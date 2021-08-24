using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BayMarch.Migrations
{
    public partial class _8231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Type_Seller_SellerId",
                table: "Type");

            /*migrationBuilder.DropIndex(
                name: "IX_Type_SellerId",
                table: "Type");*/

            migrationBuilder.AlterColumn<long>(
                name: "TypeId",
                table: "Seller",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentCategoryId",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "ParentCategory",
                columns: table => new
                {
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_ParentCategory", x => x.ParentCategoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentCategory");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "TypeId",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            /*migrationBuilder.CreateIndex(
                name: "IX_Type_SellerId",
                table: "Type",
                column: "SellerId",
                unique: true);*/

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Seller_SellerId",
                table: "Type",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
