using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recape.Data.Migrations
{
    public partial class Configurar_Conversao_TimeSpan_para_Ticks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TempoDeExecucao",
                table: "Servicos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 1,
                column: "TempoDeExecucao",
                value: 72000000000L);

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 2,
                column: "TempoDeExecucao",
                value: 288000000000L);

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 3,
                column: "TempoDeExecucao",
                value: 2160000000000L);

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 4,
                column: "TempoDeExecucao",
                value: 2592000000000L);

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 5,
                column: "TempoDeExecucao",
                value: 4320000000000L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TempoDeExecucao",
                table: "Servicos",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 1,
                column: "TempoDeExecucao",
                value: new TimeSpan(0, 2, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 2,
                column: "TempoDeExecucao",
                value: new TimeSpan(0, 8, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 3,
                column: "TempoDeExecucao",
                value: new TimeSpan(2, 12, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 4,
                column: "TempoDeExecucao",
                value: new TimeSpan(3, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Servicos",
                keyColumn: "Id",
                keyValue: 5,
                column: "TempoDeExecucao",
                value: new TimeSpan(5, 0, 0, 0, 0));
        }
    }
}
