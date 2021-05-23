using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BayMarch.Migrations
{
    public partial class _5182 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceTail");

            migrationBuilder.DropColumn(
                name: "ItemNum",
                table: "InvoiceTail");

            migrationBuilder.RenameColumn(
                name: "ItemNum",
                table: "Product",
                newName: "ProductNum");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "InvoiceTail",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "PriceListId",
                table: "InvoiceTail",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "LineNum",
                table: "InvoiceTail",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

           /* migrationBuilder.AlterColumn<long>(
                name: "InvoiceTailId",
                table: "InvoiceTail",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");*/

            migrationBuilder.AddColumn<long>(
                name: "InvoiceHeadId",
                table: "InvoiceTail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductNum",
                table: "InvoiceTail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "OrderHeadId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceNum",
                table: "InvoiceHead",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "DeviceId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            /*migrationBuilder.AlterColumn<long>(
                name: "InvoiceHeadId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");*/

            migrationBuilder.CreateTable(
                name: "OrderHead",
                columns: table => new
                {
                    OrderHeadId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNum = table.Column<long>(type: "bigint", nullable: false),
                    OrderRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceHeadId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: true),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    TotalTax = table.Column<float>(type: "real", nullable: false),
                    TotalDisc = table.Column<float>(type: "real", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_OrderHead", x => x.OrderHeadId);
                    table.ForeignKey(
                        name: "FK_OrderHead_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTail",
                columns: table => new
                {
                    OrderTailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeadId = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceTailId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    PriceListId = table.Column<long>(type: "bigint", nullable: false),
                    LineNum = table.Column<long>(type: "bigint", nullable: false),
                    ProductNum = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_OrderTail", x => x.OrderTailId);
                    table.ForeignKey(
                        name: "FK_OrderTail_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderHead_SellerId",
                table: "OrderHead",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTail_SellerId",
                table: "OrderTail",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderHead");

            migrationBuilder.DropTable(
                name: "OrderTail");

            migrationBuilder.DropColumn(
                name: "InvoiceHeadId",
                table: "InvoiceTail");

            migrationBuilder.DropColumn(
                name: "ProductNum",
                table: "InvoiceTail");

            migrationBuilder.RenameColumn(
                name: "ProductNum",
                table: "Product",
                newName: "ItemNum");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "InvoiceTail",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "PriceListId",
                table: "InvoiceTail",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "LineNum",
                table: "InvoiceTail",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceTailId",
                table: "InvoiceTail",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceTail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemNum",
                table: "InvoiceTail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "InvoiceHead",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "OrderHeadId",
                table: "InvoiceHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceNum",
                table: "InvoiceHead",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "InvoiceHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "InvoiceHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "InvoiceHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceHeadId",
                table: "InvoiceHead",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
