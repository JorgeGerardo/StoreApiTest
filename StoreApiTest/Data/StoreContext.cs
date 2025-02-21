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
        public DbSet<InventaryTransaction> Transactions { get; set; }

        //Intermediat
        public DbSet<CustomerProduct> CustomerProducts { get; set; }
        public DbSet<StoreInventary> StoreInventaries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ProductDataSeed(modelBuilder);
            CustomerDataSeed(modelBuilder);
            UserDataSeed(modelBuilder);
            SetInventory(modelBuilder);
            SetStoresDataSeed(modelBuilder);

            modelBuilder.Entity<StoreInventary>(e => e.ToTable("StoreInventary"));
        }

        private void SetStoresDataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = 1,
                    Sucursal = "Warlmart Central",
                    Address = "Monterrey, N.L"
                },
                new Store
                {
                    Id = 2,
                    Sucursal = "Soriana Centro",
                    Address = "Guadalajara, JAL"
                },
                new Store
                {
                    Id = 3,
                    Sucursal = "Chedraui Insurgentes",
                    Address = "Ciudad de México, CDMX"
                },
                new Store
                {
                    Id = 4,
                    Sucursal = "La Comer Puebla",
                    Address = "Puebla, PUE"
                },
                new Store
                {
                    Id = 5,
                    Sucursal = "H-E-B Tijuana",
                    Address = "Tijuana, BC"
                },
                new Store
                {
                    Id = 6,
                    Sucursal = "Oxxo Las Torres",
                    Address = "León, GTO"
                },
                new Store
                {
                    Id = 7,
                    Sucursal = "7-Eleven Zapopan",
                    Address = "Zapopan, JAL"
                },
                new Store
                {
                    Id = 8,
                    Sucursal = "Bodega Aurrera Mérida",
                    Address = "Mérida, YUC"
                },
                new Store
                {
                    Id = 9,
                    Sucursal = "Superama Cancún",
                    Address = "Cancún, QROO"
                }

            );
        }

        private void SetInventory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventaryTransaction>()
            .HasOne(it => it.StoreStock)
            .WithMany(ps => ps.Transacctions)
            .HasForeignKey(it => it.TransactionId)
            .OnDelete(DeleteBehavior.Restrict);
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
                    },
                    new Product 
                    {
                        Id = 10,
                        Title = "Tenis para futbool",
                        Description = "Son unos tenis brillantes muy bonitos",
                        Price = 2300,
                        Image = "https://i.imgur.com/qNOjJje.jpeg",
                    },
                    new Product 
                    {
                        Id = 11,
                        Title = "Sofa negro",
                        Description = "Es un sofa muy comodo para cuando te visite la familia",
                        Price = 5600,
                        Image = "https://i.imgur.com/Qphac99.jpeg",
                    },
                    new Product 
                    {
                        Id = 12,
                        Title = "Iphone 17 Pro Max Plus",
                        Description = "Es el nuevo Iphone con un chip A19 Bionic",
                        Price = 28000,
                        Image = "https://m.media-amazon.com/images/I/71ZzBv49bTL.jpg",
                    },
                    new Product 
                    {
                        Id = 13,
                        Title = "Gorro rojo",
                        Description = "Es un gorro con cordones",
                        Price = 599,
                        Image = "https://i.imgur.com/kg1ZhhH.jpeg",
                    },
                    new Product 
                    {
                        Id = 14,
                        Title = "Vaso de cristal",
                        Description = "Es un vaso de cristal con una naranja dentro",
                        Price = 246,
                        Image = "https://i.imgur.com/b7trwCv.jpeg",
                    },
                    new Product 
                    {
                        Id = 15,
                        Title = "Polystation Controller",
                        Description = "No es un control del polystation pero suena bien",
                        Price = 333,
                        Image = "https://i.imgur.com/ZANVnHE.jpeg",
                    },
                    new Product 
                    {
                        Id = 16,
                        Title = "Jugo de fruta",
                        Description = "Deliciosa bebida de fruta fresca",
                        Price = 199,
                        Image = "https://i.imgur.com/BLDByXP.jpeg",
                    },
                    new Product 
                    {
                        Id = 17,
                        Title = "Sudadera roja",
                        Description = "Sudadera tipo cholo de barrio, ni el Brayan se te acercará",
                        Price = 399,
                        Image = "https://iili.io/dAyUpkJ.jpg",
                    },
                    new Product 
                    {
                        Id = 18,
                        Title = "Vasos de cristal",
                        Description = "Vasos para tomar agua cuando tengas mucha sed",
                        Price = 799,
                        Image = "https://i.imgur.com/TF0pXdL.jpeg",
                    },
                    new Product 
                    {
                        Id = 19,
                        Title = "Sudadera roja",
                        Description = "Perfecto conjunto para cuando te disfraces de santa",
                        Price = 333,
                        Image = "https://i.imgur.com/FDwQgLy.jpeg",
                    },
                    new Product
                    {
                        Id = 20,
                        Title = "Gorra de color Azul",
                        Description = "Ideal para protegerte del sol con estilo.",
                        Price = 150,
                        Image = "https://i.imgur.com/N1GkCIR.jpeg",
                    },
                    new Product
                    {
                        Id = 21,
                        Title = "Camiseta de color Verde",
                        Description = "Perfecta para días casuales y relajados.",
                        Price = 200,
                        Image = "https://i.imgur.com/cBuLvBi.jpeg",
                    },
                    new Product
                    {
                        Id = 22,
                        Title = "Sudadera de color Gris",
                        Description = "Abrígate con comodidad y un toque moderno.",
                        Price = 350,
                        Image = "https://i.imgur.com/KcT6BE0.jpeg",
                    },
                    new Product
                    {
                        Id = 23,
                        Title = "Pantalón de color Negro",
                        Description = "Versátil y cómodo para cualquier ocasión.",
                        Price = 400,
                        Image = "https://i.imgur.com/BZrIEmb.jpeg",
                    },
                    new Product
                    {
                        Id = 24,
                        Title = "Chamarra de color Rojo",
                        Description = "Para mantenerte abrigado con un toque llamativo.",
                        Price = 550,
                        Image = "https://i.imgur.com/wXuQ7bm.jpeg",
                    },
                    new Product
                    {
                        Id = 25,
                        Title = "Bufanda de color Morado",
                        Description = "Accesorio ideal para el invierno.",
                        Price = 120,
                        Image = "https://i.imgur.com/76HAxcA.jpeg",
                    },
                    new Product
                    {
                        Id = 26,
                        Title = "Sombrero de color Beige",
                        Description = "Perfecto para un look veraniego.",
                        Price = 180,
                        Image = "https://i.imgur.com/Wv2KTsf.jpeg",
                    },
                    new Product
                    {
                        Id = 27,
                        Title = "Zapatos de color Marrón",
                        Description = "Comodidad y estilo en cada paso.",
                        Price = 600,
                        Image = "https://i.imgur.com/R3iobJA.jpeg",
                    },
                    new Product
                    {
                        Id = 28,
                        Title = "Suéter de color Amarillo",
                        Description = "Ideal para darle vida a tu outfit.",
                        Price = 300,
                        Image = "https://i.imgur.com/JQRGIc2.jpeg",
                    },
                    new Product
                    {
                        Id = 29,
                        Title = "Chaleco de color Naranja",
                        Description = "Añade una capa extra de calidez y estilo.",
                        Price = 250,
                        Image = "https://i.imgur.com/mp3rUty.jpeg",
                    },
                    new Product
                    {
                        Id = 30,
                        Title = "Playera de color Celeste",
                        Description = "Fresca y ligera para el verano.",
                        Price = 220,
                        Image = "https://i.imgur.com/N1GkCIR.jpeg",
                    },
                    new Product
                    {
                        Id = 31,
                        Title = "Pantalones cortos de color Caqui",
                        Description = "Comodidad y frescura para días calurosos.",
                        Price = 280,
                        Image = "https://i.imgur.com/cBuLvBi.jpeg",
                    },
                    new Product
                    {
                        Id = 32,
                        Title = "Gorra de color Blanco",
                        Description = "Combina con cualquier atuendo casual.",
                        Price = 130,
                        Image = "https://i.imgur.com/KcT6BE0.jpeg",
                    },
                    new Product
                    {
                        Id = 33,
                        Title = "Jersey de color Vino",
                        Description = "Perfecto para climas frescos con estilo.",
                        Price = 370,
                        Image = "https://i.imgur.com/BZrIEmb.jpeg",
                    },
                    new Product
                    {
                        Id = 34,
                        Title = "Cazadora de color Verde Oliva",
                        Description = "Ideal para aventuras al aire libre.",
                        Price = 600,
                        Image = "https://i.imgur.com/wXuQ7bm.jpeg",
                    },
                    new Product
                    {
                        Id = 35,
                        Title = "Blusa de color Fucsia",
                        Description = "Dale un toque de color vibrante a tu look.",
                        Price = 250,
                        Image = "https://i.imgur.com/76HAxcA.jpeg",
                    },
                    new Product
                    {
                        Id = 36,
                        Title = "Chaleco de color Gris Oscuro",
                        Description = "Aporta calidez sin perder movilidad.",
                        Price = 320,
                        Image = "https://i.imgur.com/Wv2KTsf.jpeg",
                    },
                    new Product
                    {
                        Id = 37,
                        Title = "Botines de color Caramelo",
                        Description = "Estilo y comodidad en cada pisada.",
                        Price = 700,
                        Image = "https://i.imgur.com/R3iobJA.jpeg",
                    },
                    new Product
                    {
                        Id = 38,
                        Title = "Camiseta de color Naranja",
                        Description = "Alegra tu día con este color enérgico.",
                        Price = 210,
                        Image = "https://i.imgur.com/JQRGIc2.jpeg",
                    },
                    new Product
                    {
                        Id = 39,
                        Title = "Sudadera de color Azul Marino",
                        Description = "Perfecta para mantenerte abrigado y cómodo.",
                        Price = 350,
                        Image = "https://i.imgur.com/mp3rUty.jpeg",
                    },
                    new Product
                    {
                        Id = 40,
                        Title = "Bufanda de color Azul Cobalto",
                        Description = "El toque ideal para un look invernal.",
                        Price = 140,
                        Image = "https://i.imgur.com/N1GkCIR.jpeg",
                    }


                );
        }

        private void CustomerDataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                    new Customer
                    {
                        Id = 1,
                        Name = "Jorguito",
                        Address = "Guanajuato",
                        LastName = "Gerardo",
                    },
                    new Customer
                    {
                        Id = 2,
                        Name = "Lucrecia",
                        Address = "Monterrey",
                        LastName = "Lopez",
                    },
                    new Customer
                    {
                        Id = 3,
                        Name = "Samuel",
                        Address = "Guadalajara",
                        LastName = "Urias",
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
                        CustomerId = 1,
                    },
                    new User() //customer
                    {
                        Id = 2,
                        Email = "lucrecia@example.com",
                        HashPassword = TokenService.EncrypBySHA256("lucrecia"),
                        Role = Role.Customer,
                        CustomerId = 2
                    },
                    new User() //customer
                    {
                        Id = 3,
                        Email = "samueljuan@example.com",
                        HashPassword = TokenService.EncrypBySHA256("samueljuan"),
                        Role = Role.Customer,
                        CustomerId = 3
                    }
                );
        }


    }
}
