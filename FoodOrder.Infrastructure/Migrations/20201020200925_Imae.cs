using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrder.Migrations
{
    public partial class Imae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Meal_mealId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_userId",
                table: "Order");

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
                name: "userId",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Order",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "sum",
                table: "Order",
                newName: "Sum");

            migrationBuilder.RenameColumn(
                name: "receipt",
                table: "Order",
                newName: "Receipt");

            migrationBuilder.RenameColumn(
                name: "mealId",
                table: "Order",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_userId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_mealId",
                table: "Order",
                newName: "IX_Order_MealId");

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

            migrationBuilder.RenameColumn(
                name: "mealId",
                table: "Meal",
                newName: "MealId");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Meal",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Meal_MealId",
                table: "Order",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Meal_MealId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Meal");

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
                name: "UserId",
                table: "User",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Order",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Sum",
                table: "Order",
                newName: "sum");

            migrationBuilder.RenameColumn(
                name: "Receipt",
                table: "Order",
                newName: "receipt");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Order",
                newName: "mealId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "orderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Order",
                newName: "IX_Order_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_MealId",
                table: "Order",
                newName: "IX_Order_mealId");

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

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "Meal",
                newName: "mealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Meal_mealId",
                table: "Order",
                column: "mealId",
                principalTable: "Meal",
                principalColumn: "mealId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_userId",
                table: "Order",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
