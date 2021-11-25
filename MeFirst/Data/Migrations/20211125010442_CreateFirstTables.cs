using Microsoft.EntityFrameworkCore.Migrations;

namespace MeFirst.Data.Migrations
{
    public partial class CreateFirstTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Browses",
                columns: table => new
                {
                    BrosweId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrowseBrosweId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Browses", x => x.BrosweId);
                    table.ForeignKey(
                        name: "FK_Browses_Browses_BrowseBrosweId",
                        column: x => x.BrowseBrosweId,
                        principalTable: "Browses",
                        principalColumn: "BrosweId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkinTypes",
                columns: table => new
                {
                    SkyinTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aging = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Combination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentsID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrowseBrosweId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypes", x => x.SkyinTypeId);
                    table.ForeignKey(
                        name: "FK_SkinTypes_Browses_BrowseBrosweId",
                        column: x => x.BrowseBrosweId,
                        principalTable: "Browses",
                        principalColumn: "BrosweId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    TreatmentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moisturizer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Retinal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Toner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkinTypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrowseBrosweId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.TreatmentsId);
                    table.ForeignKey(
                        name: "FK_Treatments_Browses_BrowseBrosweId",
                        column: x => x.BrowseBrosweId,
                        principalTable: "Browses",
                        principalColumn: "BrosweId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkinTypeTreatments",
                columns: table => new
                {
                    SkinTypeSkyinTypeId = table.Column<int>(type: "int", nullable: false),
                    TreatmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypeTreatments", x => new { x.SkinTypeSkyinTypeId, x.TreatmentsId });
                    table.ForeignKey(
                        name: "FK_SkinTypeTreatments_SkinTypes_SkinTypeSkyinTypeId",
                        column: x => x.SkinTypeSkyinTypeId,
                        principalTable: "SkinTypes",
                        principalColumn: "SkyinTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkinTypeTreatments_Treatments_TreatmentsId",
                        column: x => x.TreatmentsId,
                        principalTable: "Treatments",
                        principalColumn: "TreatmentsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Browses_BrowseBrosweId",
                table: "Browses",
                column: "BrowseBrosweId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinTypes_BrowseBrosweId",
                table: "SkinTypes",
                column: "BrowseBrosweId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinTypeTreatments_TreatmentsId",
                table: "SkinTypeTreatments",
                column: "TreatmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_BrowseBrosweId",
                table: "Treatments",
                column: "BrowseBrosweId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkinTypeTreatments");

            migrationBuilder.DropTable(
                name: "SkinTypes");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Browses");
        }
    }
}
