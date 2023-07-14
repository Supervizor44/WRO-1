using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WRO.Web.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdSerialNumber",
                table: "Volunteers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdSerialNumber",
                table: "TeamMembers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdSerialNumber",
                table: "TeamCoaches",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdSerialNumber",
                table: "Judges",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSerialNumber",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "IdSerialNumber",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "IdSerialNumber",
                table: "TeamCoaches");

            migrationBuilder.DropColumn(
                name: "IdSerialNumber",
                table: "Judges");
        }
    }
}
