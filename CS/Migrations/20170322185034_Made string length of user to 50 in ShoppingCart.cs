using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.Migrations
{
    public partial class Madestringlengthofuserto50inShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                nullable: true);
        }
    }
}
