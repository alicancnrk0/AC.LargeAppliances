using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.LargeAppliances.Migrations
{
    /// <inheritdoc />
    public partial class x2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.CreateTable(
                name: "CardItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardItems");

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardIcon1Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon1Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon2Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon2Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon3Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon3Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon4Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon4Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon5Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon5Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardIcon5Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });
        }
    }
}
