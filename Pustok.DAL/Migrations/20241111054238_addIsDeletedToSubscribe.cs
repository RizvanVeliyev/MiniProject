using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addIsDeletedToSubscribe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Subscribes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Subscribes");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Tags",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
