using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AC.LargeAppliances.Migrations
{
    /// <inheritdoc />
    public partial class x4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactpages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoresTittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoresDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomChatIconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomChatTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomChatDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomChatMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomPhoneIconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomPhoneTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomPhoneDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomMapIconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomMapTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomMapDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BottomMapAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactpages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contactpages");
        }
    }
}
