using GladiatorManagement.Data;
using GladiatorManagement.Models.Repo;
using GladiatorManagement.Models.Game_logic;
using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Service
{
    
    public class PlayerService : IPlayerService
    {
        IPlayerRepo _playerRepo;
        IPlayerGladiatorRepo _playerGladiatorRepo;
        IGladiatorRepo _gladiatorRepo;
        static InfoGenerator generator = new InfoGenerator();

        public PlayerService(IPlayerRepo playerRepo, IPlayerGladiatorRepo playerGladiatorRepo, IGladiatorRepo gladiatorRepo)
        {
            _playerRepo = playerRepo;
            _playerGladiatorRepo = playerGladiatorRepo;
            _gladiatorRepo = gladiatorRepo;
        }


        public PlayerGladiator CreateDefaultGladiator(string name)
        {
            int strength = 1;
            int accuracy = 1;
            int health = 1;
            int defence = 1;

            PlayerGladiator gladiator = _playerGladiatorRepo.Create(name, strength, accuracy, health, defence);

            return gladiator;

        }

        public Gladiator CreateOpponent(PlayerGladiator playerGladiator)
        {
            Random rng = new Random();

            string name = generator.NextString(3, 8);

            int minStr = playerGladiator.Strength - 2;
            int maxStr = playerGladiator.Strength + 3;
            int minAcc = playerGladiator.Accuracy - 2;
            int maxAcc = playerGladiator.Accuracy + 3;
            int minHealth = playerGladiator.Health - 2;
            int maxHealth = playerGladiator.Health + 3;
            int minDef = playerGladiator.Defence - 2;
            int maxDef = playerGladiator.Defence + 3;


            int strength = rng.Next(minStr, maxStr);
            int accuracy = rng.Next(minAcc, maxAcc);
            int health = rng.Next(minHealth, maxHealth);
            int defence = rng.Next(minDef, maxDef);

            return _gladiatorRepo.Create(name, strength, accuracy, health, defence);
        }

        public PlayerGladiator UpdateGladiatorGear(PlayerGladiator gladiator, Gear gear)
        {
            if (gear is Armor) gladiator.Armor = (Armor)gear;
            else if (gear is Weapon) gladiator.Weapon = (Weapon)gear;    
            
            return _playerGladiatorRepo.Update(gladiator);

        }
        
        //send in negative value for changeInGold if you want to decrease amount
        public Player EditAmountOfGold(Player player, int changeInGold)
        {
            player.Gold += changeInGold;
            return _playerRepo.Update(player);

        }

        public Player EditScore(Player player, int changeInScore)
        {
            player.Score += changeInScore;
            return _playerRepo.Update(player);
        }

        public PlayerGladiator LevelUp(PlayerGladiator playerGladiator)
        {
            if (CanLevelUp(playerGladiator))
            {
                playerGladiator.Level++;
                playerGladiator.Experience = 0;
            }
            return _playerGladiatorRepo.Update(playerGladiator);
        }

        public bool CanLevelUp(PlayerGladiator gladiator)
        {
            int maxLevel = XPAndGoldFormula.MaxLvl;
            int XpToLevel = XPAndGoldFormula.XpToLVl[gladiator.Level - 1];

            if (gladiator.Level < maxLevel && gladiator.Experience == XpToLevel) return true;
            else return false;
        }

        public bool RemoveGladiator(PlayerGladiator playerGladiator)
        {
            return _playerGladiatorRepo.Delete(playerGladiator);
        }

        public bool RemoveOpponent(Gladiator gladiator)
        {
            return _gladiatorRepo.Delete(gladiator);
        }



    }
}
