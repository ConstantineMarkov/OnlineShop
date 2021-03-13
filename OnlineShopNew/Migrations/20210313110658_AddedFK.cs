using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class AddedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "ProductId");
        }
    }
}
