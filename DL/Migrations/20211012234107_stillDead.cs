using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class stillDead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineItemId",
                table: "ShopOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "LineItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "LineItems");

            migrationBuilder.AddColumn<int>(
                name: "LineItemId",
                table: "ShopOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
