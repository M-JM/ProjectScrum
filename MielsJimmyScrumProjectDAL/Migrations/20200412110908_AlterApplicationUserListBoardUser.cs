using Microsoft.EntityFrameworkCore.Migrations;

namespace MielsJimmyScrumProjectDAL.Migrations
{
    public partial class AlterApplicationUserListBoardUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoardUsers_ApplicationUserId",
                table: "BoardUsers");

            migrationBuilder.CreateIndex(
                name: "IX_BoardUsers_ApplicationUserId",
                table: "BoardUsers",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoardUsers_ApplicationUserId",
                table: "BoardUsers");

            migrationBuilder.CreateIndex(
                name: "IX_BoardUsers_ApplicationUserId",
                table: "BoardUsers",
                column: "ApplicationUserId",
                unique: true);
        }
    }
}
