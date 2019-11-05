using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCenterWebApp.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_ProductModel_ProductId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_ProductModel_ProductId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_ProductModel_ProductId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_ProductModel_ProductId",
                table: "Knowledges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Products_ProductId",
                table: "Actions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductId",
                table: "Files",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Products_ProductId",
                table: "Issues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Products_ProductId",
                table: "Knowledges",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Products_ProductId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Products_ProductId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Products_ProductId",
                table: "Knowledges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_ProductModel_ProductId",
                table: "Actions",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_ProductModel_ProductId",
                table: "Files",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_ProductModel_ProductId",
                table: "Issues",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_ProductModel_ProductId",
                table: "Knowledges",
                column: "ProductId",
                principalTable: "ProductModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
