using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BayMarch.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceID",
                table: "Product",
                newName: "SourceId");

            migrationBuilder.RenameColumn(
                name: "Info5",
                table: "Product",
                newName: "InfoValue5");

            migrationBuilder.RenameColumn(
                name: "Info4",
                table: "Product",
                newName: "InfoValue4");

            migrationBuilder.RenameColumn(
                name: "Info3",
                table: "Product",
                newName: "InfoValue3");

            migrationBuilder.RenameColumn(
                name: "Info2",
                table: "Product",
                newName: "InfoValue2");

            migrationBuilder.RenameColumn(
                name: "Info1",
                table: "Product",
                newName: "InfoValue1");

            migrationBuilder.RenameColumn(
                name: "UpdatedId",
                table: "Price",
                newName: "UpdatedID");

            migrationBuilder.RenameColumn(
                name: "CreatedId",
                table: "Price",
                newName: "CreatedID");

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName1",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName2",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName3",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName4",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName5",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue1",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue2",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue3",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue4",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue5",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person1",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person2",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person3",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person4",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person5",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SourceId",
                table: "Seller",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "BranchId",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment1",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment2",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment3",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment4",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment5",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName1",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName2",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName3",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName4",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName5",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SellerId",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "AName",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EName",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName1",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName2",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName3",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName4",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoName5",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue1",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue2",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue3",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue4",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoValue5",
                table: "Price",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierNum = table.Column<long>(type: "bigint", nullable: false),
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
                    Person5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Supplier_Seller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellerId",
                table: "Product",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SellerId",
                table: "Supplier",
                column: "SellerId");

            /*migrationBuilder.AddForeignKey(
                name: "FK_Product_Seller_SellerId",
                table: "Product",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Seller_SellerId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Product_SellerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoName1",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoName2",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoName3",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoName4",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoName5",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoValue1",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoValue2",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoValue3",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoValue4",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "InfoValue5",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Person1",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Person2",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Person3",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Person4",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Person5",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Comment1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Comment2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Comment3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Comment4",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Comment5",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InfoName1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InfoName2",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InfoName3",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InfoName4",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InfoName5",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AName",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "EName",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoName1",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoName2",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoName3",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoName4",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoName5",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoValue1",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoValue2",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoValue3",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoValue4",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "InfoValue5",
                table: "Price");

            migrationBuilder.RenameColumn(
                name: "SourceId",
                table: "Product",
                newName: "SourceID");

            migrationBuilder.RenameColumn(
                name: "InfoValue5",
                table: "Product",
                newName: "Info5");

            migrationBuilder.RenameColumn(
                name: "InfoValue4",
                table: "Product",
                newName: "Info4");

            migrationBuilder.RenameColumn(
                name: "InfoValue3",
                table: "Product",
                newName: "Info3");

            migrationBuilder.RenameColumn(
                name: "InfoValue2",
                table: "Product",
                newName: "Info2");

            migrationBuilder.RenameColumn(
                name: "InfoValue1",
                table: "Product",
                newName: "Info1");

            migrationBuilder.RenameColumn(
                name: "UpdatedID",
                table: "Price",
                newName: "UpdatedId");

            migrationBuilder.RenameColumn(
                name: "CreatedID",
                table: "Price",
                newName: "CreatedId");
        }
    }
}
