﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareBook.Repository.Migrations
{
    public partial class Add_instagram2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Users");
        }
    }
}
