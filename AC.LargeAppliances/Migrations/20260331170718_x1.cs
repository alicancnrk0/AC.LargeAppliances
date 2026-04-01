using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.LargeAppliances.Migrations
{
    /// <inheritdoc />
    public partial class x1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value1IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value2IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value3IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value4IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value4Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features4Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features4Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoresTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoresDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPages", x => x.Id);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPages");

        }
    }
}
