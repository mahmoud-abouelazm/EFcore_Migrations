using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIDB.Migrations
{
    /// <inheritdoc />
    public partial class changeDepartmentFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_Dept_ManagerId",
                table: "Department");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_Dept_ManagerId",
                table: "Department",
                column: "Dept_ManagerId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Instructor_Dept_ManagerId",
                table: "Department");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Instructor_Dept_ManagerId",
                table: "Department",
                column: "Dept_ManagerId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
