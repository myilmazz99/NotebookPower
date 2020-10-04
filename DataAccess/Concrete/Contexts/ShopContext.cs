using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
    public class ShopContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:notebookpower.database.windows.net,1433;Initial Catalog=notebookpower;Persist Security Info=False;User ID=admin_notebookpower;Password=Notmusti230395;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
