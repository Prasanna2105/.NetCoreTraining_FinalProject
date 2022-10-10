using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkForceManagement.API.Migrations
{
    public partial class updatednew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Profiles_profilesprofile_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_profilesprofile_id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "profilesprofile_id",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_profile_id",
                table: "Employees",
                column: "profile_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Profiles_profile_id",
                table: "Employees",
                column: "profile_id",
                principalTable: "Profiles",
                principalColumn: "profile_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Profiles_profile_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_profile_id",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "profilesprofile_id",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_profilesprofile_id",
                table: "Employees",
                column: "profilesprofile_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Profiles_profilesprofile_id",
                table: "Employees",
                column: "profilesprofile_id",
                principalTable: "Profiles",
                principalColumn: "profile_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
