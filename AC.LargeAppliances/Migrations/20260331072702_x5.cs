using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.LargeAppliances.Migrations
{
    /// <inheritdoc />
    public partial class x5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BottomPhoneIconClass",
                table: "Contactpages",
                newName: "BottomPhoneImagePath");

            migrationBuilder.RenameColumn(
                name: "BottomMapIconClass",
                table: "Contactpages",
                newName: "BottomMapImagePath");

            migrationBuilder.RenameColumn(
                name: "BottomChatIconClass",
                table: "Contactpages",
                newName: "BottomChatImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BottomPhoneImagePath",
                table: "Contactpages",
                newName: "BottomPhoneIconClass");

            migrationBuilder.RenameColumn(
                name: "BottomMapImagePath",
                table: "Contactpages",
                newName: "BottomMapIconClass");

            migrationBuilder.RenameColumn(
                name: "BottomChatImagePath",
                table: "Contactpages",
                newName: "BottomChatIconClass");
        }
    }
}
