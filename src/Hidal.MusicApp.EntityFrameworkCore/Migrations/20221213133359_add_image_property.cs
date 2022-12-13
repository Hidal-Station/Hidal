using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hidal.MusicApp.Migrations
{
    public partial class add_image_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "AppComments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AppAppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AppComments");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AppAppUsers");
        }
    }
}
