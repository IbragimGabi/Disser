using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApplication.Data.Migrations
{
    public partial class ChangedFlowStateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowStateId",
                table: "TestTasks");

            migrationBuilder.AddColumn<string>(
                name: "FlowStateName",
                table: "TestTasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowStateName",
                table: "TestTasks");

            migrationBuilder.AddColumn<int>(
                name: "FlowStateId",
                table: "TestTasks",
                nullable: false,
                defaultValue: 0);
        }
    }
}
