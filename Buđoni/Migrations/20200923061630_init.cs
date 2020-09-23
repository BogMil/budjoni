using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Budjoni.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModeliObuce",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivModela = table.Column<string>(nullable: true),
                    SlikaByteArray = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeliObuce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Naruzbine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    IdMesta = table.Column<int>(nullable: false),
                    IdUlice = table.Column<int>(nullable: false),
                    Brojulice = table.Column<string>(nullable: true),
                    KontaktTelefon = table.Column<string>(nullable: true),
                    TimestampKreiranja = table.Column<DateTime>(nullable: false),
                    DatumSlanja = table.Column<DateTime>(nullable: false),
                    SlikaByteArray = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naruzbine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VelicinaModela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Velicina = table.Column<string>(nullable: true),
                    KolicinaNaStanju = table.Column<int>(nullable: false),
                    IdModelaObuce = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VelicinaModela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VelicinaModela_ModeliObuce_IdModelaObuce",
                        column: x => x.IdModelaObuce,
                        principalTable: "ModeliObuce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetaljiNarudzbine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(nullable: false),
                    IdNarudzbine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaljiNarudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetaljiNarudzbine_Naruzbine_IdNarudzbine",
                        column: x => x.IdNarudzbine,
                        principalTable: "Naruzbine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiNarudzbine_IdNarudzbine",
                table: "DetaljiNarudzbine",
                column: "IdNarudzbine");

            migrationBuilder.CreateIndex(
                name: "IX_VelicinaModela_IdModelaObuce",
                table: "VelicinaModela",
                column: "IdModelaObuce");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaljiNarudzbine");

            migrationBuilder.DropTable(
                name: "VelicinaModela");

            migrationBuilder.DropTable(
                name: "Naruzbine");

            migrationBuilder.DropTable(
                name: "ModeliObuce");
        }
    }
}
