using DataAccess.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderItem>().HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product {Id = 1, Name = "Product1", Price = 1},
                new Product {Id = 2, Name = "Product2", Price = 10},
                new Product {Id = 3, Name = "Product3", Price = 100},
            });

            modelBuilder.Entity<Order>().HasData(new List<Order>
            {
                new Order { Id = 1, CreatedDate = DateTime.Now, Status = OrderStatus.Created }
            });

            modelBuilder.Entity<OrderItem>().HasData(new List<OrderItem>
            {
                new OrderItem { OrderId = 1, ProductId = 1, Quantity = 1},
                new OrderItem { OrderId = 1, ProductId = 2, Quantity = 2},
                new OrderItem { OrderId = 1, ProductId = 3, Quantity = 3},
            });
        }
    }
}
