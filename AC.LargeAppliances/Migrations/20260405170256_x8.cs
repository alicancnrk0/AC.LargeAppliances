using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.LargeAppliances.Migrations
{
    /// <inheritdoc />
    public partial class x8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductHurry",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductSubTitle",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductTitle",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShockingDateTime",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShockingDescription",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShockingIconClass",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShockingRightIconClass",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShockingRightSubTitle",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShockingRightTitle",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShockingTitle",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductHurry",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ProductSubTitle",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ProductTitle",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ShockingDateTime",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ShockingDescription",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ShockingIconClass",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ShockingRightIconClass",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ShockingRightSubTitle",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ShockingRightTitle",
                table: "HomePages");

            migrationBuilder.DropColumn(
                name: "ShockingTitle",
                table: "HomePages");
        }
    }
}
