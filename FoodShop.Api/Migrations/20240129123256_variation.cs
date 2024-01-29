using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class variation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "VariationOption",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "VariationOption");
        }
    }
}
