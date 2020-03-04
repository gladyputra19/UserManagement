using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updateEmployee1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Bootcamp_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bootcamp_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Employee_Id",
                table: "tb_m_bootcamp",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_bootcamp_Employee_Id",
                table: "tb_m_bootcamp",
                column: "Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_bootcamp_AspNetUsers_Employee_Id",
                table: "tb_m_bootcamp",
                column: "Employee_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_bootcamp_AspNetUsers_Employee_Id",
                table: "tb_m_bootcamp");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_bootcamp_Employee_Id",
                table: "tb_m_bootcamp");

            migrationBuilder.DropColumn(
                name: "Employee_Id",
                table: "tb_m_bootcamp");

            migrationBuilder.AddColumn<int>(
                name: "Bootcamp_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Bootcamp_Id",
                table: "AspNetUsers",
                column: "Bootcamp_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_bootcamp_Bootcamp_Id",
                table: "AspNetUsers",
                column: "Bootcamp_Id",
                principalTable: "tb_m_bootcamp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
