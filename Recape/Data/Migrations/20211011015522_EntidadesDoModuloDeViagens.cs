using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recape.Data.Migrations
{
    public partial class EntidadesDoModuloDeViagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    DataPartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracaoEmHoras = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poltronas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<byte>(type: "tinyint", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    ViagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poltronas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poltronas_Viagens_ViagemId",
                        column: x => x.ViagemId,
                        principalTable: "Viagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoltronaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Poltronas_PoltronaId",
                        column: x => x.PoltronaId,
                        principalTable: "Poltronas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poltronas_ViagemId",
                table: "Poltronas",
                column: "ViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PoltronaId",
                table: "Reservas",
                column: "PoltronaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Poltronas");

            migrationBuilder.DropTable(
                name: "Viagens");
        }
    }
}
