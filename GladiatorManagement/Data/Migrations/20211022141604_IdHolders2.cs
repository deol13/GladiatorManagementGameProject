using Microsoft.EntityFrameworkCore.Migrations;

namespace GladiatorManagement.Data.Migrations
{
    public partial class IdHolders2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorId",
                table: "PlayerGladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponId",
                table: "PlayerGladiators");

            migrationBuilder.RenameColumn(
                name: "WeaponId",
                table: "PlayerGladiators",
                newName: "WeaponID");

            migrationBuilder.RenameColumn(
                name: "ArmorId",
                table: "PlayerGladiators",
                newName: "ArmorID");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGladiators_WeaponId",
                table: "PlayerGladiators",
                newName: "IX_PlayerGladiators_WeaponID");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGladiators_ArmorId",
                table: "PlayerGladiators",
                newName: "IX_PlayerGladiators_ArmorID");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponID",
                table: "PlayerGladiators",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArmorID",
                table: "PlayerGladiators",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorID",
                table: "PlayerGladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponID",
                table: "PlayerGladiators");

            migrationBuilder.RenameColumn(
                name: "WeaponID",
                table: "PlayerGladiators",
                newName: "WeaponId");

            migrationBuilder.RenameColumn(
                name: "ArmorID",
                table: "PlayerGladiators",
                newName: "ArmorId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGladiators_WeaponID",
                table: "PlayerGladiators",
                newName: "IX_PlayerGladiators_WeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGladiators_ArmorID",
                table: "PlayerGladiators",
                newName: "IX_PlayerGladiators_ArmorId");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponId",
                table: "PlayerGladiators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArmorId",
                table: "PlayerGladiators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Armors_ArmorId",
                table: "PlayerGladiators",
                column: "ArmorId",
                principalTable: "Armors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerGladiators_Weapons_WeaponId",
                table: "PlayerGladiators",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
