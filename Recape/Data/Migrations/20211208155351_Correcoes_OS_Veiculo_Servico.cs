using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recape.Data.Migrations
{
    public partial class Correcoes_OS_Veiculo_Servico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_AspNetUsers_ProprietarioId",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.AlterColumn<string>(
                name: "ProprietarioId",
                table: "Veiculos",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoDeExecucao",
                table: "Servicos",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "VeiculoId",
                table: "OrdensDeServico",
                type: "varchar(7)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                column: "Placa");

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

            migrationBuilder.CreateIndex(
                name: "IX_OrdensDeServico_VeiculoId",
                table: "OrdensDeServico",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdensDeServico_Veiculos_VeiculoId",
                table: "OrdensDeServico",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Placa");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_AspNetUsers_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdensDeServico_Veiculos_VeiculoId",
                table: "OrdensDeServico");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_AspNetUsers_ProprietarioId",
                table: "Veiculos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_OrdensDeServico_VeiculoId",
                table: "OrdensDeServico");

            migrationBuilder.DropColumn(
                name: "TempoDeExecucao",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "OrdensDeServico");

            migrationBuilder.UpdateData(
                table: "Veiculos",
                keyColumn: "ProprietarioId",
                keyValue: null,
                column: "ProprietarioId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProprietarioId",
                table: "Veiculos",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculos",
                table: "Veiculos",
                columns: new[] { "Placa", "ProprietarioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_AspNetUsers_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
