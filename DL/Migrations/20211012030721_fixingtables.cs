using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class fixingtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Carts",
                newName: "ProdId");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitTotal",
                table: "Carts",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Carts",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdId",
                table: "Carts",
                newName: "Total");

            migrationBuilder.AlterColumn<int>(
                name: "UnitTotal",
                table: "Carts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "UnitPrice",
                table: "Carts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
