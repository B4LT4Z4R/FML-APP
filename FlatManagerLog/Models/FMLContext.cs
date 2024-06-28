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
         public DbSet<Rooms> Rooms { get; set; }


         
        public DbSet<Tenants> Tenants { get; set; }
        public DbSet<Payments> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenants>()
                .HasMany(t => t.Payments)
                .WithOne(p => p.Tenant)
                .HasForeignKey(p => p.TenantId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
