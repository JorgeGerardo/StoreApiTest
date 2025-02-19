using Microsoft.EntityFrameworkCore;
using Bussiness.Models;
using System.Reflection.Emit;
using StoreApiTest.Services;

namespace StoreApiTest.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options) :base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        //Intermediat
        public DbSet<CustomerProduct> CustomerProducts { get; set; }
        public DbSet<ProductStore> StoreProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ProductDataSeed(modelBuilder);
            UserDataSeed(modelBuilder);
        }

        private void ProductDataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product 
                    {
                        Id = 1,
                        Title = "Playera negra",
                        Description = "Playera para hombre talla mediana en color negro",
                        Price = 700,
                        Image = "https://i.imgur.com/QkIa5tT.jpeg",
                    },
                    new Product 
                    {
                        Id = 2,
                        Title = "Sudadera",
                        Description = "Sudadera muy padre en color gris para hombres con frío",
                        Price = 632,
                        Image = "https://i.imgur.com/wbIMMme.jpeg",
                    },
                    new Product 
                    {
                        Id = 3,
                        Title = "Sudadera dark gray",
                        Description = "Sudadera muy padre en color gris oscuro para hombres que tengan frío",
                        Price = 234,
                        Image = "https://i.imgur.com/R2PN9Wq.jpeg",
                    },
                    new Product 
                    {
                        Id = 4,
                        Title = "Sudadera gris gray",
                        Description = "Es la misma sudadera solo que con otra foto y vendida como otro producto",
                        Price = 234,
                        Image = "https://i.imgur.com/R2PN9Wq.jpeg",
                    },
                    new Product 
                    {
                        Id = 5,
                        Title = "Sudadera negra",
                        Description = "Es una sudadera de color negro muuuuy bonita",
                        Price = 879,
                        Image = "https://i.imgur.com/R2PN9Wq.jpeg",
                    },
                    new Product 
                    {
                        Id = 6,
                        Title = "Pantalón de pijama",
                        Description = "Es un pantalón que parece pijama",
                        Price = 879,
                        Image = "https://i.imgur.com/R2PN9Wq.jpeg",
                    },
                    new Product 
                    {
                        Id = 7,
                        Title = "Pijama mujer",
                        Description = "Es un pantalón que parece pijama pero esta vez es para mujeres",
                        Price = 373,
                        Image = "https://i.imgur.com/mp3rUty.jpeg",
                    },
                    new Product 
                    {
                        Id = 8,
                        Title = "Pijama negra",
                        Description = "Es un pantalón negro de pijama para caballero",
                        Price = 373,
                        Image = "https://i.imgur.com/ZKGofuB.jpeg",
                    },
                    new Product 
                    {
                        Id = 9,
                        Title = "Pijama blanca",
                        Description = "Es un pantalón blanco de pijama para dama",
                        Price = 723,
                        Image = "https://i.imgur.com/mp3rUty.jpeg",
                    }

                );
        }
        private void UserDataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User() //admin
                    {
                        Id = 1,
                        Email = "jorguito@example.com",
                        HashPassword = TokenService.EncrypBySHA256("jorguito"),
                        Role = Role.Admin,
                    },
                    new User() //customer
                    {
                        Id = 2,
                        Email = "lucrecia@example.com",
                        HashPassword = TokenService.EncrypBySHA256("lucrecia"),
                        Role = Role.Customer,
                    },
                    new User() //customer
                    {
                        Id = 3,
                        Email = "samueljuan@example.com",
                        HashPassword = TokenService.EncrypBySHA256("samueljuan"),
                        Role = Role.Customer
                    }
                );
        }


    }
}
