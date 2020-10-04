using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Contexts
{
    public class ShopContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ShopContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionString").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSpecification>().HasKey(i => new { i.ProductId, i.SpecificationId });
            modelBuilder.Entity<EmailList>().HasKey(i => i.Email);
        }

        public DbSet<Product> Products { get; set; }
        public virtual DbSet<Specification> Specifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<EmailList> EmailList { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
