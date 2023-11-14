using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ShoppingCarts",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "CartDetails",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "ShoppingCarts",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
