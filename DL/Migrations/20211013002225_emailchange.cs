using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class emailchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ShopOrders");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "ShopOrders",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "ShopOrders");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ShopOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
