using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.Migrations
{
    public partial class ConnectUsertoShoppingCartforSaveCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCart");
        }
    }
}
