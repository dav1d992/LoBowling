using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BowlingGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerName = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BowlingGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstRoll = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondRoll = table.Column<int>(type: "INTEGER", nullable: false),
                    BowlingGameId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frame_BowlingGames_BowlingGameId",
                        column: x => x.BowlingGameId,
                        principalTable: "BowlingGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frame_BowlingGameId",
                table: "Frame",
                column: "BowlingGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frame");

            migrationBuilder.DropTable(
                name: "BowlingGames");
        }
    }
}
