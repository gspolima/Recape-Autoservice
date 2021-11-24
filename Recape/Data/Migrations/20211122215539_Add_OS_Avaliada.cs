using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recape.Data.Migrations
{
    public partial class Add_OS_Avaliada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Avaliado",
                table: "OrdensDeServico",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliado",
                table: "OrdensDeServico");
        }
    }
}
