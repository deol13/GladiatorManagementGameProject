using GladiatorManagement.Data;
using GladiatorManagement.Models.Repo;
using GladiatorManagement.Models.Game_logic;
using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Models.ViewModel;

namespace GladiatorManagement.Models.Service
{
    
    public class PlayerService : IPlayerService
    {
        IPlayerRepo _playerRepo;
        IPlayerGladiatorRepo _playerGladiatorRepo;
        IArmorRepo _armorRepo;
        IWeaponRepo _weaponRepo;

        static InfoGenerator generator = new InfoGenerator();
        public static Player CurrentPlayer { get; set; }

        public PlayerService(IPlayerRepo playerRepo, IPlayerGladiatorRepo playerGladiatorRepo, IWeaponRepo weaponRepo, IArmorRepo armorRepo)
        {
            _playerRepo = playerRepo;
            _playerGladiatorRepo = playerGladiatorRepo;
            _armorRepo = armorRepo;
            _weaponRepo = weaponRepo;
        }


        public PlayerGladiator CreateDefaultGladiator(Player player, string name)
        {
            int strength = 5;
            int accuracy = 5;
            int health = 5;
            int defence = 5;

            
            PlayerGladiator gladiator = _playerGladiatorRepo.Create(player, name, strength, accuracy, health, defence);
            player.Gladiators.Add(gladiator);
            _playerRepo.Update(player);

            return gladiator;

        }

        public PlayerGladiator CreateOpponent(PlayerGladiator playerGladiator)
        {
            Random rng = new Random();

            string name = generator.NextUserName();

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

            return _playerGladiatorRepo.Create(null, name, strength, accuracy, health, defence);
        }

        public PlayerGladiator UpdateGladiatorGear(PlayerGladiator gladiator, Gear gear)
        {
            if (gear is Armor)
            {
                _armorRepo.Delete(gladiator.Armor);
                gladiator.Armor = (Armor)gear;
            }
            else if (gear is Weapon)
            {
                _weaponRepo.Delete(gladiator.Weapon);
                gladiator.Weapon = (Weapon)gear;
            }
            
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

        public PlayerViewModel FindPlayerById(int id)
        {
            Player player = _playerRepo.Read(id);
            PlayerViewModel playerVM = new PlayerViewModel
            {
                Player = player,
                Gladiators = player.Gladiators
            };

            return playerVM;

        }
        public PlayerGladiator LevelUp(PlayerGladiator playerGladiator)
        {
            if (playerGladiator.Level >= 0 && playerGladiator.Level < XPAndGoldFormula.MaxLvl)
                playerGladiator.Experience += XPAndGoldFormula.XPToGive[playerGladiator.Level-1];


            if (CanLevelUp(playerGladiator))
            {
                playerGladiator.Experience -= XPAndGoldFormula.XpToLVl[playerGladiator.Level - 1];
                playerGladiator.Level++;
            }
            return _playerGladiatorRepo.Update(playerGladiator);
        }

        public bool CanLevelUp(PlayerGladiator gladiator)
        {
            int maxLevel = XPAndGoldFormula.MaxLvl;
            int XpToLevel = XPAndGoldFormula.XpToLVl[gladiator.Level - 1];

            if (gladiator.Level < maxLevel && gladiator.Experience >= XpToLevel) return true;
            else return false;
        }

        public bool RemoveGladiator(PlayerGladiator playerGladiator)
        {
            return _playerGladiatorRepo.Delete(playerGladiator);
        }

        public PlayerGladiator AddHealth(PlayerGladiator playerGladiator, int amount)
        {
            playerGladiator.Health += amount;
            return _playerGladiatorRepo.Update(playerGladiator);
        }

        public PlayerGladiator AddStrength(PlayerGladiator playerGladiator, int amount)
        {
            playerGladiator.Strength += amount;
            return _playerGladiatorRepo.Update(playerGladiator);
        }
         
        public PlayerGladiator AddAccuracy(PlayerGladiator playerGladiator, int amount)
        {
            playerGladiator.Accuracy += amount;
            return _playerGladiatorRepo.Update(playerGladiator);
        }
        public PlayerGladiator AddDefence(PlayerGladiator playerGladiator, int amount)
        {
            playerGladiator.Defence += amount;
            return _playerGladiatorRepo.Update(playerGladiator);
        }
        public PlayerGladiator AddXP(PlayerGladiator playerGladiator, int amount)
        {
            playerGladiator.Experience += amount;
            return _playerGladiatorRepo.Update(playerGladiator);
        }
        public PlayerGladiator EditScore(PlayerGladiator playerGladiator, int amount)
        {
            playerGladiator.Score += amount;
            return _playerGladiatorRepo.Update(playerGladiator);
        }

        public PlayerGladiator FindById(int id)
        {
            return _playerGladiatorRepo.Read(id);
        }

        public Player GetPlayer(int id)
        {
            if(CurrentPlayer == null || CurrentPlayer.PlayerId != id)
                CurrentPlayer = _playerRepo.Read(id);
            return CurrentPlayer;
        }

        public Player GetPlayer(string email)
        {
            if (CurrentPlayer == null ||CurrentPlayer.EmailVerification != email)
                CurrentPlayer = _playerRepo.Read(email);
            return CurrentPlayer;
        }

        public Player CreatePlayer(string name, string email)
        {
            CurrentPlayer = _playerRepo.Create(name, email);
            return CurrentPlayer;
        }

        public void LoggedOut()
        {
            CurrentPlayer = null;
        }
    }
}
