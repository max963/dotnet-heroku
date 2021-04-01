
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TarefasBackEnd.models;
using TarefasBackEnd.Repositories;

namespace TarefasBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Tarefa")]
    public class TarefaController: ControllerBase
    {

        [HttpGet]
        public IActionResult Get([FromServices]ITarefaRepository repository)
        {
            var id = Guid.Parse(User.Identity.Name);
            var tarefas = repository.Read(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarefa tarefa, [FromServices]ITarefaRepository repository)
        {
            if(!ModelState.IsValid) return BadRequest();

            tarefa.UsuarioId = Guid.Parse(User.Identity.Name);

            repository.Create(tarefa);

            return Ok();

        }

        [HttpPut]
        public IActionResult Put([FromBody] Tarefa tarefa, [FromServices]ITarefaRepository repository)
        {
            if(!ModelState.IsValid) return BadRequest();

            repository.Update(tarefa);

            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Guid Id, [FromServices]ITarefaRepository repository)
        {

            repository.Delete(Id);

            return Ok();

        }
    }
}