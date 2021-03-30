using System;
using System.ComponentModel.DataAnnotations;

namespace TarefasBackEnd.models
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }
        public bool Concluida { get; set; }

    }
}