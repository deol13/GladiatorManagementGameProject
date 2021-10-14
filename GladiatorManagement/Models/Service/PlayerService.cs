using GladiatorManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Service
{
    
    public class PlayerService
    {
        PlayerRepo _playerRepo;
        PlayerGladiatorRepo _gladiatorRepo;

        public PlayerService(PlayerRepo playerRepo, PlayerGladiatorRepo gladiatorRepo)
        {
            _playerRepo = playerRepo;
            _gladiatorRepo = gladiatorRepo;
        }


        public PlayerGladiator CreateDefaultGladiator(string name)
        {
            int strength = 1;
            int accuracy = 1;
            int health = 1;
            int defence = 1;

            PlayerGladiator gladiator = _gladiatorRepo.Create(name, strength, accuracy, health, defence);

            return gladiator;

        }

        public PlayerGladiator UpdateGladiatorGear(PlayerGladiator gladiator, Gear gear)
        {
            if (gear is Armor) gladiator.Armor = (Armor)gear;
            else if (gear is Weapon) gladiator.Weapon = (Weapon)gear;    
            
            return _gladiatorRepo.Update(gladiator);

        }
        
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
            playerGladiator.Level++;
            return _gladiatorRepo.Update(playerGladiator);
        }


    }
}
