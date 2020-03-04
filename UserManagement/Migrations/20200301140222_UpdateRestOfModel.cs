using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class UpdateRestOfModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_t_applicationusers",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_religion",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_region",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_regency",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_province",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_major",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_jobtitle",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_division",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_department",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_degree",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_batch",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "isDelete",
                table: "tb_m_application",
                newName: "IsDelete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_t_applicationusers",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_religion",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_region",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_regency",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_province",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_major",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_jobtitle",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_division",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_department",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_degree",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_batch",
                newName: "isDelete");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "tb_m_application",
                newName: "isDelete");
        }
    }
}
