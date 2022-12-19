using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hidal.MusicApp.Migrations
{
    public partial class deleteRelationShipSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPerformanceMusics_AppSongs_SongId",
                table: "AppPerformanceMusics");

            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "AppPerformanceMusics",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPerformanceMusics_AppSongs_SongId",
                table: "AppPerformanceMusics",
                column: "SongId",
                principalTable: "AppSongs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPerformanceMusics_AppSongs_SongId",
                table: "AppPerformanceMusics");

            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "AppPerformanceMusics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPerformanceMusics_AppSongs_SongId",
                table: "AppPerformanceMusics",
                column: "SongId",
                principalTable: "AppSongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
