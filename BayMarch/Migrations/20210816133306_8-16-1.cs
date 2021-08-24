using Microsoft.EntityFrameworkCore.Migrations;

namespace BayMarch.Migrations
{
    public partial class _8161 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email1",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email2",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email3",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email4",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email5",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegisterNumber",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ParentCategoryId",
                table: "Category",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Type_Seller_SellerId",
                table: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Type_SellerId",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "Email1",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Email2",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Email3",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Email4",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Email5",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "RegisterNumber",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Category");
        }
    }
}
