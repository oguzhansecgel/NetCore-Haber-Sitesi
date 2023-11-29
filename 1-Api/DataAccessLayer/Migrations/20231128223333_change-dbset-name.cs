using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class changedbsetname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Haberler_Kategoriler_CategoryID",
                table: "Haberler");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsNewsImage_HaberGorselleri_NewsImageID",
                table: "NewsNewsImage");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsNewsImage_Haberler_NewsID",
                table: "NewsNewsImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SosyalMedyaLinkler",
                table: "SosyalMedyaLinkler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Haberler",
                table: "Haberler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HaberGorselleri",
                table: "HaberGorselleri");

            migrationBuilder.RenameTable(
                name: "SosyalMedyaLinkler",
                newName: "SocialMedias");

            migrationBuilder.RenameTable(
                name: "Kategoriler",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Haberler",
                newName: "Newses");

            migrationBuilder.RenameTable(
                name: "HaberGorselleri",
                newName: "NewsImages");

            migrationBuilder.RenameIndex(
                name: "IX_Haberler_CategoryID",
                table: "Newses",
                newName: "IX_Newses_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias",
                column: "SocialMediaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Newses",
                table: "Newses",
                column: "NewsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsImages",
                table: "NewsImages",
                column: "NewsImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Newses_Categories_CategoryID",
                table: "Newses",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsNewsImage_Newses_NewsID",
                table: "NewsNewsImage",
                column: "NewsID",
                principalTable: "Newses",
                principalColumn: "NewsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsNewsImage_NewsImages_NewsImageID",
                table: "NewsNewsImage",
                column: "NewsImageID",
                principalTable: "NewsImages",
                principalColumn: "NewsImageID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Newses_Categories_CategoryID",
                table: "Newses");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsNewsImage_Newses_NewsID",
                table: "NewsNewsImage");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsNewsImage_NewsImages_NewsImageID",
                table: "NewsNewsImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsImages",
                table: "NewsImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Newses",
                table: "Newses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "SocialMedias",
                newName: "SosyalMedyaLinkler");

            migrationBuilder.RenameTable(
                name: "NewsImages",
                newName: "HaberGorselleri");

            migrationBuilder.RenameTable(
                name: "Newses",
                newName: "Haberler");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Kategoriler");

            migrationBuilder.RenameIndex(
                name: "IX_Newses_CategoryID",
                table: "Haberler",
                newName: "IX_Haberler_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SosyalMedyaLinkler",
                table: "SosyalMedyaLinkler",
                column: "SocialMediaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HaberGorselleri",
                table: "HaberGorselleri",
                column: "NewsImageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Haberler",
                table: "Haberler",
                column: "NewsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Haberler_Kategoriler_CategoryID",
                table: "Haberler",
                column: "CategoryID",
                principalTable: "Kategoriler",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsNewsImage_HaberGorselleri_NewsImageID",
                table: "NewsNewsImage",
                column: "NewsImageID",
                principalTable: "HaberGorselleri",
                principalColumn: "NewsImageID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsNewsImage_Haberler_NewsID",
                table: "NewsNewsImage",
                column: "NewsID",
                principalTable: "Haberler",
                principalColumn: "NewsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
