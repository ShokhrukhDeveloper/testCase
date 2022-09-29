using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zadaniya.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Pet1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pet1Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pet2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pet2Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pet3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pet3Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
