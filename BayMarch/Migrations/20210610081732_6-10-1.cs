using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BayMarch.Migrations
{
    public partial class _6101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Seller_SellerId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHead_Seller_SellerId",
                table: "InvoiceHead");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceTail_Seller_SellerId",
                table: "InvoiceTail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHead_Seller_SellerId",
                table: "OrderHead");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTail_Seller_SellerId",
                table: "OrderTail");

            /*migrationBuilder.DropForeignKey(
                name: "FK_Product_Seller_SellerId",
                table: "Product");*/

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Seller_SellerId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Uom_Seller_SellerId",
                table: "Uom");

            migrationBuilder.DropTable(
                name: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_Uom_SellerId",
                table: "Uom");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_SellerId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Product_SellerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_OrderTail_SellerId",
                table: "OrderTail");

            migrationBuilder.DropIndex(
                name: "IX_OrderHead_SellerId",
                table: "OrderHead");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceTail_SellerId",
                table: "InvoiceTail");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHead_SellerId",
                table: "InvoiceHead");

            migrationBuilder.DropIndex(
                name: "IX_Category_SellerId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "OrderHead");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "InvoiceHead");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "InvoiceHead");

            migrationBuilder.RenameColumn(
                name: "UomNum",
                table: "Uom",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SupplierNum",
                table: "Supplier",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProductNum",
                table: "Product",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CategoryNum",
                table: "Category",
                newName: "UserId");

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "Uom",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "Supplier",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "OrderTail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "OrderTail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "OrderHead",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "OrderHead",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "InvoiceTail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "InvoiceTail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "InvoiceHead",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PaymentId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "Category",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(type: "bigint", nullable: false),
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                    SysComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(type: "bigint", nullable: false),
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "StockTrack",
                columns: table => new
                {
                    StockTrackId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrxDate = table.Column<long>(type: "bigint", nullable: false),
                    TrxType = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WareHouseId = table.Column<long>(type: "bigint", nullable: false),
                    LastValue = table.Column<long>(type: "bigint", nullable: false),
                    TrxValue = table.Column<long>(type: "bigint", nullable: false),
                    CurrentValue = table.Column<long>(type: "bigint", nullable: false),
                    Last = table.Column<bool>(type: "bit", nullable: false),
                    Number = table.Column<long>(type: "bigint", nullable: false),
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_StockTrack", x => x.StockTrackId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "StockTrack");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Uom");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "OrderTail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderTail");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "OrderHead");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderHead");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "InvoiceTail");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InvoiceTail");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "InvoiceHead");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "InvoiceHead");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Uom",
                newName: "UomNum");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Supplier",
                newName: "SupplierNum");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Product",
                newName: "ProductNum");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Category",
                newName: "CategoryNum");

            migrationBuilder.AddColumn<long>(
                name: "ClientId",
                table: "OrderHead",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClientId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeviceId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    WareHouseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    BranchId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    GrantBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrantComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrantFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrantToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Person1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Person5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerId = table.Column<long>(type: "bigint", nullable: false),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    SysComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseNum = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.WareHouseId);
                    table.ForeignKey(
                        name: "FK_WareHouse_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uom_SellerId",
                table: "Uom",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SellerId",
                table: "Supplier",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellerId",
                table: "Product",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTail_SellerId",
                table: "OrderTail",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHead_SellerId",
                table: "OrderHead",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTail_SellerId",
                table: "InvoiceTail",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHead_SellerId",
                table: "InvoiceHead",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SellerId",
                table: "Category",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_SellerId",
                table: "WareHouse",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Seller_SellerId",
                table: "Category",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHead_Seller_SellerId",
                table: "InvoiceHead",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceTail_Seller_SellerId",
                table: "InvoiceTail",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHead_Seller_SellerId",
                table: "OrderHead",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTail_Seller_SellerId",
                table: "OrderTail",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_SellerId",
                table: "Product",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Seller_SellerId",
                table: "Supplier",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uom_Seller_SellerId",
                table: "Uom",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
