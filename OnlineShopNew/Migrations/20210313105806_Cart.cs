using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

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
    }
}
