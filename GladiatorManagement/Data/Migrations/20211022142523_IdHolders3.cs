using Microsoft.EntityFrameworkCore.Migrations;

namespace GladiatorManagement.Data.Migrations
{
    public partial class IdHolders3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorID",
                table: "PlayerGladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponID",
                table: "PlayerGladiators");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponID",
                table: "PlayerGladiators",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArmorID",
                table: "PlayerGladiators",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorID",
                table: "PlayerGladiators",
                column: "ArmorID",
                principalTable: "Armors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponID",
                table: "PlayerGladiators",
                column: "WeaponID",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorID",
                table: "PlayerGladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponID",
                table: "PlayerGladiators");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponID",
                table: "PlayerGladiators",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArmorID",
                table: "PlayerGladiators",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorID",
                table: "PlayerGladiators",
                column: "ArmorID",
                principalTable: "Armors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponID",
                table: "PlayerGladiators",
                column: "WeaponID",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
