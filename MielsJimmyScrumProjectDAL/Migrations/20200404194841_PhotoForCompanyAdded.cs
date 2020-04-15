using Microsoft.EntityFrameworkCore.Migrations;

namespace MielsJimmyScrumProjectDAL.Migrations
{
    public partial class PhotoForCompanyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Companies");
        }
    }
}
