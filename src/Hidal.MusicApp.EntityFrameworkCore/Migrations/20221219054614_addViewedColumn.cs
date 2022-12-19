using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hidal.MusicApp.Migrations
{
    public partial class addViewedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Viewed",
                table: "AppPerformanceMusics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Viewed",
                table: "AppPerformanceMusics");
        }
    }
}
