using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resmap.Data.Migrations
{
    public partial class addedAddressToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AddressId",
                table: "Projects",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Address_AddressId",
                table: "Projects",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Address_AddressId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AddressId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Projects");
        }
    }
}
