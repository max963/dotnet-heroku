using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TarefasBackEnd.Dtos;
using TarefasBackEnd.models;
using TarefasBackEnd.Repositories;

namespace TarefasBackEnd.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices]IUsuarioRepository  repository)
        {
            var usuario = repository.Read();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario, [FromServices]IUsuarioRepository repository)
        {
            if(!ModelState.IsValid) return BadRequest();
            
            repository.Create(usuario);

            return Ok();
            
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDto model, [FromServices]IUsuarioRepository repository)
        {
            if(!ModelState.IsValid) return BadRequest();
            var usuario = repository.Read(model.Email, model.Senha);
            
            if (usuario == null)
            {
                return BadRequest();
            }

            return Ok(new {
                usuario = usuario,
                token = GenerateToken(usuario)
            });
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario usuario, [FromServices]IUsuarioRepository repository)
        {
            if(!ModelState.IsValid) return BadRequest();

            repository.Update(usuario);

            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Guid Id, [FromServices]IUsuarioRepository repository)
        {

            repository.Delete(Id);

            return Ok();

        }


        private string GenerateToken(Usuario usuario) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = "123456asdksdfsdaiusdsdbnxnzxbiuwqnxjnksmncxhsmxzkiyhermmxj";
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature
                )

            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}