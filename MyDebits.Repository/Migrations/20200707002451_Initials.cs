using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDebits.Repository.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Debits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    DateDebit = table.Column<DateTime>(nullable: false),
                    DebitValue = table.Column<decimal>(nullable: false),
                    Quota = table.Column<int>(nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debits_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Debits_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Gastos Fixos" });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Dinheiro" });

            migrationBuilder.InsertData(
                table: "Debits",
                columns: new[] { "Id", "CategoryId", "DateDebit", "DebitValue", "Description", "PaymentMethodId", "Quota" },
                values: new object[] { 1, 1, new DateTime(2020, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3528m, "Conta de água", 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Debits_CategoryId",
                table: "Debits",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Debits_PaymentMethodId",
                table: "Debits",
                column: "PaymentMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debits");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
