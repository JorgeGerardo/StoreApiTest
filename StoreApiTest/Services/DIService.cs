using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.EntityFrameworkCore;
using StoreApiTest.Data;

namespace StoreApiTest.Services
{
    public static class DIService
    {

        public static void InjectDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<DbContext, StoreContext>();
            builder.Services.AddScoped<IGenericRepository<Product>, ProductRepository>();
            builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
            builder.Services.AddScoped<IGenericRepository<Store>, StoreRepository>();
            builder.Services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();
            builder.Services.AddScoped<IGenericRepository<StoreInventary>, StoreInventaryRepository>();
        }
    }
}
