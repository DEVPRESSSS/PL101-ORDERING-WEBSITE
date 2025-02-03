using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = "CAT-1012", Name = "Hot Coffe" },
                new Category { CategoryID = "CAT-1013", Name = "Iced Coffe" }
            );

            modelBuilder.Entity<Products>().HasData(
              new Products
              {
                  ProductID = "PROD-202",
                  Name = "Product101",
                  Description = "Test",
                  Size = "30oz",
                  Price = 50,
                  Stock= 2,
                  CreatedAt = DateOnly.Parse("2023-12-10"),
                  Category_ID= "CAT-1012"
              },
               new Products
               {
                   ProductID = "PROD-203",
                   Name = "Product101",
                   Description = "Test",
                   Size = "30oz",
                   Price = 50,
                   Stock = 2,
                   CreatedAt = DateOnly.Parse("2023-12-10"),
                   Category_ID = "CAT-1012"
               },
                new Products
                {
                    ProductID = "PROD-204",
                    Name = "Product101",
                    Description = "Test",
                    Size = "30oz",
                    Price = 50,
                    Stock = 2,
                    CreatedAt = DateOnly.Parse("2023-12-10"),
                    Category_ID = "CAT-1012"
                }





              );



        }

    }
}
