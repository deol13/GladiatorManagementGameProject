﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public interface IGameService
    {
        public void LaunchCombat(int playerGladiatorId, int opponentGladiatorId, bool PvP);
        public int HowMuchGoldWon(int lvl);
        public ShopInventory GenerateInventoryForAShop(int lvlOfGladiator, int nrOfGears);

        public ShopInventory CreateAShop(int lvlOfGladiator);

        public bool BuyAPieceOfGear(ShopInventory inventory, PlayerGladiator playersGladiator, int idOfItem);
    }
}
