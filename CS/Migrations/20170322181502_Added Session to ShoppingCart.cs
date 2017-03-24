using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.Migrations
{
    public partial class AddedSessiontoShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Order",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CartItem",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "ShoppingCart",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CartItem",
                newName: "ID");
        }
    }
}
