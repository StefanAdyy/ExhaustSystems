using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseSqlServer("Server=localhost;Database=ExhaustSystems;User Id=stefan;Password=1q2w3e; TrustServerCertificate=True")
                    .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Class>().Property(e => e.Name).HasMaxLength(10);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPart> OrderPart { get; set; }
        public DbSet<Part> Parts { get; set; }
    }
}
