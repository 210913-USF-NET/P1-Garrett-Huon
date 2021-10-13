using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class LineItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Carts_CartId",
                table: "LineItems");

            migrationBuilder.DropTable(
                name: "LineItemProduct");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "LineItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_CartId",
                table: "LineItems",
                newName: "IX_LineItems_ProductId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems",
                newName: "IX_LineItems_CartId");

            migrationBuilder.CreateTable(
                name: "LineItemProduct",
                columns: table => new
                {
                    LineItemsId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItemProduct", x => new { x.LineItemsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_LineItemProduct_LineItems_LineItemsId",
                        column: x => x.LineItemsId,
                        principalTable: "LineItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItemProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItemProduct_ProductsId",
                table: "LineItemProduct",
                column: "ProductsId");

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
