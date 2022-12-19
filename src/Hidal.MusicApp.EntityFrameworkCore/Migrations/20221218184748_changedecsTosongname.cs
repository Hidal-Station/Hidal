using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hidal.MusicApp.Migrations
{
    public partial class changedecsTosongname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AppPerformanceMusics",
                newName: "SongName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SongName",
                table: "AppPerformanceMusics",
                newName: "Description");
        }
    }
}
