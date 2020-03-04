using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class deleteRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_region_Region_Id",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tb_m_region");

            migrationBuilder.RenameColumn(
                name: "Region_Id",
                table: "AspNetUsers",
                newName: "Regency_Id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Region_Id",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Regency_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_regency_Regency_Id",
                table: "AspNetUsers",
                column: "Regency_Id",
                principalTable: "tb_m_regency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_regency_Regency_Id",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Regency_Id",
                table: "AspNetUsers",
                newName: "Region_Id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Regency_Id",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Region_Id");

            migrationBuilder.CreateTable(
                name: "tb_m_region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Regency_Id = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_region", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_region_Region_Id",
                table: "AspNetUsers",
                column: "Region_Id",
                principalTable: "tb_m_region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
