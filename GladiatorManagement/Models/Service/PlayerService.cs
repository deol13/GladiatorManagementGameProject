﻿using GladiatorManagement.Data;
using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Service
{
    
    public class PlayerService
    {
        PlayerRepo _playerRepo;
        PlayerGladiatorRepo _playerGladiatorRepo;
        GladiatorRepo _gladiatorRepo;
        static InfoGenerator generator = new InfoGenerator();

        public PlayerService(PlayerRepo playerRepo, PlayerGladiatorRepo playerGladiatorRepo, GladiatorRepo gladiatorRepo)
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
            if (canLevelUp(playerGladiator)) playerGladiator.Level++;
            return _playerGladiatorRepo.Update(playerGladiator);
        }

        public bool canLevelUp(PlayerGladiator gladiator)
        {
            return true;
        }


    }
}
