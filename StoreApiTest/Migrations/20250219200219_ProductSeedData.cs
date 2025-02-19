using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApiTest.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 9, "Es un pantalón blanco de pijama para dama", "https://i.imgur.com/mp3rUty.jpeg", 723f, "Pijama blanca" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
