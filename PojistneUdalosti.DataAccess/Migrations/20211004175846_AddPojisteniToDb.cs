using Microsoft.EntityFrameworkCore.Migrations;

namespace PojistneUdalosti.DataAccess.Migrations
{
    public partial class AddPojisteniToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pojisteni",
                columns: table => new
                {
                    PojisteniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypPojisteni = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Podminky = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zaloha = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojisteni", x => x.PojisteniId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pojisteni");
        }
    }
}
