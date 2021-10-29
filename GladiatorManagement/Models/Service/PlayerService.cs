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
            gladiator.Player = player;
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
                Armor deletThis = gladiator.Armor;
                gladiator.Armor = (Armor)gear;
                gladiator.ArmorID = gear.Id;
                gladiator = _playerGladiatorRepo.Update(gladiator);

                _armorRepo.Delete(deletThis);
            }
            else if (gear is Weapon)
            {
                Weapon deletThis = gladiator.Weapon;
                gladiator.Weapon = (Weapon)gear;
                gladiator.WeaponID = gear.Id;
                gladiator = _playerGladiatorRepo.Update(gladiator);

                _weaponRepo.Delete(deletThis);
            }

            for (int i = 0; i < CurrentPlayer.Gladiators.Count; i++)
            {
                if (CurrentPlayer.Gladiators[i].Id == gladiator.Id)
                    CurrentPlayer.Gladiators[i] = gladiator;
            }

            return gladiator;

            //if (gear is Armor)
            //{
            //    _armorRepo.Delete(gladiator.Armor);
            //    gladiator.Armor = (Armor)gear;
            //    gladiator.ArmorID = gear.Id;
            //}
            //else if (gear is Weapon)
            //{
            //    _weaponRepo.Delete(gladiator.Weapon);
            //    gladiator.Weapon = (Weapon)gear;
            //    gladiator.WeaponID = gear.Id;
            //}

            //return _playerGladiatorRepo.Update(gladiator);

        }

        /// <summary>
        /// Return all gladiators that doesn't belong to the playerId
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public List<PlayerGladiator> GetListOfEnemyGlad(int playerId)
        {
            return _playerGladiatorRepo.ReadEnemyGlad(playerId);
        }

        //send in negative value for changeInGold if you want to decrease amount
        public Player EditAmountOfGold(Player player, int changeInGold)
        {
            player.Gold += changeInGold;
            player = _playerRepo.Update(player);

            if (player.PlayerId == CurrentPlayer.PlayerId)
                CurrentPlayer.Gold = player.Gold;

            return player;
        }

        public Player EditScore(Player player, int changeInScore)
        {
            player.Score += changeInScore;
            player =  _playerRepo.Update(player);

            if (player.PlayerId == CurrentPlayer.PlayerId)
                CurrentPlayer.Score = player.Score;

            return player;
        }

        public PlayerViewModel FindPlayerById(int id)
        {
            PlayerViewModel playerVM = null;
            //Player player = _playerRepo.Read(id);
            Player player = null;
            if (CurrentPlayer != null)
                if(CurrentPlayer.PlayerId == id || id == 0)
                    player = CurrentPlayer;

            if(player == null)
                player = _playerRepo.Read(id);
            if (player != null)
            {
                playerVM = new PlayerViewModel
                {
                    Player = player,
                    Gladiators = player.Gladiators
                };
            }

            return playerVM;

        }
        public PlayerGladiator LevelUp(PlayerGladiator playerGladiator, ref bool lvledUp)
        {
            if (playerGladiator.Level >= 0 && playerGladiator.Level < XPAndGoldFormula.MaxLvl)
                playerGladiator.Experience += XPAndGoldFormula.XPToGive[playerGladiator.Level-1];

            lvledUp = CanLevelUp(playerGladiator);
            if (lvledUp)
            {
                playerGladiator.Experience -= XPAndGoldFormula.XpToLVl[playerGladiator.Level - 1];
                playerGladiator.Level++;
            }

            //Keep currentPlayer updated
            for (int i = 0; i < CurrentPlayer.Gladiators.Count; i++)
            {
                if(CurrentPlayer.Gladiators[i].Id == playerGladiator.Id)
                {
                    CurrentPlayer.Gladiators[i].Level = playerGladiator.Level;
                    CurrentPlayer.Gladiators[i].Experience = playerGladiator.Experience;
                }
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
            for (int i = 0; i < CurrentPlayer.Gladiators.Count; i++)
            {
                if (CurrentPlayer.Gladiators[i].Id == id)
                {
                    return CurrentPlayer.Gladiators[i];
                }
            }


            PlayerGladiator gladiator = _playerGladiatorRepo.Read(id);
            if (gladiator != null)
            {
                gladiator.Player = GetPlayer((int)gladiator.PlayerId);
                gladiator.Weapon = _weaponRepo.Read((int)gladiator.WeaponID);
                gladiator.Armor = _armorRepo.Read((int)gladiator.ArmorID);
            }
            return gladiator;
        }

        public Player GetPlayer(int id)
        {
            Player opponent = _playerRepo.Read(id);
            if (opponent != null)
            {
                opponent.Gladiators = _playerGladiatorRepo.ReadRelatedToPlayer(opponent.PlayerId);
                for (int i = 0; i < opponent.Gladiators.Count; i++)
                {
                    opponent.Gladiators[i].Armor = _armorRepo.Read((int)opponent.Gladiators[i].ArmorID);
                    opponent.Gladiators[i].Weapon = _weaponRepo.Read((int)opponent.Gladiators[i].WeaponID);
                }
            }

            //Collect specific gladiator
            return opponent;
        }

        public Player GetPlayer(string email)
        {
            if (CurrentPlayer == null || CurrentPlayer.EmailVerification != email)
            {
                _armorRepo.Read();
                _weaponRepo.Read();

                CurrentPlayer = _playerRepo.Read(email);
                CurrentPlayer.Gladiators = _playerGladiatorRepo.ReadRelatedToPlayer(CurrentPlayer.PlayerId);
             
                for (int i = 0; i < CurrentPlayer.Gladiators.Count; i++)
                {
                    CurrentPlayer.Gladiators[i].Armor = _armorRepo.Read((int)CurrentPlayer.Gladiators[i].ArmorID);
                    CurrentPlayer.Gladiators[i].Weapon = _weaponRepo.Read((int)CurrentPlayer.Gladiators[i].WeaponID);
                }
            }
            return CurrentPlayer;
        }
        public Player GetCurrentPlayer()
        {
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
