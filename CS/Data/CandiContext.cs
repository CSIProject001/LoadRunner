using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.Data
{
    using CS.Models.DBModels;
    using CS.Models.OrderViewModels;
    using CS.Models.ProductViewModels;

    using Microsoft.EntityFrameworkCore;

    public class CandiContext : DbContext
    {
        public CandiContext(DbContextOptions<CandiContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Phone>().ToTable("Phone");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
            modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCart");
        }
    }
}
