using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCenterWebApp.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Agreements_AgreementId1",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Customers_CustomerId1",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Products_ProductId1",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Agreements_AgreementId1",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Customers_CustomerId1",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Products_ProductId1",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Agreements_AgreementId1",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Customers_CustomerId1",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Products_ProductId1",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Knowledges_AgreementId1",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Knowledges_CustomerId1",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Knowledges_ProductId1",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AgreementId1",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_CustomerId1",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ProductId1",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Actions_AgreementId1",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_CustomerId1",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_ProductId1",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "AgreementId1",
                table: "Knowledges");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Knowledges");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Knowledges");

            migrationBuilder.DropColumn(
                name: "AgreementId1",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "AgreementId1",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Actions");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Knowledges",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Knowledges",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Knowledges",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Actions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Actions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgreementId",
                table: "Actions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_AgreementId",
                table: "Knowledges",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_CustomerId",
                table: "Knowledges",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_ProductId",
                table: "Knowledges",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AgreementId",
                table: "Issues",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_CustomerId",
                table: "Issues",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProductId",
                table: "Issues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_AgreementId",
                table: "Actions",
                column: "AgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CustomerId",
                table: "Actions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ProductId",
                table: "Actions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Agreements_AgreementId",
                table: "Actions",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Customers_CustomerId",
                table: "Actions",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Products_ProductId",
                table: "Actions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Agreements_AgreementId",
                table: "Issues",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Customers_CustomerId",
                table: "Issues",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Products_ProductId",
                table: "Issues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Agreements_AgreementId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Customers_CustomerId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Products_ProductId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Agreements_AgreementId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Customers_CustomerId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Products_ProductId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Agreements_AgreementId",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Customers_CustomerId",
                table: "Knowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Products_ProductId",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Knowledges_AgreementId",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Knowledges_CustomerId",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Knowledges_ProductId",
                table: "Knowledges");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AgreementId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_CustomerId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ProductId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Actions_AgreementId",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_CustomerId",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_ProductId",
                table: "Actions");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Knowledges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Knowledges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AgreementId",
                table: "Knowledges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AgreementId1",
                table: "Knowledges",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Knowledges",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Knowledges",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AgreementId",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AgreementId1",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Issues",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Actions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Actions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AgreementId",
                table: "Actions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AgreementId1",
                table: "Actions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Actions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Actions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_AgreementId1",
                table: "Knowledges",
                column: "AgreementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_CustomerId1",
                table: "Knowledges",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_ProductId1",
                table: "Knowledges",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AgreementId1",
                table: "Issues",
                column: "AgreementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_CustomerId1",
                table: "Issues",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProductId1",
                table: "Issues",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_AgreementId1",
                table: "Actions",
                column: "AgreementId1");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CustomerId1",
                table: "Actions",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ProductId1",
                table: "Actions",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Agreements_AgreementId1",
                table: "Actions",
                column: "AgreementId1",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Customers_CustomerId1",
                table: "Actions",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Products_ProductId1",
                table: "Actions",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Agreements_AgreementId1",
                table: "Issues",
                column: "AgreementId1",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Customers_CustomerId1",
                table: "Issues",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Products_ProductId1",
                table: "Issues",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Agreements_AgreementId1",
                table: "Knowledges",
                column: "AgreementId1",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Customers_CustomerId1",
                table: "Knowledges",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_Products_ProductId1",
                table: "Knowledges",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
