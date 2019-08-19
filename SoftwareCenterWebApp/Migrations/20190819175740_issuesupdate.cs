using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCenterWebApp.Migrations
{
    public partial class issuesupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsible",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Severity",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Issues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Responsible",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Issues");
        }
    }
}
