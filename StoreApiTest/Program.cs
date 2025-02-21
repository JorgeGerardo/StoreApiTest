
using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.EntityFrameworkCore;
using StoreApiTest.Data;
using StoreApiTest.Services;

namespace StoreApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var SqlConnection = builder.Configuration.GetConnectionString("SqlServerCon");
            builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(SqlConnection));
            DIService.InjectDependencies(builder);

            //Cors addition:
            builder.Services.AddCors(cors =>
            {
                cors.AddPolicy(name: "Cors_Angular",
                    builder => builder.WithOrigins(@"http://localhost:4200")
                        .AllowAnyHeader() // Permite cualquier encabezado
                        .AllowAnyMethod() // Permite cualquier método HTTP
                        .AllowCredentials() // Permite el envío de cookies o credenciales
                );
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors("Cors_Angular");


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
