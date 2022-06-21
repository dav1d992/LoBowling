using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AdjustedFrameIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Frames",
                table: "Frames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Frames",
                table: "Frames",
                columns: new[] { "UserId", "BowlingGameId", "FrameNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Frames",
                table: "Frames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Frames",
                table: "Frames",
                columns: new[] { "UserId", "BowlingGameId" });
        }
    }
}
