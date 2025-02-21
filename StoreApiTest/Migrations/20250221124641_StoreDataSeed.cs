using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApiTest.Migrations
{
    /// <inheritdoc />
    public partial class StoreDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Sucursal" },
                values: new object[,]
                {
                    { 1, "Monterrey, N.L", "Warlmart Central" },
                    { 2, "Guadalajara, JAL", "Soriana Centro" },
                    { 3, "Ciudad de México, CDMX", "Chedraui Insurgentes" },
                    { 4, "Puebla, PUE", "La Comer Puebla" },
                    { 5, "Tijuana, BC", "H-E-B Tijuana" },
                    { 6, "León, GTO", "Oxxo Las Torres" },
                    { 7, "Zapopan, JAL", "7-Eleven Zapopan" },
                    { 8, "Mérida, YUC", "Bodega Aurrera Mérida" },
                    { 9, "Cancún, QROO", "Superama Cancún" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
