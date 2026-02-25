using Microsoft.EntityFrameworkCore;
using JworgApi.Models;

namespace JworgApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
    }
}