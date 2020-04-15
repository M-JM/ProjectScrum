using Microsoft.EntityFrameworkCore.Migrations;

namespace MielsJimmyScrumProjectDAL.Migrations
{
    public partial class Alt2ManytoManyRelationBetweenBoardandUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardUser_AspNetUsers_ApplicationUserId",
                table: "BoardUser");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardUser_Boards_BoardId",
                table: "BoardUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardUser",
                table: "BoardUser");

            migrationBuilder.RenameTable(
                name: "BoardUser",
                newName: "BoardUsers");

            migrationBuilder.RenameIndex(
                name: "IX_BoardUser_ApplicationUserId",
                table: "BoardUsers",
                newName: "IX_BoardUsers_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardUsers",
                table: "BoardUsers",
                columns: new[] { "BoardId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BoardUsers_AspNetUsers_ApplicationUserId",
                table: "BoardUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardUsers_Boards_BoardId",
                table: "BoardUsers",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardUsers_AspNetUsers_ApplicationUserId",
                table: "BoardUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardUsers_Boards_BoardId",
                table: "BoardUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardUsers",
                table: "BoardUsers");

            migrationBuilder.RenameTable(
                name: "BoardUsers",
                newName: "BoardUser");

            migrationBuilder.RenameIndex(
                name: "IX_BoardUsers_ApplicationUserId",
                table: "BoardUser",
                newName: "IX_BoardUser_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardUser",
                table: "BoardUser",
                columns: new[] { "BoardId", "ApplicationUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BoardUser_AspNetUsers_ApplicationUserId",
                table: "BoardUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardUser_Boards_BoardId",
                table: "BoardUser",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
