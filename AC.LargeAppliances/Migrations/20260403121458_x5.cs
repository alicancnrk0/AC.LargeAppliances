using System;
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
            migrationBuilder.CreateTable(
                name: "ProductPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeroLeftButonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroLeftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroLeftDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroLeftImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroRightImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPages");
        }
    }
}
