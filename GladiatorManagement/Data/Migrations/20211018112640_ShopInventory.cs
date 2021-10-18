using Microsoft.EntityFrameworkCore.Migrations;

namespace GladiatorManagement.Data.Migrations
{
    public partial class ShopInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopInventoryId",
                table: "Weapons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopInventoryId",
                table: "Armors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopInventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GladiatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopInventories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_ShopInventoryId",
                table: "Weapons",
                column: "ShopInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Armors_ShopInventoryId",
                table: "Armors",
                column: "ShopInventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armors_ShopInventories_ShopInventoryId",
                table: "Armors",
                column: "ShopInventoryId",
                principalTable: "ShopInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_ShopInventories_ShopInventoryId",
                table: "Weapons",
                column: "ShopInventoryId",
                principalTable: "ShopInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armors_ShopInventories_ShopInventoryId",
                table: "Armors");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_ShopInventories_ShopInventoryId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "ShopInventories");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_ShopInventoryId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Armors_ShopInventoryId",
                table: "Armors");

            migrationBuilder.DropColumn(
                name: "ShopInventoryId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "ShopInventoryId",
                table: "Armors");
        }
    }
}
