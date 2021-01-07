using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Moldovan_Sonia.Migrations
{
    public partial class ChangePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Painting",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "TicketPrice",
                table: "Museum",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Painting",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "TicketPrice",
                table: "Museum",
                type: "decimal(2, 2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
