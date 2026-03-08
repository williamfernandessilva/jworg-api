using Microsoft.EntityFrameworkCore;
using JworgApi.Models;

namespace JworgApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> usuarios { get; set; }


        public DbSet<Bairro> bairros { get; set; } 
    }
}