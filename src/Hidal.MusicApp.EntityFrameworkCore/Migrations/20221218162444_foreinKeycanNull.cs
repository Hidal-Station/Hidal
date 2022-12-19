using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hidal.MusicApp.Migrations
{
    public partial class foreinKeycanNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSongs_AppAuthors_AuthorId",
                table: "AppSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSongs_AppCategories_CategoryId",
                table: "AppSongs");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSongs_AppAuthors_AuthorId",
                table: "AppSongs",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSongs_AppCategories_CategoryId",
                table: "AppSongs",
                column: "CategoryId",
                principalTable: "AppCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppSongs_AppAuthors_AuthorId",
                table: "AppSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSongs_AppCategories_CategoryId",
                table: "AppSongs");

            migrationBuilder.AddForeignKey(
                name: "FK_AppSongs_AppAuthors_AuthorId",
                table: "AppSongs",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSongs_AppCategories_CategoryId",
                table: "AppSongs",
                column: "CategoryId",
                principalTable: "AppCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
