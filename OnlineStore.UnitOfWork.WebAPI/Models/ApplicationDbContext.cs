using Microsoft.EntityFrameworkCore;

namespace OnlineStore.UnitOfWork.WebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(x =>
            {
                x.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);

                x.Property(e => e.ListPrice).HasColumnType("decimal(10,2)");
                x.Property(e => e.SellingPrice).HasColumnType("decimal(10,2)");
                x.Property(e => e.Discount).HasDefaultValueSql("0");
                x.Property(e => e.AddedDate).HasDefaultValueSql("getdate()");

                //Add Data to Product Table
                x.HasData(
                    new Product { Id = 1, ProductName = "Sony Television", ListPrice =55000.50M, SellingPrice=51000, Discount=5, AddedDate=DateTime.Now, CategoryId=1},
                    new Product { Id = 2, ProductName = "LG Television", ListPrice =45000.50M, SellingPrice=41000, Discount=5, AddedDate=DateTime.Now.AddDays(-2), CategoryId=1},
                    new Product { Id = 3, ProductName = "iPhone14", ListPrice =85000.50M, SellingPrice=80000, Discount=5, AddedDate=DateTime.Now, CategoryId=2},
                    new Product { Id = 4, ProductName = "Samsung M33", ListPrice =25000.50M, SellingPrice=22000, Discount=4, AddedDate=DateTime.Now, CategoryId=2},
                    new Product { Id = 5, ProductName = "Levis Jeans", ListPrice =2599M, SellingPrice=2199, Discount=5, AddedDate=DateTime.Now, CategoryId=3},
                    new Product { Id = 6, ProductName = "Shirt", ListPrice =950, SellingPrice=900, Discount=5, AddedDate=DateTime.Now, CategoryId=3},
                    new Product { Id = 7, ProductName = "Ruskin Bonds", ListPrice =259, SellingPrice=209, Discount=10, AddedDate=DateTime.Now, CategoryId=4}
                    );
            });

            modelBuilder.Entity<Category>(x =>
            {
                x.Property(e=>e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);

                //Add Rows to Category Table
                x.HasData(
                    new Category { Id=1, CategoryName="HomeApplicances"},
                    new Category { Id=2, CategoryName="Mobiles"},
                    new Category { Id=3, CategoryName="Clothing"},
                    new Category { Id=4, CategoryName="Books"}
                    );
            });


        }
    }
}
