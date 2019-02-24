using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Data.Migrations
{
    public partial class AddedQuestions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestTask_Tests_TestId",
                table: "TestTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestTask",
                table: "TestTask");

            migrationBuilder.RenameTable(
                name: "TestTask",
                newName: "TestTasks");

            migrationBuilder.RenameIndex(
                name: "IX_TestTask_TestId",
                table: "TestTasks",
                newName: "IX_TestTasks_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestTasks",
                table: "TestTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestTasks_Tests_TestId",
                table: "TestTasks",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestTasks_Tests_TestId",
                table: "TestTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestTasks",
                table: "TestTasks");

            migrationBuilder.RenameTable(
                name: "TestTasks",
                newName: "TestTask");

            migrationBuilder.RenameIndex(
                name: "IX_TestTasks_TestId",
                table: "TestTask",
                newName: "IX_TestTask_TestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestTask",
                table: "TestTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestTask_Tests_TestId",
                table: "TestTask",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
