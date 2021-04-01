using Microsoft.EntityFrameworkCore;
using TarefasBackEnd.models;

namespace TarefasBackEnd.Repositories
{
    public class DataContext: DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DataContext(DbContextOptions options): base(options) { }
        

    }
}