using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIDB.Migrations
{
    /// <inheritdoc />
    public partial class fix_instCourseRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Course_Instructor_InstructorId",
                table: "Ins_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Course_Student_st_Id",
                table: "Ins_Course");

            migrationBuilder.DropIndex(
                name: "IX_Ins_Course_InstructorId",
                table: "Ins_Course");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Ins_Course");

            migrationBuilder.RenameColumn(
                name: "st_Id",
                table: "Ins_Course",
                newName: "Instructor_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Course_st_Id",
                table: "Ins_Course",
                newName: "IX_Ins_Course_Instructor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Course_Instructor_Instructor_Id",
                table: "Ins_Course",
                column: "Instructor_Id",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Course_Instructor_Instructor_Id",
                table: "Ins_Course");

            migrationBuilder.RenameColumn(
                name: "Instructor_Id",
                table: "Ins_Course",
                newName: "st_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Course_Instructor_Id",
                table: "Ins_Course",
                newName: "IX_Ins_Course_st_Id");

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Ins_Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Course_InstructorId",
                table: "Ins_Course",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Course_Instructor_InstructorId",
                table: "Ins_Course",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Course_Student_st_Id",
                table: "Ins_Course",
                column: "st_Id",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
