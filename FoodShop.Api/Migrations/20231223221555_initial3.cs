using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_BaseCategoryDiscriminators_BaseCategoryDiscriminatorId",
                table: "Category");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseCategoryDiscriminatorId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_BaseCategoryDiscriminators_BaseCategoryDiscriminatorId",
                table: "Category",
                column: "BaseCategoryDiscriminatorId",
                principalTable: "BaseCategoryDiscriminators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_BaseCategoryDiscriminators_BaseCategoryDiscriminatorId",
                table: "Category");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseCategoryDiscriminatorId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_BaseCategoryDiscriminators_BaseCategoryDiscriminatorId",
                table: "Category",
                column: "BaseCategoryDiscriminatorId",
                principalTable: "BaseCategoryDiscriminators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
