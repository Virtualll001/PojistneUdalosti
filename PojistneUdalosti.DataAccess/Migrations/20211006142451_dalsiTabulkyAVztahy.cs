using Microsoft.EntityFrameworkCore.Migrations;

namespace PojistneUdalosti.DataAccess.Migrations
{
    public partial class dalsiTabulkyAVztahy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pojistnik_Udalost_UdalostId",
                table: "Pojistnik");

            migrationBuilder.DropIndex(
                name: "IX_Pojistnik_UdalostId",
                table: "Pojistnik");

            migrationBuilder.DropColumn(
                name: "PojistnikId",
                table: "Udalost");

            migrationBuilder.DropColumn(
                name: "UdalostId",
                table: "Pojistnik");

            migrationBuilder.AlterColumn<string>(
                name: "Popis",
                table: "Udalost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Udalost_PojisteniId",
                table: "Udalost",
                column: "PojisteniId");

            migrationBuilder.AddForeignKey(
                name: "FK_Udalost_Pojisteni_PojisteniId",
                table: "Udalost",
                column: "PojisteniId",
                principalTable: "Pojisteni",
                principalColumn: "PojisteniId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Udalost_Pojisteni_PojisteniId",
                table: "Udalost");

            migrationBuilder.DropIndex(
                name: "IX_Udalost_PojisteniId",
                table: "Udalost");

            migrationBuilder.AlterColumn<string>(
                name: "Popis",
                table: "Udalost",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PojistnikId",
                table: "Udalost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UdalostId",
                table: "Pojistnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pojistnik_UdalostId",
                table: "Pojistnik",
                column: "UdalostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pojistnik_Udalost_UdalostId",
                table: "Pojistnik",
                column: "UdalostId",
                principalTable: "Udalost",
                principalColumn: "UdalostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
