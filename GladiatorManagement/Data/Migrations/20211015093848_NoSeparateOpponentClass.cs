using Microsoft.EntityFrameworkCore.Migrations;

namespace GladiatorManagement.Data.Migrations
{
    public partial class NoSeparateOpponentClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gladiators_Armor_ArmorId",
                table: "Gladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_Gladiators_Players_PlayerId1",
                table: "Gladiators");

            migrationBuilder.DropForeignKey(
                name: "FK_Gladiators_Weapon_WeaponId",
                table: "Gladiators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gladiators",
                table: "Gladiators");

            migrationBuilder.DropIndex(
                name: "IX_Gladiators_PlayerId1",
                table: "Gladiators");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Gladiators");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "Gladiators");

            migrationBuilder.RenameTable(
                name: "Gladiators",
                newName: "PlayerGladiators");

            migrationBuilder.RenameIndex(
                name: "IX_Gladiators_WeaponId",
                table: "PlayerGladiators",
                newName: "IX_PlayerGladiators_WeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_Gladiators_ArmorId",
                table: "PlayerGladiators",
                newName: "IX_PlayerGladiators_ArmorId");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "PlayerGladiators",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "PlayerGladiators",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "PlayerGladiators",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlayerGladiators",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "PlayerGladiators",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerGladiators",
                table: "PlayerGladiators",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGladiators_PlayerId",
                table: "PlayerGladiators",
                column: "PlayerId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PK_PlayerGladiators",
                table: "PlayerGladiators");

            migrationBuilder.DropIndex(
                name: "IX_PlayerGladiators_PlayerId",
                table: "PlayerGladiators");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "PlayerGladiators");

            migrationBuilder.RenameTable(
                name: "PlayerGladiators",
                newName: "Gladiators");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGladiators_WeaponId",
                table: "Gladiators",
                newName: "IX_Gladiators_WeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerGladiators_ArmorId",
                table: "Gladiators",
                newName: "IX_Gladiators_ArmorId");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Gladiators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gladiators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Gladiators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Gladiators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Gladiators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId1",
                table: "Gladiators",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gladiators",
                table: "Gladiators",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Gladiators_PlayerId1",
                table: "Gladiators",
                column: "PlayerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Gladiators_Armor_ArmorId",
                table: "Gladiators",
                column: "ArmorId",
                principalTable: "Armor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gladiators_Players_PlayerId1",
                table: "Gladiators",
                column: "PlayerId1",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gladiators_Weapon_WeaponId",
                table: "Gladiators",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
