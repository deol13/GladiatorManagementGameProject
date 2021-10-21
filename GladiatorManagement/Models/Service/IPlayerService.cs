using GladiatorManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Service
{
    public interface IPlayerService
    {
        private static Player CurrentPlayer;

        public Player CreatePlayer(string name, string email);
        public Player GetCurrentPlayer();
        public Player GetPlayer(int id);
        public Player GetPlayer(string email);
        public Player EditAmountOfGold(Player player, int changeInGold);
        public Player EditScore(Player player, int changeInScore);
        public Player UpdatePlayer();
        public void UpdateCurrentPlayerGladiator(PlayerGladiator playerGladiator);
        public void LoggedOut();

        public PlayerGladiator CreateDefaultGladiator(Player player, string name);
        public PlayerGladiator CreateOpponent(PlayerGladiator playerGladiator);
        public PlayerGladiator FindById(int id);
        public bool RemoveGladiator(PlayerGladiator playerGladiator);
        public PlayerGladiator UpdateGladiatorGear(PlayerGladiator gladiator, Gear gear);

        public PlayerViewModel FindPlayerById(int id);
        
        public PlayerGladiator LevelUp(PlayerGladiator playerGladiator);
        public bool CanLevelUp(PlayerGladiator gladiator);
        public PlayerGladiator AddHealth(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator AddStrength(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator AddAccuracy(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator AddDefence(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator AddXP(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator EditScore(PlayerGladiator playerGladiator, int amount);
    }
}
