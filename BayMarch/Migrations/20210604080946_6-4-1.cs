using Microsoft.EntityFrameworkCore.Migrations;

namespace BayMarch.Migrations
{
    public partial class _641 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Seller_SellerObjSellerId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_SellerObjSellerId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "MainSellerId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "SellerObjSellerId",
                table: "Seller");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MainSellerId",
                table: "Seller",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SellerObjSellerId",
                table: "Seller",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_SellerObjSellerId",
                table: "Seller",
                column: "SellerObjSellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Seller_SellerObjSellerId",
                table: "Seller",
                column: "SellerObjSellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
