using Microsoft.EntityFrameworkCore;
using pasaj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.DataAccess.Data
{
    public class PasajDataContext : DbContext
    {
        public PasajDataContext(DbContextOptions<PasajDataContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //PostgeSql, SQLite, Oracle, MySQL, Cosmos DB, MSSQL
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=PasajDb;Integrated Security=True;Encrypt=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name)
                                          .IsRequired()
                                          .HasMaxLength(120);

            modelBuilder.Entity<Product>().Property(p => p.Price)
                                          .HasPrecision(4, 2);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Müzik" },
                new Category { Id = 2, Name = "Elektronik" },
                new Category { Id = 3, Name = "Kitap" }


                );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Gitar",
                    Description = "Mendel",
                    CategoryId = 1,
                    DiscountRate = 0.15m,
                    Price = 10000,
                    Stock = 200,
                    ImageUrl = "https://ffo3gv1cf3ir.merlincdn.net/SiteAssets/pasaj/crop/cg/00LWMC/00LWMC-1/00LWMC-1_250x188.png?17735349480679"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Davul",
                    Description = "Yamaha",
                    CategoryId = 1,
                    Price = 15000,
                    DiscountRate = 0.20m,
                    ImageUrl = "https://ffo3gv1cf3ir.merlincdn.net/SiteAssets/pasaj/crop/cg/00LWMC/00LWMC-1/00LWMC-1_250x188.png?17735349480679",
                    Stock = 250
                },
                 new Product()
                 {
                     Id = 3,
                     Name = "Denizler Altından 20.000 Fersah",
                     Description = "Yamaha",
                     CategoryId = 3,
                     Price = 200,
                     DiscountRate = 0.20m,
                     ImageUrl = "https://ffo3gv1cf3ir.merlincdn.net/SiteAssets/pasaj/crop/cg/00LWMC/00LWMC-1/00LWMC-1_250x188.png?17735349480679",
                     Stock = 250
                 }


                );



        }

    }
}
