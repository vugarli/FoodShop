using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variation_Category_CategoryId1",
                table: "Variation");

            migrationBuilder.DropIndex(
                name: "IX_Variation_CategoryId1",
                table: "Variation");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Variation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "Variation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variation_CategoryId1",
                table: "Variation",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Variation_Category_CategoryId1",
                table: "Variation",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
