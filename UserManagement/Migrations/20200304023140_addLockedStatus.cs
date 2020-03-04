using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class addLockedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<bool>(
                name: "LockedStatus",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockedStatus",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "AspNetRoles",
                nullable: true);
        }
    }
}
