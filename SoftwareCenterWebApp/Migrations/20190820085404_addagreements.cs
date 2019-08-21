using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCenterWebApp.Migrations
{
    public partial class addagreements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_AgreementModel_AgreementId1",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AgreementModel_AgreementId1",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_AgreementModel_AgreementId1",
                table: "Knowledges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgreementModel",
                table: "AgreementModel");

            migrationBuilder.RenameTable(
                name: "AgreementModel",
                newName: "Agreements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agreements",
                table: "Agreements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_Agreements_AgreementId1",
                table: "Actions",
                column: "AgreementId1",
                principalTable: "Agreements",
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
                name: "FK_Knowledges_Agreements_AgreementId1",
                table: "Knowledges",
                column: "AgreementId1",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Agreements_AgreementId1",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Agreements_AgreementId1",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Knowledges_Agreements_AgreementId1",
                table: "Knowledges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agreements",
                table: "Agreements");

            migrationBuilder.RenameTable(
                name: "Agreements",
                newName: "AgreementModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgreementModel",
                table: "AgreementModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_AgreementModel_AgreementId1",
                table: "Actions",
                column: "AgreementId1",
                principalTable: "AgreementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AgreementModel_AgreementId1",
                table: "Issues",
                column: "AgreementId1",
                principalTable: "AgreementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knowledges_AgreementModel_AgreementId1",
                table: "Knowledges",
                column: "AgreementId1",
                principalTable: "AgreementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
