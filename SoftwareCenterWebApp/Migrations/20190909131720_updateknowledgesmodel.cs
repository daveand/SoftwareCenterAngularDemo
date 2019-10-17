using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCenterWebApp.Migrations
{
    public partial class updateknowledgesmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Agreements_AgreementId",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Customers_CustomerId",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Products_ProductId",
                table: "Knowledges");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Knowledges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Knowledges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Knowledges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Knowledges",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remedy",
                table: "Knowledges",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Knowledges",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_UserId",
                table: "Knowledges",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Agreements_AgreementId",
                table: "Knowledges",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Customers_CustomerId",
                table: "Knowledges",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Products_ProductId",
                table: "Knowledges",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Users_UserId",
                table: "Knowledges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Agreements_AgreementId",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Customers_CustomerId",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Products_ProductId",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Users_UserId",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Knowledges_UserId",
                table: "Knowledges");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Knowledges");

            migrationBuilder.DropColumn(
                name: "Remedy",
                table: "Knowledges");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Knowledges");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Knowledges",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Knowledges",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Knowledges",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Agreements_AgreementId",
                table: "Knowledges",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Customers_CustomerId",
                table: "Knowledges",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Products_ProductId",
                table: "Knowledges",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
