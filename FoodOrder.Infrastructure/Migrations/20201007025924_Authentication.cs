using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrder.Migrations
{
    public partial class Authentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "User",
                type: "text",
                nullable: true);
        }
    }
}
