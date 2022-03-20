using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KonusarakOgrenProject.DataAccess.Migrations
{
    public partial class examnameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExamName",
                table: "Exams",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamName",
                table: "Exams");
        }
    }
}
