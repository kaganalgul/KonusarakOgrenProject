using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KonusarakOgrenProject.DataAccess.Migrations
{
    public partial class DatabaseChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paragraph",
                table: "Exams");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Paragraph",
                table: "Exams",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
