﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace UselessCore.Migrations
{
    public partial class Auth3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetRoles");
        }
    }
}
