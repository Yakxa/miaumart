using Microsoft.EntityFrameworkCore.Migrations;

namespace MiauMart.Dal.Migrations
{
    public partial class UpdateValorUnitarioColumnTypeFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ValorUnitarioVenda",
                table: "Vendas",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValorUnitarioVenda",
                table: "Vendas",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
