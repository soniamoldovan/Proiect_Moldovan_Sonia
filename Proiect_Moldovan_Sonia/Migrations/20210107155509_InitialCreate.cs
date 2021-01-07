using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Moldovan_Sonia.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Era",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EraName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Era", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Museum",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MuseumName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(2, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museum", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Painting",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    MuseumID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Painting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Painting_Museum_MuseumID",
                        column: x => x.MuseumID,
                        principalTable: "Museum",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaintingEra",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaintingID = table.Column<int>(nullable: false),
                    EraID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintingEra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaintingEra_Era_EraID",
                        column: x => x.EraID,
                        principalTable: "Era",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaintingEra_Painting_PaintingID",
                        column: x => x.PaintingID,
                        principalTable: "Painting",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Painting_MuseumID",
                table: "Painting",
                column: "MuseumID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingEra_EraID",
                table: "PaintingEra",
                column: "EraID");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingEra_PaintingID",
                table: "PaintingEra",
                column: "PaintingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaintingEra");

            migrationBuilder.DropTable(
                name: "Era");

            migrationBuilder.DropTable(
                name: "Painting");

            migrationBuilder.DropTable(
                name: "Museum");
        }
    }
}
