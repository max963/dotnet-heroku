using System;
using System.Collections.Generic;
using TarefasBackEnd.models;

namespace TarefasBackEnd.Repositories
{
    public interface ITarefaRepository
    {
        List<Tarefa> Read(Guid id);

        void Create(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Guid id);
    }
}