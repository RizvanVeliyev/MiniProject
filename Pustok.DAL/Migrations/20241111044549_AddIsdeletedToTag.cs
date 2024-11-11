using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIsdeletedToTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tags",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tags");
        }
    }
}
