using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Category>().HasData(
        new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1 },
        new Category { CategoryId = 2, Name = "SciFi", DisplayOrder = 2 },
        new Category { CategoryId = 3, Name = "History", DisplayOrder = 3 }
      );
      modelBuilder.Entity<Product>().HasData(
        new Product
        {
          ProductId = 1,
          Title = "Ella",
          Description = "Libro sobre ella",
          ISBN = "C928341",
          Author = "Agatha Cristie",
          ListPrice = 100000,
          Price = 1200,
          Price50 = 9823,
          Price100 = 12832,
          CategoryId = 3,
          ImageUrl = ""
        },
        new Product
        {
          ProductId = 2,
          Title = "El",
          Description = "Libro sobre el",
          ISBN = "C928342",
          Author = "Agatha Cristie",
          ListPrice = 110000,
          Price = 11200,
          Price50 = 9824,
          Price100 = 12132,
          CategoryId = 3,
          ImageUrl = ""
        },
        new Product
        {
          ProductId = 3,
          Title = "Prueba",
          Description = "Wasd",
          ISBN = "C928343",
          Author = "Agatha Cristie",
          ListPrice = 1100,
          Price = 120,
          Price50 = 983,
          Price100 = 1832,
          CategoryId = 2,
          ImageUrl = ""
        }
      );
    }
  }
}