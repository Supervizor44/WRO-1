using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WRO.Web.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdentityCardImageId",
                table: "Volunteers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityCardImageId",
                table: "TeamMembers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityCardImageId",
                table: "TeamCoaches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdentityCardImageId",
                table: "Judges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IdentityCardImageId",
                table: "Volunteers",
                column: "IdentityCardImageId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_IdentityCardImageId",
                table: "TeamMembers",
                column: "IdentityCardImageId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCoaches_IdentityCardImageId",
                table: "TeamCoaches",
                column: "IdentityCardImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_IdentityCardImageId",
                table: "Judges",
                column: "IdentityCardImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Judges_Images_IdentityCardImageId",
                table: "Judges",
                column: "IdentityCardImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamCoaches_Images_IdentityCardImageId",
                table: "TeamCoaches",
                column: "IdentityCardImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Images_IdentityCardImageId",
                table: "TeamMembers",
                column: "IdentityCardImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteers_Images_IdentityCardImageId",
                table: "Volunteers",
                column: "IdentityCardImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Judges_Images_IdentityCardImageId",
                table: "Judges");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamCoaches_Images_IdentityCardImageId",
                table: "TeamCoaches");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Images_IdentityCardImageId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteers_Images_IdentityCardImageId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_Volunteers_IdentityCardImageId",
                table: "Volunteers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_IdentityCardImageId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamCoaches_IdentityCardImageId",
                table: "TeamCoaches");

            migrationBuilder.DropIndex(
                name: "IX_Judges_IdentityCardImageId",
                table: "Judges");

            migrationBuilder.DropColumn(
                name: "IdentityCardImageId",
                table: "Volunteers");

            migrationBuilder.DropColumn(
                name: "IdentityCardImageId",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "IdentityCardImageId",
                table: "TeamCoaches");

            migrationBuilder.DropColumn(
                name: "IdentityCardImageId",
                table: "Judges");
        }
    }
}
