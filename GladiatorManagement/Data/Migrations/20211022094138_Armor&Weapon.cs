using Microsoft.EntityFrameworkCore.Migrations;

namespace GladiatorManagement.Data.Migrations
{
    public partial class ArmorWeapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    EmailVerification = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Gold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

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

            migrationBuilder.CreateTable(
                name: "PlayerGladiators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlayerId = table.Column<int>(nullable: true),
                    Strength = table.Column<int>(nullable: false),
                    Accuracy = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Defence = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGladiators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGladiators_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Defence = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    PlayerGladiatorId = table.Column<int>(nullable: true),
                    ShopInventoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armors_PlayerGladiators_PlayerGladiatorId",
                        column: x => x.PlayerGladiatorId,
                        principalTable: "PlayerGladiators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Armors_ShopInventories_ShopInventoryId",
                        column: x => x.ShopInventoryId,
                        principalTable: "ShopInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Accuracy = table.Column<int>(nullable: false),
                    PlayerGladiatorId = table.Column<int>(nullable: true),
                    ShopInventoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_PlayerGladiators_PlayerGladiatorId",
                        column: x => x.PlayerGladiatorId,
                        principalTable: "PlayerGladiators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weapons_ShopInventories_ShopInventoryId",
                        column: x => x.ShopInventoryId,
                        principalTable: "ShopInventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armors_PlayerGladiatorId",
                table: "Armors",
                column: "PlayerGladiatorId",
                unique: true,
                filter: "[PlayerGladiatorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Armors_ShopInventoryId",
                table: "Armors",
                column: "ShopInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGladiators_PlayerId",
                table: "PlayerGladiators",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_PlayerGladiatorId",
                table: "Weapons",
                column: "PlayerGladiatorId",
                unique: true,
                filter: "[PlayerGladiatorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_ShopInventoryId",
                table: "Weapons",
                column: "ShopInventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "PlayerGladiators");

            migrationBuilder.DropTable(
                name: "ShopInventories");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
