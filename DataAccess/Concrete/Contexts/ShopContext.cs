using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
    public class ShopContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(new SqlConnectionStringBuilder
            {
                UserID = "sqlserver",
                Password = "Notebookpoweradmin1",
                DataSource = "34.65.36.167",
                InitialCatalog = "NotebookPowerDB",
            }.ConnectionString);
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
