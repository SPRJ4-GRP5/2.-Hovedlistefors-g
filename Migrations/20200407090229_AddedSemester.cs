using Microsoft.EntityFrameworkCore.Migrations;

namespace Hovedliste.Migrations
{
    public partial class AddedSemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "Sager",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Sager");
        }
    }
}
