using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TarefasBackEnd.models;

namespace TarefasBackEnd.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _dataContext;
        public TarefaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Tarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid();
            _dataContext.Tarefas.Add(tarefa);
            _dataContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var tarefa = _dataContext.Tarefas.Find(id);

            _dataContext.Entry(tarefa).State = EntityState.Deleted;
            _dataContext.SaveChanges();
        }

        public List<Tarefa> Read()
        {
            return _dataContext.Tarefas.ToList();
        }

        public void Update(Tarefa tarefa)
        {
            // var _tarefa = _dataContext.Tarefas.Find(tarefa.Id);

            // _dataContext.Update(tarefa);
            _dataContext.Entry(tarefa).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}