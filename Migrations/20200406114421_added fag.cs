using Microsoft.EntityFrameworkCore.Migrations;

namespace Hovedliste.Migrations
{
    public partial class addedfag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fag",
                table: "Sager",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fag",
                table: "Sager");
        }
    }
}
