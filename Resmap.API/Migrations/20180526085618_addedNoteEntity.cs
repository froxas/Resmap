using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Resmap.API.Migrations
{
    public partial class addedNoteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NoteId",
                table: "Relations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relations_NoteId",
                table: "Relations",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Note_NoteId",
                table: "Relations",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Note_NoteId",
                table: "Relations");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Relations_NoteId",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Relations");
        }
    }
}
