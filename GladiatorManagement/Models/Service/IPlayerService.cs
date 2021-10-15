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


        public bool RemoveGladiator(PlayerGladiator playerGladiator);

        public bool RemoveOpponent(Gladiator gladiator);

        public PlayerGladiator AddHealth(PlayerGladiator playerGladiator, int amount);

        public PlayerGladiator AddStrength(PlayerGladiator playerGladiator, int amount);

        public PlayerGladiator AddAccuracy(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator AddDefence(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator AddXP(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator EditScore(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator FindById(int id);
        public Gladiator FindOpponentById(int id);



    }
}
