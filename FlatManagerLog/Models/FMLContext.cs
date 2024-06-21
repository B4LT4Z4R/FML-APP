using Microsoft.EntityFrameworkCore;

namespace FlatManagerLog.Models
{
    public class FMLContext : DbContext
    {
        public FMLContext(DbContextOptions<FMLContext> options) : base(options)
        {
        }

        public DbSet<Manager> Manager { get; set; }
        public DbSet<Buildings> Buildings { get; set; }
        public DbSet<ToDos> ToDos { get; set; }
         public DbSet<Tenants> Tenants { get; set; }
    }
}
