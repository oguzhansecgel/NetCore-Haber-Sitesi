using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class addedcolumnnews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsContent2",
                table: "Newses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsContent3",
                table: "Newses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsContentTitle",
                table: "Newses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsContentTitle2",
                table: "Newses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsContent2",
                table: "Newses");

            migrationBuilder.DropColumn(
                name: "NewsContent3",
                table: "Newses");

            migrationBuilder.DropColumn(
                name: "NewsContentTitle",
                table: "Newses");

            migrationBuilder.DropColumn(
                name: "NewsContentTitle2",
                table: "Newses");
        }
    }
}
