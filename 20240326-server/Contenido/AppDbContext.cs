using _20240326_server.Models;
using Microsoft.EntityFrameworkCore;

namespace _20240326_server.Contenido
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plato> Platos => Set<Plato>();
        public AppDbContext(DbContextOptions<AppDbContext> op) : base(op)
        {
            
        }
    }
}
