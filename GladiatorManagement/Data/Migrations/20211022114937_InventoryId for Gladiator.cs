using Microsoft.EntityFrameworkCore.Migrations;

namespace GladiatorManagement.Data.Migrations
{
    public partial class InventoryIdforGladiator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "PlayerGladiators",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "PlayerGladiators");
        }
    }
}
