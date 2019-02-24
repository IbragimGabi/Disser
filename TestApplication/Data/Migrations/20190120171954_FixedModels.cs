using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Data.Migrations
{
    public partial class FixedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TestTasks",
                newName: "TestTaskId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tests",
                newName: "TestId");

            migrationBuilder.AddColumn<string>(
                name: "TestFile",
                table: "Tests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestTasks_TestTaskId",
                table: "TestTasks",
                column: "TestTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TestTasks_TestTaskId",
                table: "TestTasks");

            migrationBuilder.DropColumn(
                name: "TestFile",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "TestTaskId",
                table: "TestTasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "Tests",
                newName: "Id");
        }
    }
}
