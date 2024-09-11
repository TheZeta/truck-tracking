using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>(entity =>
            {
                entity.Property(t => t.RawMaterial)
                      .HasConversion<int>();

                entity.Property(t => t.State)
                      .HasConversion<int>();
            });
        }
    }
}
