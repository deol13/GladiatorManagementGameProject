using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Service
{
    public interface IPlayerService
    {
        public PlayerGladiator CreateDefaultGladiator(string name);

        public Gladiator CreateOpponent(PlayerGladiator playerGladiator);

        public PlayerGladiator UpdateGladiatorGear(PlayerGladiator gladiator, Gear gear);
        public Player EditAmountOfGold(Player player, int changeInGold);

        public Player EditScore(Player player, int changeInScore);
        public PlayerGladiator LevelUp(PlayerGladiator playerGladiator);

        public bool CanLevelUp(PlayerGladiator gladiator);
    }
}
