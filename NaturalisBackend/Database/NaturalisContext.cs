using Microsoft.EntityFrameworkCore;
using NaturalisBackend.Models;

namespace NaturalisBackend.Database
{
    public class NaturalisContext : DbContext
    {
        public NaturalisContext(DbContextOptions<NaturalisContext> options) : base(options) { }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Produtos { get; set; }
        public DbSet<Test> Test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductTypeNavigation)
                .WithMany()
                .HasForeignKey(p => p.ProductType)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
