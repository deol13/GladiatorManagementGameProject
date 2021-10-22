using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Models.Game_logic.GameRepo;
using GladiatorManagement.Models.Repo;
using GladiatorManagement.Models.Service;

namespace GladiatorManagement.Models.Game_logic.GameService
{
    public class GameService : IGameService
    {
        IPlayerService _playerService;
        IGameRepo _gameRepo;
        IArmorRepo _armorRepo;
        IWeaponRepo _weaponRepo;

        public static Shop Shop { get; set; }

        public GameService(IPlayerService playerService, IGameRepo gameRepo, IWeaponRepo weaponRepo, IArmorRepo armorRepo)
        {
            _playerService = playerService;
            _gameRepo = gameRepo;
            _armorRepo = armorRepo;
            _weaponRepo = weaponRepo;
        }

        //Needs to be tweak and improved
        public void LaunchCombat(int playerGladiatorId, int opponentGladiatorId, bool PvP)
        {
            //Setup
            PlayerGladiator player = null;
            PlayerGladiator opponent = null;
            player = _playerService.FindById(playerGladiatorId);
            opponent = _playerService.FindById(opponentGladiatorId);
            Combat combat = new Combat(player, opponent);

            //Start combat & save info
            List<CombatInfo> listOfCombatDetails = combat.StartCombat();
            CombatInfo info = listOfCombatDetails.Last();

            //Work in progress
            if (info.Winner == "Player")
            {
                int gold = HowMuchGoldWon(player.Level);
                _playerService.EditAmountOfGold(player.Player, gold);

                _playerService.LevelUp(player);

                _playerService.RemoveGladiator(opponent);
            }
            else
            {
                if (PvP)
                {
                    int gold = HowMuchGoldWon(opponent.Level);
                    _playerService.EditAmountOfGold(opponent.Player, gold);
                    _playerService.LevelUp(opponent);
                }

                _playerService.RemoveGladiator(player);
            }
        }

        public int HowMuchGoldWon(int lvl)
        {
            int gold = 0;

            if ((lvl - 1) >= 0 && (lvl - 1) < XPAndGoldFormula.GoldToGive.Length)
                gold = XPAndGoldFormula.GoldToGive[lvl - 1];

            return gold;
        }

        public ShopInventory GenerateInventoryForAShop(int lvlOfGladiator, int nrOfGears)
        {
            Gear newGear = null;
            ShopInventory inventory = new ShopInventory();

            for (int i = 0; i < nrOfGears / 2; i++)
            {
                newGear = GenerateGear.GenerateAGearObject("Weapon", lvlOfGladiator);
                newGear = _weaponRepo.Create(newGear as Weapon);
                inventory.WeaponsInShop.Add(newGear as Weapon);
                newGear = null;
            }
            for (int i = 0; i < nrOfGears / 2; i++)
            {
                newGear = GenerateGear.GenerateAGearObject("Armor", lvlOfGladiator);
                newGear = _armorRepo.Create(newGear as Armor);
                inventory.ArmorsInShop.Add(newGear as Armor);
                newGear = null;
            }

            return inventory;
        }

        public ShopInventory CreateAShop(int lvlOfGladiator, int gladiatorId)
        {
            ShopInventory inventory = GenerateInventoryForAShop(lvlOfGladiator, 10);
            inventory.GladiatorId = gladiatorId;

            _gameRepo.SaveShopInventory(inventory);
            Shop.Shops.Add(inventory);

            return inventory;
        }

        public bool RemoveShopInventory(int shopInventoryId)
        {
            bool succeeded = false;
            ShopInventory inventory = FindShopInventory(shopInventoryId);

            Shop.Shops.Remove(inventory);

            foreach (var item in inventory.WeaponsInShop)
            {
                _weaponRepo.Delete(item);
            }
            foreach (var item in inventory.ArmorsInShop)
            {
                _armorRepo.Delete(item);
            }

            succeeded = _gameRepo.RemoveShopInvenotry(inventory);

            return succeeded;
        }

