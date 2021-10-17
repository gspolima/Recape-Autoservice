using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recape.Data.Migrations
{
    public partial class SemearBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Pediatria" },
                    { 2, "Cardiologia" },
                    { 4, "Pneumologia" },
                    { 5, "Clínica Geral" },
                    { 6, "Oftalmologia" },
                    { 7, "Ortopedia" }
                });

            migrationBuilder.InsertData(
                table: "Viagens",
                columns: new[] { "Id", "DataPartida", "Destino", "DuracaoEmHoras", "Origem", "Preco" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 10, 25, 16, 20, 0, 0, DateTimeKind.Unspecified), "Recife", 28f, "Fortaleza", 120.0 },
                    { 2, new DateTime(2021, 10, 23, 6, 0, 0, 0, DateTimeKind.Unspecified), "Juazeiro do Norte", 20f, "Fortaleza", 90.0 },
                    { 3, new DateTime(2021, 11, 2, 22, 30, 0, 0, DateTimeKind.Unspecified), "Belo Horizonte", 24f, "Salvador", 100.0 },
                    { 4, new DateTime(2021, 11, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), "Brasília", 36f, "Porto Alegre", 180.0 }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "EspecialidadeId", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "Dra. Adama Cadaval" },
                    { 2, 2, "Dr. Raúl Abelho" },
                    { 4, 2, "Dr. Alberto Mourão" },
                    { 7, 2, "Dra. Adriana Rosário" },
                    { 3, 4, "Dr. Ismael Veleda" },
                    { 8, 5, "Dr. Arthur Nazário" },
                    { 5, 6, "Dr. Teófilo Saldanha" },
                    { 6, 7, "Dr. Rúben Medeiros" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Viagens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
