using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class newsimagetablerelationchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsNewsImage");

            migrationBuilder.CreateIndex(
                name: "IX_NewsImages_NewsID",
                table: "NewsImages",
                column: "NewsID");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsImages_Newses_NewsID",
                table: "NewsImages",
                column: "NewsID",
                principalTable: "Newses",
                principalColumn: "NewsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsImages_Newses_NewsID",
                table: "NewsImages");

            migrationBuilder.DropIndex(
                name: "IX_NewsImages_NewsID",
                table: "NewsImages");

            migrationBuilder.CreateTable(
                name: "NewsNewsImage",
                columns: table => new
                {
                    NewsID = table.Column<int>(type: "int", nullable: false),
                    NewsImageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsNewsImage", x => new { x.NewsID, x.NewsImageID });
                    table.ForeignKey(
                        name: "FK_NewsNewsImage_Newses_NewsID",
                        column: x => x.NewsID,
                        principalTable: "Newses",
                        principalColumn: "NewsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsNewsImage_NewsImages_NewsImageID",
                        column: x => x.NewsImageID,
                        principalTable: "NewsImages",
                        principalColumn: "NewsImageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsNewsImage_NewsImageID",
                table: "NewsNewsImage",
                column: "NewsImageID");
        }
    }
}
