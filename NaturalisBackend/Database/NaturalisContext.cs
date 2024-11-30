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
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductTypeNavigation)
                .WithMany()
                .HasForeignKey(p => p.ProductType)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductTypeNavigation)
                .WithMany()  // Assuming ProductType is referenced only in Product
                .HasForeignKey(p => p.ProductType)
                .OnDelete(DeleteBehavior.Cascade);

            // Purchase - User: Many-to-One
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.UserData)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Use Restrict or Cascade based on your requirements

            // Purchase - Delivery: Many-to-One
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.DeliveryData)
                .WithMany(d => d.Purchases)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.SetNull); // Choose appropriate delete behavior (e.g., SetNull or Cascade)

            // Purchase - Payment: Many-to-One
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.PaymentData)
                .WithMany()  // Assuming Payment is not referenced in any other entity
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.SetNull);

            // CartItem - Product: Many-to-One
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Product) // Use the navigation property, not just ProductId
                .WithMany()  // Assuming Product is not referenced in any other entity
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete if Product is deleted


            // Delivery - User: Many-to-One
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.User)
                .WithMany(u => u.Deliveries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);



        }

    }
}
