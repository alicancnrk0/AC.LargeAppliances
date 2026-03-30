using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.LargeAppliances.Migrations
{
    /// <inheritdoc />
    public partial class x23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardIcon1Class",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon1Description",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon1Tittle",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon2Class",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon2Description",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon2Tittle",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon3Class",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon3Description",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon3Tittle",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon4Class",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon4Description",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon4Tittle",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon5Class",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon5Description",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardIcon5Tittle",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAlt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropColumn(
                name: "CardIcon1Class",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon1Description",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon1Tittle",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon2Class",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon2Description",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon2Tittle",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon3Class",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon3Description",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon3Tittle",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon4Class",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon4Description",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon4Tittle",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon5Class",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon5Description",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardIcon5Tittle",
                table: "Cards");
        }
    }
}
