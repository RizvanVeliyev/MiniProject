using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsdeletedforProductImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ProductImages");
        }
    }
}
