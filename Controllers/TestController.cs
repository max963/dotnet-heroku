using Microsoft.AspNetCore.Mvc;

namespace dotnet_heroku.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController: ControllerBase
    {
     
        [HttpGet]
        public IActionResult Get()
        {
            var retorno = new {
                funciona = "Sim",
                versao = 1,
                objeto = new {
                    item1 = "Roupa",
                    item2 = "Sapato"
                }
            };
            return Ok(retorno);
        }
    }
}