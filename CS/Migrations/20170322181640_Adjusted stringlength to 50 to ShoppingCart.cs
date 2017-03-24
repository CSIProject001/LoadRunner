using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.Migrations
{
    public partial class Adjustedstringlengthto50toShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "ShoppingCart",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "ShoppingCart",
                nullable: true);
        }
    }
}
