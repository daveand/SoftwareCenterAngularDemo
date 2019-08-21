using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareCenterWebApp.Migrations
{
    public partial class addmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Severity",
                table: "Issues",
                newName: "Remedy");

            migrationBuilder.RenameColumn(
                name: "Customer",
                table: "Issues",
                newName: "ProductId");

            migrationBuilder.AddColumn<string>(
                name: "AgreementId",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgreementId1",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CloseDate",
                table: "Issues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Issues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Issues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Issues",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgreementModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Actions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreementModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true),
                    Agreements = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectNumber = table.Column<string>(nullable: true),
                    RespTech = table.Column<string>(nullable: true),
                    ProjectLeader = table.Column<string>(nullable: true),
                    SalesRep = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Files = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ClosedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerContacts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Responsible = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    AgreementId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DoneDate = table.Column<DateTime>(nullable: false),
                    Priority = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CustomerId1 = table.Column<int>(nullable: true),
                    AgreementId1 = table.Column<int>(nullable: true),
                    ProductId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_AgreementModel_AgreementId1",
                        column: x => x.AgreementId1,
                        principalTable: "AgreementModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actions_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actions_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    AgreementId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CustomerId1 = table.Column<int>(nullable: true),
                    AgreementId1 = table.Column<int>(nullable: true),
                    ProductId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knowledges_AgreementModel_AgreementId1",
                        column: x => x.AgreementId1,
                        principalTable: "AgreementModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Knowledges_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Knowledges_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContacts_CustomerId",
                table: "CustomerContacts",
                column: "CustomerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AgreementModel_AgreementId1",
                table: "Issues",
                column: "AgreementId1",
                principalTable: "AgreementModel",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AgreementModel_AgreementId1",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Customers_CustomerId1",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Products_ProductId1",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "CustomerContacts");

            migrationBuilder.DropTable(
                name: "Knowledges");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AgreementModel");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AgreementId1",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_CustomerId1",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ProductId1",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "AgreementId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "AgreementId1",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CloseDate",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "Remedy",
                table: "Issues",
                newName: "Severity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Issues",
                newName: "Customer");
        }
    }
}
