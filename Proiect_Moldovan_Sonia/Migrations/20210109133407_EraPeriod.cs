using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Moldovan_Sonia.Migrations
{
    public partial class EraPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Painting",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EraPeriod",
                table: "Era",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EraPeriod",
                table: "Era");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Painting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
