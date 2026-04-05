using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.LargeAppliances.Migrations
{
    /// <inheritdoc />
    public partial class x7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeroSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroLeftButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroLefButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroRightButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroRightButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlueTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlueSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlueValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrangeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrangeSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrangeValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GreenTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GreenSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GreenValues = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePages");
        }
    }
}
