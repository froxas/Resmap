using Microsoft.EntityFrameworkCore.Migrations;

namespace Resmap.Data.Migrations
{
    public partial class addedProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Project_ProjectId",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Projects_ProjectId",
                table: "Event",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Projects_ProjectId",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Project_ProjectId",
                table: "Event",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
