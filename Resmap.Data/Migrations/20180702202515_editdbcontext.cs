using Microsoft.EntityFrameworkCore.Migrations;

namespace Resmap.Data.Migrations
{
    public partial class editdbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Projects_ProjectId",
                table: "ProjectTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Tags_TagId",
                table: "ProjectTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTag",
                table: "ProjectTag");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProjectTag_ProjectId_TagId",
                table: "ProjectTag");

            migrationBuilder.RenameTable(
                name: "ProjectTag",
                newName: "ProjectTags");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTag_TagId",
                table: "ProjectTags",
                newName: "IX_ProjectTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTags",
                table: "ProjectTags",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProjectTags_ProjectId_TagId",
                table: "ProjectTags",
                columns: new[] { "ProjectId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTags_Projects_ProjectId",
                table: "ProjectTags",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTags_Tags_TagId",
                table: "ProjectTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTags_Projects_ProjectId",
                table: "ProjectTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTags_Tags_TagId",
                table: "ProjectTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTags",
                table: "ProjectTags");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProjectTags_ProjectId_TagId",
                table: "ProjectTags");

            migrationBuilder.RenameTable(
                name: "ProjectTags",
                newName: "ProjectTag");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTags_TagId",
                table: "ProjectTag",
                newName: "IX_ProjectTag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTag",
                table: "ProjectTag",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProjectTag_ProjectId_TagId",
                table: "ProjectTag",
                columns: new[] { "ProjectId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Projects_ProjectId",
                table: "ProjectTag",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Tags_TagId",
                table: "ProjectTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
