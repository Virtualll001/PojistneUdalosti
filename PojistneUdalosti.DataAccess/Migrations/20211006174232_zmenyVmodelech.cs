using Microsoft.EntityFrameworkCore.Migrations;

namespace PojistneUdalosti.DataAccess.Migrations
{
    public partial class zmenyVmodelech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Udalost_Pojisteni_PojisteniId",
                table: "Udalost");

            migrationBuilder.RenameColumn(
                name: "PojisteniId",
                table: "Udalost",
                newName: "PojistnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Udalost_PojisteniId",
                table: "Udalost",
                newName: "IX_Udalost_PojistnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Udalost_Pojistnik_PojistnikId",
                table: "Udalost",
                column: "PojistnikId",
                principalTable: "Pojistnik",
                principalColumn: "PojistnikId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Udalost_Pojistnik_PojistnikId",
                table: "Udalost");

            migrationBuilder.RenameColumn(
                name: "PojistnikId",
                table: "Udalost",
                newName: "PojisteniId");

            migrationBuilder.RenameIndex(
                name: "IX_Udalost_PojistnikId",
                table: "Udalost",
                newName: "IX_Udalost_PojisteniId");

            migrationBuilder.AddForeignKey(
                name: "FK_Udalost_Pojisteni_PojisteniId",
                table: "Udalost",
                column: "PojisteniId",
                principalTable: "Pojisteni",
                principalColumn: "PojisteniId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
