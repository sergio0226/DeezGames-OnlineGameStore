using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab4t1.Data.Migrations
{
    public partial class PerfilUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Perfils",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Perfils");
        }
    }
}
