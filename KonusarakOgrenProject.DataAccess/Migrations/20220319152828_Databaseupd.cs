using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KonusarakOgrenProject.DataAccess.Migrations
{
    public partial class Databaseupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrueOption",
                table: "Questions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrueOption",
                table: "Questions");
        }
    }
}
