using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoepify.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedShoeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Shoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_CategoryId",
                table: "Shoes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Categories_CategoryId",
                table: "Shoes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Categories_CategoryId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_CategoryId",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Shoes");
        }
    }
}
