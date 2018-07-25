using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resmap.Data.Migrations
{
    public partial class addedJobTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "LabelEntity",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "JobTitleId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_LabelEntity_JobTitleId",
                table: "Employees",
                column: "JobTitleId",
                principalTable: "LabelEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_LabelEntity_JobTitleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "LabelEntity");

            migrationBuilder.DropColumn(
                name: "JobTitleId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Employees",
                nullable: true);
        }
    }
}
