using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resmap.Data.Migrations
{
    public partial class updatedJobTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_LabelEntity_JobTitleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "LabelEntity");

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobTitle_JobTitleId",
                table: "Employees",
                column: "JobTitleId",
                principalTable: "JobTitle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobTitle_JobTitleId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "JobTitle");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "LabelEntity",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_LabelEntity_JobTitleId",
                table: "Employees",
                column: "JobTitleId",
                principalTable: "LabelEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
