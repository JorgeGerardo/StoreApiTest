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

            UserDataSeed(modelBuilder);
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
