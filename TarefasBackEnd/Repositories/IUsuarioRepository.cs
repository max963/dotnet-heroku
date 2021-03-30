using System;
using System.Collections.Generic;
using TarefasBackEnd.models;

namespace TarefasBackEnd.Repositories
{
    public interface IUsuarioRepository
    {
        List<Usuario> Read();

        Usuario Read(string email, string senha);

        void Create(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Guid id);
    }
}