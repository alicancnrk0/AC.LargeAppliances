using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.LargeAppliances.Migrations
{
    /// <inheritdoc />
    public partial class x6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconClass",
                table: "CardItems",
                newName: "IconImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconImagePath",
                table: "CardItems",
                newName: "IconClass");
        }
    }
}
