using Microsoft.EntityFrameworkCore.Migrations;

namespace PojistneUdalosti.DataAccess.Migrations
{
    public partial class addPojistnikUdalostToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Udalost",
                columns: table => new
                {
                    UdalostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Potvrzeno = table.Column<bool>(type: "bit", nullable: false),
                    PojistnikId = table.Column<int>(type: "int", nullable: false),
                    PojisteniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Udalost", x => x.UdalostId);
                });

            migrationBuilder.CreateTable(
                name: "Pojistnik",
                columns: table => new
                {
                    PojistnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ulice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cislo = table.Column<int>(type: "int", nullable: false),
                    Mesto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SmerovaciCislo = table.Column<int>(type: "int", nullable: false),
                    TelefonCislo = table.Column<int>(type: "int", nullable: false),
                    PojisteniId = table.Column<int>(type: "int", nullable: false),
                    UdalostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojistnik", x => x.PojistnikId);
                    table.ForeignKey(
                        name: "FK_Pojistnik_Pojisteni_PojisteniId",
                        column: x => x.PojisteniId,
                        principalTable: "Pojisteni",
                        principalColumn: "PojisteniId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pojistnik_Udalost_UdalostId",
                        column: x => x.UdalostId,
                        principalTable: "Udalost",
                        principalColumn: "UdalostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pojistnik_PojisteniId",
                table: "Pojistnik",
                column: "PojisteniId");

            migrationBuilder.CreateIndex(
                name: "IX_Pojistnik_UdalostId",
                table: "Pojistnik",
                column: "UdalostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pojistnik");

            migrationBuilder.DropTable(
                name: "Udalost");
        }
    }
}
