using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApiTest.Migrations
{
    /// <inheritdoc />
    public partial class TittleField_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Products");
        }
    }
}
