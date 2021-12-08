using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recape.Data.Migrations
{
    public partial class Tornar_Proprietario_Obrigatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_AspNetUsers_ProprietarioId",
                table: "Veiculos");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_AspNetUsers_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_AspNetUsers_ProprietarioId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_AspNetUsers_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
