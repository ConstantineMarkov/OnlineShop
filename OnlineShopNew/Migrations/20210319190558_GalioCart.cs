using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class GalioCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_FK_Product_Id",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_FK_Product_Id",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "FK_Product_Id",
                table: "Cart",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProductId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart",
                newName: "FK_Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_FK_Product_Id",
                table: "Cart",
                column: "FK_Product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_FK_Product_Id",
                table: "Cart",
                column: "FK_Product_Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
