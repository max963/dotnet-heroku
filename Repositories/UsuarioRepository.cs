using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TarefasBackEnd.models;

namespace TarefasBackEnd.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;
        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            _dataContext.Usuarios.Add(usuario);
            _dataContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var usuario = _dataContext.Usuarios.Find(id);

            _dataContext.Entry(usuario).State = EntityState.Deleted;
            _dataContext.SaveChanges();
        }

        public List<Usuario> Read()
        {
            return _dataContext.Usuarios.ToList();
        }

        public Usuario Read(string email, string senha)
        {
            return _dataContext.Usuarios.SingleOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void Update(Usuario usuario)
        {
            _dataContext.Entry(usuario).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}