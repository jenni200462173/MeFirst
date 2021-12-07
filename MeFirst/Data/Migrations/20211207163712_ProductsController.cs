using Microsoft.EntityFrameworkCore.Migrations;

namespace MeFirst.Data.Migrations
{
    public partial class ProductsController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TreatmentsID",
                table: "SkinTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "SkinTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkinType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Combination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkinTypeID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkinTypes_ProductsId",
                table: "SkinTypes",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkinTypes_Products_ProductsId",
                table: "SkinTypes",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "ProductsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkinTypes_Products_ProductsId",
                table: "SkinTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_SkinTypes_ProductsId",
                table: "SkinTypes");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "SkinTypes");

            migrationBuilder.AlterColumn<string>(
                name: "TreatmentsID",
                table: "SkinTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
