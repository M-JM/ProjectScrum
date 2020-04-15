using Microsoft.EntityFrameworkCore.Migrations;

namespace MielsJimmyScrumProjectDAL.Migrations
{
    public partial class AltManytoManyRelationBetweenBoardandUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Boards_BoardId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_BoardUser_ApplicationUserId",
                table: "BoardUser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BoardId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_BoardUser_ApplicationUserId",
                table: "BoardUser",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoardUser_ApplicationUserId",
                table: "BoardUser");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardUser_ApplicationUserId",
                table: "BoardUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BoardId",
                table: "AspNetUsers",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Boards_BoardId",
                table: "AspNetUsers",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
