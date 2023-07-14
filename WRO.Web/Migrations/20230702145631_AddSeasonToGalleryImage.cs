using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WRO.Web.Migrations
{
    public partial class AddSeasonToGalleryImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "Images",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Season",
                table: "Images");
        }
    }
}
