using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkForceManagement.API.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    profile_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profile_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.profile_id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    skillid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skillname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.skillid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    manager = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    wfm_manager = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    lockstatus = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    experience = table.Column<decimal>(type: "decimal(5,0)", nullable: false),
                    profile_id = table.Column<int>(type: "int", nullable: false),
                    profilesprofile_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employees_Profiles_profilesprofile_id",
                        column: x => x.profilesprofile_id,
                        principalTable: "Profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skillmaps",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    skillid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skillmaps", x => new { x.employee_id, x.skillid });
                    table.ForeignKey(
                        name: "FK_Skillmaps_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skillmaps_Skills_skillid",
                        column: x => x.skillid,
                        principalTable: "Skills",
                        principalColumn: "skillid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Softlocks",
                columns: table => new
                {
                    lockid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    manager = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    reqdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    lastupdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    requestmessage = table.Column<string>(type: "varchar", nullable: true),
                    wfmremark = table.Column<string>(type: "varchar", nullable: true),
                    managerstatus = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, defaultValue: "awaiting_approval"),
                    mgrstatuscomment = table.Column<string>(type: "varchar", nullable: true),
                    mgrlastupdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softlocks", x => x.lockid);
                    table.ForeignKey(
                        name: "FK_Softlocks_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_profilesprofile_id",
                table: "Employees",
                column: "profilesprofile_id");

            migrationBuilder.CreateIndex(
                name: "IX_Skillmaps_skillid",
                table: "Skillmaps",
                column: "skillid");

            migrationBuilder.CreateIndex(
                name: "IX_Softlocks_employee_id",
                table: "Softlocks",
                column: "employee_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skillmaps");

            migrationBuilder.DropTable(
                name: "Softlocks");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
