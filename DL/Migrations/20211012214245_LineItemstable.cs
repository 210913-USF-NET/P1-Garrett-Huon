using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class LineItemstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems");

            migrationBuilder.DropTable(
                name: "CartLineItem");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "LineItems",
                newName: "CartId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Carts_CartId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_CartId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ShopOrderId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "LineItems",
                newName: "ProductId");

            migrationBuilder.CreateTable(
                name: "CartLineItem",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "integer", nullable: false),
                    LineItemsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLineItem", x => new { x.CartsId, x.LineItemsId });
                    table.ForeignKey(
                        name: "FK_CartLineItem_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartLineItem_LineItems_LineItemsId",
                        column: x => x.LineItemsId,
                        principalTable: "LineItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProdId",
                table: "LineItems",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItem_LineItemsId",
                table: "CartLineItem",
                column: "LineItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
