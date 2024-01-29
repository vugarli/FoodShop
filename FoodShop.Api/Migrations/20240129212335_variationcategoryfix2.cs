using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class variationcategoryfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVariation_Variation_VaritaionsId",
                table: "CategoryVariation");

            migrationBuilder.RenameColumn(
                name: "VaritaionsId",
                table: "CategoryVariation",
                newName: "VariationsId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryVariation_VaritaionsId",
                table: "CategoryVariation",
                newName: "IX_CategoryVariation_VariationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVariation_Variation_VariationsId",
                table: "CategoryVariation",
                column: "VariationsId",
                principalTable: "Variation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryVariation_Variation_VariationsId",
                table: "CategoryVariation");

            migrationBuilder.RenameColumn(
                name: "VariationsId",
                table: "CategoryVariation",
                newName: "VaritaionsId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryVariation_VariationsId",
                table: "CategoryVariation",
                newName: "IX_CategoryVariation_VaritaionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryVariation_Variation_VaritaionsId",
                table: "CategoryVariation",
                column: "VaritaionsId",
                principalTable: "Variation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
