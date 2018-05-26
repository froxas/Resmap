using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Resmap.API.Migrations
{
    public partial class addedRelationTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RelationTypeId",
                table: "Relations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RelationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relations_RelationTypeId",
                table: "Relations",
                column: "RelationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_RelationType_RelationTypeId",
                table: "Relations",
                column: "RelationTypeId",
                principalTable: "RelationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_RelationType_RelationTypeId",
                table: "Relations");

            migrationBuilder.DropTable(
                name: "RelationType");

            migrationBuilder.DropIndex(
                name: "IX_Relations_RelationTypeId",
                table: "Relations");

            migrationBuilder.DropColumn(
                name: "RelationTypeId",
                table: "Relations");
        }
    }
}
