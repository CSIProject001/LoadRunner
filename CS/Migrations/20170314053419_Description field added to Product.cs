using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.Migrations
{
    public partial class DescriptionfieldaddedtoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Order",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "QuantityPerUnit",
                table: "Product",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Product",
                maxLength: 500,
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Order",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "QuantityPerUnit",
                table: "Product",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Product",
                nullable: true);
        }
    }
}
