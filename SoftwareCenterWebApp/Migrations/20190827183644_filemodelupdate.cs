using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCenterWebApp.Migrations
{
    public partial class filemodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Files",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Files");
        }
    }
}
