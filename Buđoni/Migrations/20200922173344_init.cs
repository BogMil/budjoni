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

            migrationBuilder.CreateIndex(
                name: "IX_VelicinaModela_IdModelaObuce",
                table: "VelicinaModela",
                column: "IdModelaObuce");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VelicinaModela");

            migrationBuilder.DropTable(
                name: "ModeliObuce");
        }
    }
}
