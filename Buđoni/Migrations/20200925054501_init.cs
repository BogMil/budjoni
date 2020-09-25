using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Budjoni.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modeli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivModela = table.Column<string>(nullable: true),
                    Sifra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeli", x => x.Id);
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
                    KucniBroj = table.Column<string>(nullable: true),
                    UlazIliStan = table.Column<string>(nullable: true),
                    AdresaZaPrikaz = table.Column<string>(nullable: true),
                    KontaktTelefon = table.Column<string>(nullable: true),
                    TimestampKreiranja = table.Column<DateTime>(nullable: false),
                    DatumSlanja = table.Column<DateTime>(nullable: false),
                    Otkup = table.Column<int>(nullable: false),
                    IdVrsteRobe = table.Column<int>(nullable: false),
                    ShipmentCategory = table.Column<int>(nullable: false),
                    IdNalogaSaKogSeSalje = table.Column<int>(nullable: false),
                    NalogSaKogSeSalje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naruzbine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BojaModela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivModela = table.Column<string>(nullable: true),
                    Sifra = table.Column<string>(nullable: true),
                    SlikaByteArray = table.Column<byte[]>(nullable: true),
                    IdModela = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BojaModela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BojaModela_Modeli_IdModela",
                        column: x => x.IdModela,
                        principalTable: "Modeli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_VelicinaModela_BojaModela_IdModelaObuce",
                        column: x => x.IdModelaObuce,
                        principalTable: "BojaModela",
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
                    IdNarudzbine = table.Column<int>(nullable: false),
                    IdVelicineModela = table.Column<int>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_DetaljiNarudzbine_VelicinaModela_IdVelicineModela",
                        column: x => x.IdVelicineModela,
                        principalTable: "VelicinaModela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BojaModela_IdModela",
                table: "BojaModela",
                column: "IdModela");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiNarudzbine_IdNarudzbine",
                table: "DetaljiNarudzbine",
                column: "IdNarudzbine");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiNarudzbine_IdVelicineModela",
                table: "DetaljiNarudzbine",
                column: "IdVelicineModela");

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
                name: "Naruzbine");

            migrationBuilder.DropTable(
                name: "VelicinaModela");

            migrationBuilder.DropTable(
                name: "BojaModela");

            migrationBuilder.DropTable(
                name: "Modeli");
        }
    }
}
