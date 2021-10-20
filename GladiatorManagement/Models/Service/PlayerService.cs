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
        //Variables
        IPlayerRepo _playerRepo;
        IPlayerGladiatorRepo _playerGladiatorRepo;
        IArmorRepo _armorRepo;
        IWeaponRepo _weaponRepo;

        static InfoGenerator generator = new InfoGenerator();
        public static Player CurrentPlayer { get; set; }

        //Constructor
        public PlayerService(IPlayerRepo playerRepo, IPlayerGladiatorRepo playerGladiatorRepo, IWeaponRepo weaponRepo, IArmorRepo armorRepo)
        {
            _playerRepo = playerRepo;
            _playerGladiatorRepo = playerGladiatorRepo;
            _armorRepo = armorRepo;
            _weaponRepo = weaponRepo;
        }

        //Player object
        public Player CreatePlayer(string name, string email)
        {
            CurrentPlayer = _playerRepo.Create(name, email);
            return CurrentPlayer;
        }
        /// <summary>
        /// Used to get opponent Player object in PVP
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Player GetPlayer(int id)
        {
            return _playerRepo.Read(id);

            //if (CurrentPlayer == null || CurrentPlayer.PlayerId != id)
            //    CurrentPlayer = _playerRepo.Read(id);
            //return CurrentPlayer;
        }
        /// <summary>
        /// Used by register and login
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Player GetPlayer(string email)
        {
            if (CurrentPlayer == null || CurrentPlayer.EmailVerification != email)
                CurrentPlayer = _playerRepo.Read(email);

            if (CurrentPlayer.Gladiators == null)
                CurrentPlayer.Gladiators = new List<PlayerGladiator>();

            return CurrentPlayer;
        }
        public PlayerViewModel FindPlayerById(int id)
        {
            Player player = null;
            if (CurrentPlayer.PlayerId != id)
                player = _playerRepo.Read(id);
            else
                player = CurrentPlayer;

            PlayerViewModel playerVM = new PlayerViewModel
            {
                Player = player,
                Gladiators = player.Gladiators
            };

            return playerVM;

        }
        //send in negative value for changeInGold if you want to decrease amount
        public Player EditAmountOfGold(Player player, int changeInGold)
        {
            CurrentPlayer.Gold += changeInGold;
            return _playerRepo.Update(CurrentPlayer);
        }
        public Player EditScore(Player player, int changeInScore)
        {
            player.Score += changeInScore;
            return _playerRepo.Update(player);
        }
        /// <summary>
        /// Not sure if I should remove it
        /// </summary>
        /// <returns></returns>
        public Player UpdatePlayer()
        {
            return _playerRepo.Update(CurrentPlayer);
        }
        /// <summary>
        /// Send in an existing gladiator and update currentPlayer's version of that gladiator.
        /// Used after finishing updating a gladiator
        /// </summary>
        /// <param name="gladiator"></param>
        public void UpdateCurrentPlayerGladiator(PlayerGladiator gladiator)
        {
            for (int i = 0; i < CurrentPlayer.Gladiators.Count; i++)
            {
                if (CurrentPlayer.Gladiators[i].Id == gladiator.Id)
                {
                    CurrentPlayer.Gladiators[i] = gladiator;
                }
            }
        }
        public void LoggedOut()
        {
            CurrentPlayer = null;
        }

        
                    
        //PlayerGladiator Object
        public PlayerGladiator CreateDefaultGladiator(Player player, string name)
        {
            int strength = 5;
            int accuracy = 5;
            int health = 5;
            int defence = 5;

            
            PlayerGladiator gladiator = _playerGladiatorRepo.Create(player, name, strength, accuracy, health, defence);
            CurrentPlayer.Gladiators.Add(gladiator);
            _playerRepo.Update(CurrentPlayer);

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
        public PlayerGladiator FindById(int id)
        {
            foreach (var item in CurrentPlayer.Gladiators)
            {
                if (item.Id == id)
                    return item;
            }
            return _playerGladiatorRepo.Read(id);
        }
        public bool RemoveGladiator(PlayerGladiator playerGladiator)
        {
            foreach (var item in CurrentPlayer.Gladiators)
            {
                if (item.Id == playerGladiator.Id)
                {
                    CurrentPlayer.Gladiators.Remove(item);
                    return _playerGladiatorRepo.Delete(playerGladiator);
                }
            }

            return _playerGladiatorRepo.Delete(playerGladiator);
        }
        public PlayerGladiator UpdateGladiatorGear(PlayerGladiator gladiator, Gear gear)
        {
            if (gear is Armor)
            {
                Armor tmp = gladiator.Armor;
                gladiator.Armor = (Armor)gear;
                gladiator = _playerGladiatorRepo.Update(gladiator);
                _armorRepo.Delete(tmp);
            }
            else if (gear is Weapon)
            {
                Weapon tmp = gladiator.Weapon;
                gladiator.Weapon = (Weapon)gear;
                gladiator = _playerGladiatorRepo.Update(gladiator);
                _weaponRepo.Delete(tmp);
            }

            return gladiator;
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
    }
}
