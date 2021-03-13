using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class AddedCartToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "OnlineShopUserId",
                table: "Products",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OnlineShopUserId",
                table: "Products",
                column: "OnlineShopUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_OnlineShopUserId",
                table: "Products",
                column: "OnlineShopUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_OnlineShopUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OnlineShopUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OnlineShopUserId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
