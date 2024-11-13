using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BasketitemCountAndSomeParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BasketItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "BasketItems",
                newName: "Count");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "BasketItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_AppUserId",
                table: "BasketItems",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_AspNetUsers_AppUserId",
                table: "BasketItems",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_AspNetUsers_AppUserId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_AppUserId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BasketItems");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "BasketItems",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
