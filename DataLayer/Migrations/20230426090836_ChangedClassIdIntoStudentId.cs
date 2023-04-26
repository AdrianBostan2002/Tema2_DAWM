using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class ChangedClassIdIntoStudentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Users",
                newName: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentId",
                table: "Users",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_StudentId",
                table: "Users",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_StudentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Users",
                newName: "ClassId");
        }
    }
}
