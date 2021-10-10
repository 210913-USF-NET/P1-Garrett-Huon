using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class updatetotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "LineItems");
        }
    }
}
