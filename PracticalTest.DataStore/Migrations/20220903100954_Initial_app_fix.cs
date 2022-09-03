using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticalTest.DataStore.Migrations
{
    public partial class Initial_app_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientUniqueId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Surname = table.Column<string>(maxLength: 200, nullable: false),
                    TelephoneNr = table.Column<string>(fixedLength: true, maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientUniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    LoanPeriod = table.Column<int>(maxLength: 24, nullable: false),
                    PayoutDate = table.Column<DateTime>(nullable: false),
                    ClientID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Loans_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientUniqueId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNr = table.Column<string>(nullable: true),
                    OrderNr = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    LoanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Loans_LoanID",
                        column: x => x.LoanID,
                        principalTable: "Loans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_LoanID",
                table: "Invoices",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_ClientID",
                table: "Loans",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
