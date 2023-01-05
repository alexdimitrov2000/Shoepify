using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shoepify.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreShoeProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Shoes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hex = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeInCm = table.Column<double>(type: "float", nullable: false),
                    SizeEU = table.Column<double>(type: "float", nullable: false),
                    SizeUS = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoeColors",
                columns: table => new
                {
                    ShoeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeColors", x => new { x.ShoeId, x.ColorId });
                    table.ForeignKey(
                        name: "FK_ShoeColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoeColors_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoeSizes",
                columns: table => new
                {
                    ShoeId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSizes", x => new { x.ShoeId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ShoeSizes_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoeSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeColors_ColorId",
                table: "ShoeColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizes_SizeId",
                table: "ShoeSizes",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ShoeColors");

            migrationBuilder.DropTable(
                name: "ShoeSizes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Shoes");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Shoes",
                type: "int",
                nullable: true);
        }
    }
}
