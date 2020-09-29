using Microsoft.EntityFrameworkCore.Migrations;

namespace Budjoni.Migrations
{
    public partial class flagsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KreiranPapiric",
                table: "Naruzbine",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KreiranaAdresnica",
                table: "Naruzbine",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KreiranPapiric",
                table: "Naruzbine");

            migrationBuilder.DropColumn(
                name: "KreiranaAdresnica",
                table: "Naruzbine");
        }
    }
}
