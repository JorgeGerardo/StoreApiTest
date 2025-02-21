using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApiTest.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedDataProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Price", "Title" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);
        }
    }
}
