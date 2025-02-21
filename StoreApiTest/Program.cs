
using Bussiness.Models;
using Bussiness.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StoreApiTest.Data;
using StoreApiTest.Services;
using System.Security.Claims;
using System.Text;

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

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Planify", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });



            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)
                        ),

                        ClockSkew = TimeSpan.Zero,
                        NameClaimType = "UserId",
                        RoleClaimType = ClaimTypes.Role,
                    }
                );


            var app = builder.Build();
            app.UseCors("Cors_Angular");
            app.UseAuthentication();
            app.UseAuthorization();


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
