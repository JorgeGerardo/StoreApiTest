using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApiTest.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreInventary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInventary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreInventary_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreInventary_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quatity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_StoreInventary_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "StoreInventary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "Guanajuato", "Gerardo", "Jorguito" },
                    { 2, "Monterrey", "Lopez", "Lucrecia" },
                    { 3, "Guadalajara", "Urias", "Samuel" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Playera para hombre talla mediana en color negro", "https://i.imgur.com/QkIa5tT.jpeg", 700f, "Playera negra" },
                    { 2, "Sudadera muy padre en color gris para hombres con frío", "https://i.imgur.com/wbIMMme.jpeg", 632f, "Sudadera" },
                    { 3, "Sudadera muy padre en color gris oscuro para hombres que tengan frío", "https://i.imgur.com/R2PN9Wq.jpeg", 234f, "Sudadera dark gray" },
                    { 4, "Es la misma sudadera solo que con otra foto y vendida como otro producto", "https://i.imgur.com/R2PN9Wq.jpeg", 234f, "Sudadera gris gray" },
                    { 5, "Es una sudadera de color negro muuuuy bonita", "https://i.imgur.com/R2PN9Wq.jpeg", 879f, "Sudadera negra" },
                    { 6, "Es un pantalón que parece pijama", "https://i.imgur.com/R2PN9Wq.jpeg", 879f, "Pantalón de pijama" },
                    { 7, "Es un pantalón que parece pijama pero esta vez es para mujeres", "https://i.imgur.com/mp3rUty.jpeg", 373f, "Pijama mujer" },
                    { 8, "Es un pantalón negro de pijama para caballero", "https://i.imgur.com/ZKGofuB.jpeg", 373f, "Pijama negra" },
                    { 9, "Es un pantalón blanco de pijama para dama", "https://i.imgur.com/mp3rUty.jpeg", 723f, "Pijama blanca" },
                    { 10, "Son unos tenis brillantes muy bonitos", "https://i.imgur.com/qNOjJje.jpeg", 2300f, "Tenis para futbool" },
                    { 11, "Es un sofa muy comodo para cuando te visite la familia", "https://i.imgur.com/Qphac99.jpeg", 5600f, "Sofa negro" },
                    { 12, "Es el nuevo Iphone con un chip A19 Bionic", "https://m.media-amazon.com/images/I/71ZzBv49bTL.jpg", 28000f, "Iphone 17 Pro Max Plus" },
                    { 13, "Es un gorro con cordones", "https://i.imgur.com/kg1ZhhH.jpeg", 599f, "Gorro rojo" },
                    { 14, "Es un vaso de cristal con una naranja dentro", "https://i.imgur.com/b7trwCv.jpeg", 246f, "Vaso de cristal" },
                    { 15, "No es un control del polystation pero suena bien", "https://i.imgur.com/ZANVnHE.jpeg", 333f, "Polystation Controller" },
                    { 16, "Deliciosa bebida de fruta fresca", "https://i.imgur.com/BLDByXP.jpeg", 199f, "Jugo de fruta" },
                    { 17, "Sudadera tipo cholo de barrio, ni el Brayan se te acercará", "https://iili.io/dAyUpkJ.jpg", 399f, "Sudadera roja" },
                    { 18, "Vasos para tomar agua cuando tengas mucha sed", "https://i.imgur.com/TF0pXdL.jpeg", 799f, "Vasos de cristal" },
                    { 19, "Perfecto conjunto para cuando te disfraces de santa", "https://i.imgur.com/FDwQgLy.jpeg", 333f, "Sudadera roja" },
                    { 20, "Ideal para protegerte del sol con estilo.", "https://i.imgur.com/N1GkCIR.jpeg", 150f, "Gorra de color Azul" },
                    { 21, "Perfecta para días casuales y relajados.", "https://i.imgur.com/cBuLvBi.jpeg", 200f, "Camiseta de color Verde" },
                    { 22, "Abrígate con comodidad y un toque moderno.", "https://i.imgur.com/KcT6BE0.jpeg", 350f, "Sudadera de color Gris" },
                    { 23, "Versátil y cómodo para cualquier ocasión.", "https://i.imgur.com/BZrIEmb.jpeg", 400f, "Pantalón de color Negro" },
                    { 24, "Para mantenerte abrigado con un toque llamativo.", "https://i.imgur.com/wXuQ7bm.jpeg", 550f, "Chamarra de color Rojo" },
                    { 25, "Accesorio ideal para el invierno.", "https://i.imgur.com/76HAxcA.jpeg", 120f, "Bufanda de color Morado" },
                    { 26, "Perfecto para un look veraniego.", "https://i.imgur.com/Wv2KTsf.jpeg", 180f, "Sombrero de color Beige" },
                    { 27, "Comodidad y estilo en cada paso.", "https://i.imgur.com/R3iobJA.jpeg", 600f, "Zapatos de color Marrón" },
                    { 28, "Ideal para darle vida a tu outfit.", "https://i.imgur.com/JQRGIc2.jpeg", 300f, "Suéter de color Amarillo" },
                    { 29, "Añade una capa extra de calidez y estilo.", "https://i.imgur.com/mp3rUty.jpeg", 250f, "Chaleco de color Naranja" },
                    { 30, "Fresca y ligera para el verano.", "https://i.imgur.com/N1GkCIR.jpeg", 220f, "Playera de color Celeste" },
                    { 31, "Comodidad y frescura para días calurosos.", "https://i.imgur.com/cBuLvBi.jpeg", 280f, "Pantalones cortos de color Caqui" },
                    { 32, "Combina con cualquier atuendo casual.", "https://i.imgur.com/KcT6BE0.jpeg", 130f, "Gorra de color Blanco" },
                    { 33, "Perfecto para climas frescos con estilo.", "https://i.imgur.com/BZrIEmb.jpeg", 370f, "Jersey de color Vino" },
                    { 34, "Ideal para aventuras al aire libre.", "https://i.imgur.com/wXuQ7bm.jpeg", 600f, "Cazadora de color Verde Oliva" },
                    { 35, "Dale un toque de color vibrante a tu look.", "https://i.imgur.com/76HAxcA.jpeg", 250f, "Blusa de color Fucsia" },
                    { 36, "Aporta calidez sin perder movilidad.", "https://i.imgur.com/Wv2KTsf.jpeg", 320f, "Chaleco de color Gris Oscuro" },
                    { 37, "Estilo y comodidad en cada pisada.", "https://i.imgur.com/R3iobJA.jpeg", 700f, "Botines de color Caramelo" },
                    { 38, "Alegra tu día con este color enérgico.", "https://i.imgur.com/JQRGIc2.jpeg", 210f, "Camiseta de color Naranja" },
                    { 39, "Perfecta para mantenerte abrigado y cómodo.", "https://i.imgur.com/mp3rUty.jpeg", 350f, "Sudadera de color Azul Marino" },
                    { 40, "El toque ideal para un look invernal.", "https://i.imgur.com/N1GkCIR.jpeg", 140f, "Bufanda de color Azul Cobalto" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CustomerId", "Email", "HashPassword", "Role" },
                values: new object[,]
                {
                    { 1, 1, "jorguito@example.com", "b88b88cd87cf54d08aabf61b73023cf35551850dc8da5a9d8ae410ef243f74ce", 1 },
                    { 2, 2, "lucrecia@example.com", "362b3c03a6b7ad6e47e3029b1eb9f31194123825ff4aec5833feca5e120446f0", 0 },
                    { 3, 3, "samueljuan@example.com", "67a0978030e50d8f060cc216bc9ae8ea0e3fa38f0951cc412e5b41744f548add", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_CustomerId",
                table: "CustomerProducts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProducts_ProductId",
                table: "CustomerProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreInventary_ProductId",
                table: "StoreInventary",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreInventary_StoreId",
                table: "StoreInventary",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StoreId",
                table: "Transactions",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionId",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                table: "Users",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProducts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StoreInventary");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
