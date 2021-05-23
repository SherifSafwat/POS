using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BayMarch.Migrations
{
    public partial class tables7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "InvoiceHead",
                columns: table => new
                {
                    InvoiceHeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNum = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: true),
                    OrderHeadId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    InvoiceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    TotalTax = table.Column<float>(type: "real", nullable: false),
                    TotalDisc = table.Column<float>(type: "real", nullable: false),
                    EName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SellerId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    GrantBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrantFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrantToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrantComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHead", x => x.InvoiceHeadId);
                    table.ForeignKey(
                        name: "FK_InvoiceHead_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTail",
                columns: table => new
                {
                    InvoiceTailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false),
                    LineNum = table.Column<int>(type: "int", nullable: false),
                    ItemNum = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Qty = table.Column<float>(type: "real", nullable: false),
                    LineTax = table.Column<float>(type: "real", nullable: false),
                    LineDisc = table.Column<float>(type: "real", nullable: false),
                    TotalLine = table.Column<float>(type: "real", nullable: false),
                    EName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoName5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoValue5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SellerId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    GrantBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrantFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrantToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrantComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTail", x => x.InvoiceTailId);
                    table.ForeignKey(
                        name: "FK_InvoiceTail_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHead_SellerId",
                table: "InvoiceHead",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTail_SellerId",
                table: "InvoiceTail",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceHead");

            migrationBuilder.DropTable(
                name: "InvoiceTail");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");
        }
    }
}
