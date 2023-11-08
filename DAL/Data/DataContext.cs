using DAL.Models;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasOne(e => e.ShoppingCart)
                .WithOne(e => e.Customer)
                .HasForeignKey<ShoppingCart>(e => e.CustomerID)
                .IsRequired();

            builder.Entity<ShoppingCart>()
                .HasOne(e => e.Order)
                .WithOne(e => e.ShoppingCart)
                .HasForeignKey<Order>(e => e.CartID)
                .IsRequired();

            builder.Entity<Payment>()
               .HasOne(e => e.Order)
               .WithOne(e => e.Payment)
               .HasForeignKey<Payment>(e => e.OrderID)
               .IsRequired();


            builder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false);

            builder.Entity<Customer>()
                .HasMany(e => e.Payments)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerID)
                .IsRequired(false);

            builder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerID)
                .IsRequired(false);

           
            builder.Entity<OrderDetails>()
                .HasKey(pc => new { pc.OrderID, pc.ProductID });
            builder.Entity<OrderDetails>()
                .HasOne(p => p.Order)
                .WithMany(pc => pc.OrderDetails)
                .HasForeignKey(p => p.OrderID);
            builder.Entity<OrderDetails>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.OrderDetails)
                .HasForeignKey(p => p.ProductID);

            builder.Entity<CartDetails>()
                .HasKey(pc => new {pc.CartID, pc.ProductID});
            builder.Entity<CartDetails>()
                .HasOne(p => p.Cart)
                .WithMany(pc => pc.CartDetails)
                .HasForeignKey(p => p.CartID);
            builder.Entity<CartDetails>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.CartDetails)
                .HasForeignKey(p => p.ProductID);
        }
    }
}
