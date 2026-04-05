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
            migrationBuilder.DropColumn(
                name: "HeroLeftImageUrl",
                table: "ProductPages");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "ProductFeatures",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "ProductFeatures");

            migrationBuilder.AddColumn<string>(
                name: "HeroLeftImageUrl",
                table: "ProductPages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
