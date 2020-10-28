using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrder.Migrations
{
    public partial class _07102020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "lname",
                table: "User",
                newName: "Lname");

            migrationBuilder.RenameColumn(
                name: "fname",
                table: "User",
                newName: "Fname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "User",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "sum",
                table: "Order",
                newName: "Sum");

            migrationBuilder.RenameColumn(
                name: "receipt",
                table: "Order",
                newName: "Receipt");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "Meal",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Meal",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Meal",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Meal",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Meal",
                newName: "Name");

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

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Lname",
                table: "User",
                newName: "lname");

            migrationBuilder.RenameColumn(
                name: "Fname",
                table: "User",
                newName: "fname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Sum",
                table: "Order",
                newName: "sum");

            migrationBuilder.RenameColumn(
                name: "Receipt",
                table: "Order",
                newName: "receipt");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Meal",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Meal",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Meal",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Meal",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Meal",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "User",
                type: "text",
                nullable: true);
        }
    }
}
