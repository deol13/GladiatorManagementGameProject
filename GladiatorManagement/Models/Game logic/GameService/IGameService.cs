using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic.GameService
{
    public interface IGameService
    {
        public static Shop Shop { get; set; }

        public List<CombatInfo> LaunchCombat(PlayerGladiator player, PlayerGladiator opponent, bool PvP);
        public int HowMuchGoldWon(int lvl);
        public ShopInventory GenerateInventoryForAShop(ShopInventory inventory, int lvlOfGladiator, int nrOfGears);

        public ShopInventory CreateAShop(int lvlOfGladiator, int gladiatorId);

        public bool RemoveShopInventory(int shopInventoryId, bool belongToAGlad);

        public ShopInventory FindShopInventory(int id, bool belongToAGladiator);

        public ShopInventory GladLvledUp(PlayerGladiator glad);

        public bool BuyAPieceOfGear(ShopInventory inventory, PlayerGladiator playersGladiator, bool weapon, int idOfItem);
        public void CheckDefaultGear();
        public void LogOut();
        public List<Armor> ReadAllArmor();
        public List<Weapon> ReadAllWeapon();

        public void RemoveFalledGladiatorsGear(PlayerGladiator gladiator);

        public Weapon FindWeapon(int id);
        public Armor FindArmor(int id);
    }
}
