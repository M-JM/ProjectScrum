using Microsoft.EntityFrameworkCore.Migrations;

namespace MielsJimmyScrumProjectDAL.Migrations
{
    public partial class OTMBoardtoCompanyWithUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "AspNetUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Boards_BoardId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BoardId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "AspNetUsers");
        }
    }
}
