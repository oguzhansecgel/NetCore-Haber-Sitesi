using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HaberGorselleri",
                columns: table => new
                {
                    NewsImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaberGorselleri", x => x.NewsImageID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "SosyalMedyaLinkler",
                columns: table => new
                {
                    SocialMediaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstagramURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalMedyaLinkler", x => x.SocialMediaID);
                });

            migrationBuilder.CreateTable(
                name: "Haberler",
                columns: table => new
                {
                    NewsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditorPick = table.Column<bool>(type: "bit", nullable: false),
                    NewsEnterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haberler", x => x.NewsID);
                    table.ForeignKey(
                        name: "FK_Haberler_Kategoriler_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Kategoriler",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_NewsNewsImage_HaberGorselleri_NewsImageID",
                        column: x => x.NewsImageID,
                        principalTable: "HaberGorselleri",
                        principalColumn: "NewsImageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsNewsImage_Haberler_NewsID",
                        column: x => x.NewsID,
                        principalTable: "Haberler",
                        principalColumn: "NewsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Haberler_CategoryID",
                table: "Haberler",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsNewsImage_NewsImageID",
                table: "NewsNewsImage",
                column: "NewsImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsNewsImage");

            migrationBuilder.DropTable(
                name: "SosyalMedyaLinkler");

            migrationBuilder.DropTable(
                name: "HaberGorselleri");

            migrationBuilder.DropTable(
                name: "Haberler");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
