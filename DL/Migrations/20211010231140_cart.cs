using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DL.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "LineItems",
                newName: "ShopOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems",
                newName: "IX_LineItems_ShopOrderId");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quant = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<int>(type: "integer", nullable: false),
                    UnitTotal = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

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
                name: "IX_Products_CartId",
                table: "Products",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_CartId",
                table: "LineItems",
                column: "CartId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_ShopOrders_ShopOrderId",
                table: "LineItems",
                column: "ShopOrderId",
                principalTable: "ShopOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products",
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

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_ShopOrders_ShopOrderId",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "LineItemProduct");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_CartId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "ShopOrderId",
                table: "LineItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ShopOrderId",
                table: "LineItems",
                newName: "IX_LineItems_ProductId");

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
