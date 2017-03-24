using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.Migrations
{
    public partial class RemovedSessionsfromShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "ShoppingCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "ShoppingCart",
                maxLength: 50,
                nullable: true);
        }
    }
}
