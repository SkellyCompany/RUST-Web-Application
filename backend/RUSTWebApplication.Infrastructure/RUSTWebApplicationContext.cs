using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.Entity.Authentication;
using RUSTWebApplication.Core.Entity.Order;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure
{
    public class RUSTWebApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductMetric> ProductMetrics { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }

        public RUSTWebApplicationContext(DbContextOptions<RUSTWebApplicationContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            


        }

    }
}

    
