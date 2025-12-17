using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace INFRAESTRUCTURE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Chamado> Chamados => Set<Chamado>();
        public DbSet<Interacao> Interacoes => Set<Interacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aqui depois entram Fluent Configurations
        }
    }
}