using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hidal.MusicApp.Migrations
{
    public partial class add_property_for_music : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRating",
                table: "AppPerformanceMusics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ratingAverage",
                table: "AppPerformanceMusics",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRating",
                table: "AppPerformanceMusics");

            migrationBuilder.DropColumn(
                name: "ratingAverage",
                table: "AppPerformanceMusics");
        }
    }
}