        public ShopInventory FindShopInventory(int shopInventoryId)
        {
            foreach (var item in Shop.Shops)
            {
                if (item.Id == shopInventoryId)
                    return item;
            }

            ShopInventory inv = _gameRepo.FindShopInventory(shopInventoryId);


            if (inv != null)
                Shop.Shops.Add(inv);

            return inv;
        }

        public ShopInventory FindGladiatorsInventory(int gladiatorId)
        {
            foreach (var item in Shop.Shops)
            {
                if (item.GladiatorId == gladiatorId)
                    return item;
            }

            ShopInventory inv = _gameRepo.FindGladiatorsInventory(gladiatorId);
            //for (int i = 0; i < inv.ArmorsInShop.Count; i++)
            //{

            //}
            //for (int i = 0; i < inv.WeaponsInShop.Count; i++)
            //{

            //}

            if (inv != null)
                Shop.Shops.Add(inv);

            return inv;
        }

        /// <summary>
        /// Send ShopInventory inventory in as a ref, changes to it are made.
        /// </summary>
        /// <param name="inventory">Specific inventory gladiator sees</param>
        /// <param name="playersGladiator">The gladiator buying</param>
        /// <param name="idOfItem">The index of the gear in the inventory</param>
        /// <returns></returns>
        public bool BuyAPieceOfGear(ShopInventory inventory, PlayerGladiator playersGladiator, bool weapon, int idOfItem)
        {
            bool succeeded = false;

            if (weapon)
            {
                if (idOfItem >= 0 && idOfItem < inventory.WeaponsInShop.Count)
                {
                    int goldAvailable = playersGladiator.Player.Gold;

                    if (goldAvailable >= inventory.WeaponsInShop[idOfItem].Cost)
                    {
                        //Weapon weap = inventory.WeaponsInShop[idOfItem];
                        //inventory.WeaponsInShop.RemoveAt(idOfItem);
                        //_gameRepo.Update(inventory);


                        //_playerService.EditAmountOfGold(playersGladiator.Player, weap.Cost * -1);
                        //playersGladiator = _playerService.UpdateGladiatorGear(playersGladiator, weap);

                        //succeeded = true;

                        _playerService.EditAmountOfGold(playersGladiator.Player, inventory.WeaponsInShop[idOfItem].Cost * -1);
                        _playerService.UpdateGladiatorGear(playersGladiator, inventory.WeaponsInShop[idOfItem]);

                        inventory.WeaponsInShop.RemoveAt(idOfItem);

                        _gameRepo.Update(inventory);

                        succeeded = true;
                    }
                }
            }
            else
            {
                if (idOfItem >= 0 && idOfItem < inventory.ArmorsInShop.Count)
                {
                    int goldAvailable = playersGladiator.Player.Gold;

                    if (goldAvailable >= inventory.ArmorsInShop[idOfItem].Cost)
                    {
                        _playerService.EditAmountOfGold(playersGladiator.Player, inventory.ArmorsInShop[0].Cost * -1);
                        _playerService.UpdateGladiatorGear(playersGladiator, inventory.ArmorsInShop[idOfItem]);

                        inventory.ArmorsInShop.RemoveAt(idOfItem);

                        _gameRepo.Update(inventory);

                        succeeded = true;
                    }
                }
            }

            return succeeded;
        }

        //public void GetInventoryFromdatabase()
        //{
        //    Shop.Shops = _gameRepo.All();
        //}

        public void CheckDefaultGear()
        {
            if (_weaponRepo.Read(1) == null)
            {
                Weapon weapon = _weaponRepo.Create("Fist", 0, 0, 0);
                PlayerGladiatorRepo.DefaultWId = weapon.Id;

            }
            if (_armorRepo.Read(1) == null)
            {
                Armor armor = _armorRepo.Create("Skin", 0, 0, 0);
                PlayerGladiatorRepo.DefaultAId = armor.Id;
            }
            if (Shop == null)
                Shop = new Shop();
        }

        public void LogOut()
        {
            Shop = null;
        }

        public List<Armor> ReadAllArmor()
        {
            return _armorRepo.Read();
        }
        public List<Weapon> ReadAllWeapon()
        {
            return _weaponRepo.Read();
        }
    }
}
