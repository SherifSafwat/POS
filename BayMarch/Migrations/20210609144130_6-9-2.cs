using Microsoft.EntityFrameworkCore.Migrations;

namespace BayMarch.Migrations
{
    public partial class _692 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address3",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address4",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address5",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact1",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact2",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact3",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact4",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact5",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person1",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person2",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person3",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person4",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Person5",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Address3",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Address4",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Address5",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Contact1",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Contact2",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Contact3",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Contact4",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Contact5",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Person1",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Person2",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Person3",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Person4",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "Person5",
                table: "WareHouse");
        }
    }
}
