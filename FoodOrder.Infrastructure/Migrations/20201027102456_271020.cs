using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodOrder.Migrations
{
    public partial class _271020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Meal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Meal");
        }
    }
}
