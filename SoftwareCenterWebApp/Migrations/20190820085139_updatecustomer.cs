using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCenterWebApp.Migrations
{
    public partial class updatecustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agreements",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Contacts",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agreements",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacts",
                table: "Customers",
                nullable: true);
        }
    }
}
