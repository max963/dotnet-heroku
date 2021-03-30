
using System;
using Microsoft.AspNetCore.Mvc;
using TarefasBackEnd.models;
using TarefasBackEnd.Repositories;

namespace TarefasBackEnd.Controllers
{
    [ApiController]
    [Route("Tarefa")]
    public class TarefaController: ControllerBase
    {

        [HttpGet]
        public IActionResult Get([FromServices]ITarefaRepository repository)
        {
            var tarefas = repository.Read();
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarefa tarefa, [FromServices]ITarefaRepository repository)
        {
            if(!ModelState.IsValid) return BadRequest();

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