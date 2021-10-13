using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class Dying : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Carts_CartId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_CartId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "LineItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_CartId",
                table: "LineItems",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Carts_CartId",
                table: "LineItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
