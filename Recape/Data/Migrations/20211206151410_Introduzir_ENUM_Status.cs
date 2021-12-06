using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recape.Data.Migrations
{
    public partial class Introduzir_ENUM_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliado",
                table: "OrdensDeServico");

            migrationBuilder.DropColumn(
                name: "Cancelado",
                table: "OrdensDeServico");

            migrationBuilder.DropColumn(
                name: "Finalizado",
                table: "OrdensDeServico");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "OrdensDeServico",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrdensDeServico");

            migrationBuilder.AddColumn<bool>(
                name: "Avaliado",
                table: "OrdensDeServico",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelado",
                table: "OrdensDeServico",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Finalizado",
                table: "OrdensDeServico",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
