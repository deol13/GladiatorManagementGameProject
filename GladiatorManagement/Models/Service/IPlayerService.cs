using GladiatorManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Service
{
    public interface IPlayerService
    {
        public static Player CurrentPlayer { get; set; }

        public Player CreatePlayer(string name, string email);
        public Player GetPlayer(int id);
        public Player GetPlayer(string email);
        public Player GetCurrentPlayer();

        public PlayerGladiator UpdateGladiator(PlayerGladiator gladiator);
        public PlayerGladiator CreateDefaultGladiator(Player player, string name);

        public PlayerGladiator CreateOpponent(PlayerGladiator playerGladiator);

        public PlayerGladiator UpdateGladiatorGear(PlayerGladiator gladiator, Gear gear);

        public List<PlayerGladiator> GetListOfEnemyGlad(int gladiatorId);

        public HighScoreViewModel GetHighScore();

        public Player EditAmountOfGold(Player player, int changeInGold);

        public PlayerGladiator EditScore(ref Player player,  PlayerGladiator glad, int changeInScore);
        public PlayerGladiator LevelUp(PlayerGladiator playerGladiator, ref bool lvledUp);

        public bool CanLevelUp(PlayerGladiator gladiator);

        public PlayerViewModel FindPlayerById(int id);


        public bool RemoveGladiator(PlayerGladiator playerGladiator);

        public PlayerGladiator AddHealth(PlayerGladiator playerGladiator, int amount);

        public PlayerGladiator AddStrength(PlayerGladiator playerGladiator, int amount);

        public PlayerGladiator AddAccuracy(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator AddDefence(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator AddXP(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator EditScore(PlayerGladiator playerGladiator, int amount);
        public PlayerGladiator FindById(int id);
        public void LoggedOut();

        public PlayerGladiator CreateGladiator(CreateGladiatorViewModel createGladiatorViewModel);


    }
}
