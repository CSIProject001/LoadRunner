using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CS.Migrations
{
    public partial class AddedCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Product_ItemID",
                table: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCart_ItemID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "Coupon",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ShoppingCart");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<int>(nullable: false),
                    Coupon = table.Column<string>(nullable: true),
                    DiscountPrice = table.Column<decimal>(nullable: false),
                    ItemID = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    ShoppingCartID = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_ShoppingCart_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "ShoppingCart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ItemID",
                table: "CartItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingCartID",
                table: "CartItem",
                column: "ShoppingCartID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.AddColumn<string>(
                name: "Coupon",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ItemID",
                table: "ShoppingCart",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Product_ItemID",
                table: "ShoppingCart",
                column: "ItemID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
