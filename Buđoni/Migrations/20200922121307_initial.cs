using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Budjoni.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModeliObuce",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivModela = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeliObuce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BojaModela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlikaByteArray = table.Column<byte[]>(nullable: true),
                    IdModela = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BojaModela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BojaModela_ModeliObuce_IdModela",
                        column: x => x.IdModela,
                        principalTable: "ModeliObuce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrojBojeModela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Velicina = table.Column<string>(nullable: true),
                    KolicinaNaStanju = table.Column<string>(nullable: true),
                    IdBojeModela = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrojBojeModela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrojBojeModela_BojaModela_IdBojeModela",
                        column: x => x.IdBojeModela,
                        principalTable: "BojaModela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BojaModela_IdModela",
                table: "BojaModela",
                column: "IdModela");

            migrationBuilder.CreateIndex(
                name: "IX_BrojBojeModela_IdBojeModela",
                table: "BrojBojeModela",
                column: "IdBojeModela");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrojBojeModela");

            migrationBuilder.DropTable(
                name: "BojaModela");

            migrationBuilder.DropTable(
                name: "ModeliObuce");
        }
    }
}
