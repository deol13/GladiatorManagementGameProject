using Microsoft.EntityFrameworkCore.Migrations;

namespace GladiatorManagement.Data.Migrations
{
    public partial class NullablePlayerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Armor_ArmorId",
                table: "PlayerGladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Players_PlayerId",
                table: "PlayerGladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Weapon_WeaponId",
                table: "PlayerGladiators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Armor",
                table: "Armor");

            migrationBuilder.RenameTable(
                name: "Weapon",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "Armor",
                newName: "Armors");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerGladiators",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Armors",
                table: "Armors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorId",
                table: "PlayerGladiators",
                column: "ArmorId",
                principalTable: "Armors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Players_PlayerId",
                table: "PlayerGladiators",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponId",
                table: "PlayerGladiators",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorId",
                table: "PlayerGladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Players_PlayerId",
                table: "PlayerGladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponId",
                table: "PlayerGladiators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Armors",
                table: "Armors");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "Weapon");

            migrationBuilder.RenameTable(
                name: "Armors",
                newName: "Armor");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerGladiators",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Armor",
                table: "Armor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Armor_ArmorId",
                table: "PlayerGladiators",
                column: "ArmorId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Players_PlayerId",
                table: "PlayerGladiators",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Weapon_WeaponId",
                table: "PlayerGladiators",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
