using Microsoft.EntityFrameworkCore.Migrations;

namespace PojistneUdalosti.DataAccess.Migrations
{
    public partial class zmenaAdresyPojistnika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cislo",
                table: "Pojistnik");

            migrationBuilder.DropColumn(
                name: "Mesto",
                table: "Pojistnik");

            migrationBuilder.DropColumn(
                name: "SmerovaciCislo",
                table: "Pojistnik");

            migrationBuilder.DropColumn(
                name: "Ulice",
                table: "Pojistnik");

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Pojistnik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Pojistnik");

            migrationBuilder.AddColumn<int>(
                name: "Cislo",
                table: "Pojistnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Mesto",
                table: "Pojistnik",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SmerovaciCislo",
                table: "Pojistnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ulice",
                table: "Pojistnik",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
