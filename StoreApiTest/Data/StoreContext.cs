using Microsoft.EntityFrameworkCore;
using Bussiness.Models;

namespace StoreApiTest.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options) :base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //Intermediat
        public DbSet<CustomerProduct> CustomerProducts { get; set; }
        public DbSet<ProductStore> StoreProducts { get; set; }




    }
}
