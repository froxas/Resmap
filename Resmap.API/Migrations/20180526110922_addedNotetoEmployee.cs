using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Resmap.API.Migrations
{
    public partial class addedNotetoEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "NoteId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_NoteId",
                table: "Employees",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Note_NoteId",
                table: "Employees",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Note_NoteId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_NoteId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Employees",
                nullable: true);
        }
    }
}
