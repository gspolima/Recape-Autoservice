using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Recape.Data.Migrations
{
    public partial class Entidade_Horarios_Fixos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatasReservadas");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Data",
                table: "OrdensDeServico",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
                table: "OrdensDeServico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HoraDoDia = table.Column<TimeOnly>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "Id", "HoraDoDia" },
                values: new object[,]
                {
                    { 1, new TimeOnly(8, 0, 0) },
                    { 2, new TimeOnly(9, 0, 0) },
                    { 3, new TimeOnly(10, 0, 0) },
                    { 4, new TimeOnly(11, 0, 0) },
                    { 5, new TimeOnly(12, 0, 0) },
                    { 6, new TimeOnly(13, 0, 0) },
                    { 7, new TimeOnly(14, 0, 0) },
                    { 8, new TimeOnly(15, 0, 0) },
                    { 9, new TimeOnly(16, 0, 0) },
                    { 10, new TimeOnly(17, 0, 0) }
                });

            migrationBuilder.UpdateData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataPartida",
                value: new DateTime(2021, 12, 25, 16, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataPartida",
                value: new DateTime(2022, 10, 23, 6, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataPartida",
                value: new DateTime(2022, 11, 2, 22, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataPartida",
                value: new DateTime(2022, 2, 15, 19, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_OrdensDeServico_HorarioId",
                table: "OrdensDeServico",
                column: "HorarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdensDeServico_Horarios_HorarioId",
                table: "OrdensDeServico",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdensDeServico_Horarios_HorarioId",
                table: "OrdensDeServico");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_OrdensDeServico_HorarioId",
                table: "OrdensDeServico");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "OrdensDeServico");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "OrdensDeServico");

            migrationBuilder.CreateTable(
                name: "DatasReservadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrdemDeServicoId = table.Column<int>(type: "int", nullable: false),
                    DataHorario = table.Column<DateTime>(type: "datetime(1)", precision: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatasReservadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatasReservadas_OrdensDeServico_OrdemDeServicoId",
                        column: x => x.OrdemDeServicoId,
                        principalTable: "OrdensDeServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataPartida",
                value: new DateTime(2021, 10, 25, 16, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataPartida",
                value: new DateTime(2021, 10, 23, 6, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataPartida",
                value: new DateTime(2021, 11, 2, 22, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataPartida",
                value: new DateTime(2021, 11, 5, 19, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_DatasReservadas_OrdemDeServicoId",
                table: "DatasReservadas",
                column: "OrdemDeServicoId",
                unique: true);
        }
    }
}
