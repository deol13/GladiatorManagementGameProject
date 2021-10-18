﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public interface IGameService
    {
        public Shop Shop { get; set; }

        public void GetInventoryFromdatabase();

        public void LaunchCombat(int playerGladiatorId, int opponentGladiatorId, bool PvP);
        public int HowMuchGoldWon(int lvl);
        public ShopInventory GenerateInventoryForAShop(int lvlOfGladiator, int nrOfGears);

        public ShopInventory CreateAShop(int lvlOfGladiator, int gladiatorId);

        public bool RemoveShopInventory(int shopInventoryId);

        public ShopInventory FindShopInventory(int id);

        public bool BuyAPieceOfGear(ShopInventory inventory, PlayerGladiator playersGladiator, bool weapon, int idOfItem);
    }
}