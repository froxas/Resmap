using Microsoft.EntityFrameworkCore.Migrations;

namespace Resmap.Data.Migrations
{
    public partial class addedJoinInterface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Projects_ProjectId",
                table: "ProjectTag");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectTag",
                newName: "ResourceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTag_ProjectId",
                table: "ProjectTag",
                newName: "IX_ProjectTag_ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Projects_ResourceId",
                table: "ProjectTag",
                column: "ResourceId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Projects_ResourceId",
                table: "ProjectTag");

            migrationBuilder.RenameColumn(
                name: "ResourceId",
                table: "ProjectTag",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTag_ResourceId",
                table: "ProjectTag",
                newName: "IX_ProjectTag_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Projects_ProjectId",
                table: "ProjectTag",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
