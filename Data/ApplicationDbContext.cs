using lab4t1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab4t1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produtora> Produtoras { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Compras> Compras { get; set; }
    }
}