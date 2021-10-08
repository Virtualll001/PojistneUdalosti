using Microsoft.EntityFrameworkCore.Migrations;

namespace PojistneUdalosti.DataAccess.Migrations
{
    public partial class zmenaDatTypuUUdalost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Potvrzeno",
                table: "Udalost",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Potvrzeno",
                table: "Udalost",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
