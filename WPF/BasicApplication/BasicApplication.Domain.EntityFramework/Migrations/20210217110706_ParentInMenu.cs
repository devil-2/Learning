using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicApplication.Domain.EntityFramework.Migrations
{
    public partial class ParentInMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "Menus");
        }
    }
}
