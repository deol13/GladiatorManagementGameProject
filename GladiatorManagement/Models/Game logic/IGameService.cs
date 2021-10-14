﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public interface IGameService
    {
        public void LaunchCombat(int playerGladiatorId, int opponentGladiatorId);
        public int HowMuchGoldWon(int lvl);
        public ShopInventory GenerateInventoryForAShop(ShopInventory inventory, int lvlOfGladiator, int nrOfGears);
    }
}
