using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class updateEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_regency_tb_m_province_Province_Id",
                table: "tb_m_regency");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_region_tb_m_regency_Regency_Id",
                table: "tb_m_region");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_applicationusers_tb_m_application_Application_Id",
                table: "tb_t_applicationusers");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_applicationusers_AspNetUsers_Employee_Id",
                table: "tb_t_applicationusers");

            migrationBuilder.DropIndex(
                name: "IX_tb_t_applicationusers_Application_Id",
                table: "tb_t_applicationusers");

            migrationBuilder.DropIndex(
                name: "IX_tb_t_applicationusers_Employee_Id",
                table: "tb_t_applicationusers");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_region_Regency_Id",
                table: "tb_m_region");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_regency_Province_Id",
                table: "tb_m_regency");

            migrationBuilder.AlterColumn<string>(
                name: "Employee_Id",
                table: "tb_t_applicationusers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "tb_m_regency",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bootcamp_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Degree_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Department_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobTitle_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Major_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIK",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Region_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Religion_Id",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "AspNetRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tb_m_bootcamp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Batch_Id = table.Column<int>(nullable: false),
                    Major_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_bootcamp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_bootcamp_tb_m_batch_Batch_Id",
                        column: x => x.Batch_Id,
                        principalTable: "tb_m_batch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_bootcamp_tb_m_major_Major_Id",
                        column: x => x.Major_Id,
                        principalTable: "tb_m_major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_regency_ProvinceId",
                table: "tb_m_regency",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Bootcamp_Id",
                table: "AspNetUsers",
                column: "Bootcamp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Degree_Id",
                table: "AspNetUsers",
                column: "Degree_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Department_Id",
                table: "AspNetUsers",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JobTitle_Id",
                table: "AspNetUsers",
                column: "JobTitle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Major_Id",
                table: "AspNetUsers",
                column: "Major_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Region_Id",
                table: "AspNetUsers",
                column: "Region_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Religion_Id",
                table: "AspNetUsers",
                column: "Religion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_bootcamp_Batch_Id",
                table: "tb_m_bootcamp",
                column: "Batch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_bootcamp_Major_Id",
                table: "tb_m_bootcamp",
                column: "Major_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_bootcamp_Bootcamp_Id",
                table: "AspNetUsers",
                column: "Bootcamp_Id",
                principalTable: "tb_m_bootcamp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_degree_Degree_Id",
                table: "AspNetUsers",
                column: "Degree_Id",
                principalTable: "tb_m_degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_department_Department_Id",
                table: "AspNetUsers",
                column: "Department_Id",
                principalTable: "tb_m_department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_jobtitle_JobTitle_Id",
                table: "AspNetUsers",
                column: "JobTitle_Id",
                principalTable: "tb_m_jobtitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_major_Major_Id",
                table: "AspNetUsers",
                column: "Major_Id",
                principalTable: "tb_m_major",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_region_Region_Id",
                table: "AspNetUsers",
                column: "Region_Id",
                principalTable: "tb_m_region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tb_m_religion_Religion_Id",
                table: "AspNetUsers",
                column: "Religion_Id",
                principalTable: "tb_m_religion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_regency_tb_m_province_ProvinceId",
                table: "tb_m_regency",
                column: "ProvinceId",
                principalTable: "tb_m_province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_bootcamp_Bootcamp_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_degree_Degree_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_department_Department_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_jobtitle_JobTitle_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_major_Major_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_region_Region_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_tb_m_religion_Religion_Id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_regency_tb_m_province_ProvinceId",
                table: "tb_m_regency");

            migrationBuilder.DropTable(
                name: "tb_m_bootcamp");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_regency_ProvinceId",
                table: "tb_m_regency");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Bootcamp_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Degree_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Department_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_JobTitle_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Major_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Region_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Religion_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "tb_m_regency");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bootcamp_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Degree_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Department_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobTitle_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Major_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NIK",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Region_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Religion_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "University",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<string>(
                name: "Employee_Id",
                table: "tb_t_applicationusers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_applicationusers_Application_Id",
                table: "tb_t_applicationusers",
                column: "Application_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_t_applicationusers_Employee_Id",
                table: "tb_t_applicationusers",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_region_Regency_Id",
                table: "tb_m_region",
                column: "Regency_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_regency_Province_Id",
                table: "tb_m_regency",
                column: "Province_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_regency_tb_m_province_Province_Id",
                table: "tb_m_regency",
                column: "Province_Id",
                principalTable: "tb_m_province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_region_tb_m_regency_Regency_Id",
                table: "tb_m_region",
                column: "Regency_Id",
                principalTable: "tb_m_regency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_applicationusers_tb_m_application_Application_Id",
                table: "tb_t_applicationusers",
                column: "Application_Id",
                principalTable: "tb_m_application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_applicationusers_AspNetUsers_Employee_Id",
                table: "tb_t_applicationusers",
                column: "Employee_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
