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

        //Make a view model and return it, it contains listOfCombatDetails, player, gladiator and pvp?
        public List<CombatInfo> LaunchCombat(PlayerGladiator player, PlayerGladiator opponent, bool PvP)
        {
            //Setup
            Combat combat = new Combat(player, opponent);

            //Start combat & save info
            List<CombatInfo> listOfCombatDetails = combat.StartCombat();
            CombatInfo info = listOfCombatDetails.Last();

            //Work in progress
            if (info.Winner == "Player")
            {
                bool lvledUp = false;
                int gold = HowMuchGoldWon(player.Level);
                _playerService.EditAmountOfGold(player.Player, gold);
                //Add score _playerService.EditScore();
                //For both player and glad
                _playerService.LevelUp(player, ref lvledUp);

                RemoveFalledGladiatorsGear(opponent);

                if (lvledUp)
                    GladLvledUp(player);

                Player currPlayer = _playerService.GetCurrentPlayer();
                for (int i = 0; i < currPlayer.Gladiators.Count; i++)
                {
                    if(player.Id == currPlayer.Gladiators[i].Id)
                        currPlayer.Gladiators[i] = player;
                }
                //Kolla om player hos glad uppdaterades auto
            }
            else
            {
                if (PvP)
                {
                    bool lvledUp = false;
                    int gold = HowMuchGoldWon(opponent.Level);
                    _playerService.EditAmountOfGold(opponent.Player, gold);
                    //Add score _playerService.EditScore();
                    //For both player and glad
                    _playerService.LevelUp(opponent, ref lvledUp);

                    if (lvledUp)
                        GladLvledUp(opponent);
                }

                RemoveFalledGladiatorsGear(player);
                Player currPlayer = _playerService.GetCurrentPlayer(); //kolla om glad tas bort
            }

            return listOfCombatDetails;
        }

        public void RemoveFalledGladiatorsGear(PlayerGladiator gladiator)
        {
            Armor armor = gladiator.Armor;
            Weapon weapon = gladiator.Weapon;
            _playerService.RemoveGladiator(gladiator);
            _armorRepo.Delete(armor);
            _weaponRepo.Delete(weapon);
        }

        public int HowMuchGoldWon(int lvl)
        {
            int gold = 0;

            if ((lvl - 1) >= 0 && (lvl - 1) < XPAndGoldFormula.GoldToGive.Length)
                gold = XPAndGoldFormula.GoldToGive[lvl - 1];

            return gold;
        }

        public ShopInventory GenerateInventoryForAShop(ShopInventory inventory, int lvlOfGladiator, int nrOfGears)
        {
            Gear newGear = null;

            for (int i = 0; i < nrOfGears / 2; i++)
            {
                newGear = GenerateGear.GenerateAGearObject("Weapon", lvlOfGladiator);
                Weapon newW = newGear as Weapon;
                newW.ShopInventoryId = inventory.Id;

                newW = _weaponRepo.Create(newW);
                //inventory.WeaponsInShop.Add(newW);
                newGear = null;
                newW = null;
            }
            for (int i = 0; i < nrOfGears / 2; i++)
            {
                newGear = GenerateGear.GenerateAGearObject("Armor", lvlOfGladiator);
                Armor newA = newGear as Armor;
                newA.ShopInventoryId = inventory.Id;

                newA = _armorRepo.Create(newA);
                //inventory.ArmorsInShop.Add(newA);
                newGear = null;
                newA = null;
            }

            return inventory;
        }

        public ShopInventory CreateAShop(int lvlOfGladiator, int gladiatorId)
        {
            ShopInventory inventory = new ShopInventory();
            inventory.GladiatorId = gladiatorId;
            inventory = _gameRepo.SaveShopInventory(inventory);
            
            inventory = GenerateInventoryForAShop(inventory, lvlOfGladiator, 10);

            _gameRepo.Update(inventory);
            Shop.Shops.Add(inventory);

            return inventory;
        }

        //public ShopInventory CreateAShop(int lvlOfGladiator, int gladiatorId)
        //{

        //    ShopInventory inventory = GenerateInventoryForAShop(lvlOfGladiator, 10);
        //    inventory.GladiatorId = gladiatorId;

        //    _gameRepo.SaveShopInventory(inventory);
        //    Shop.Shops.Add(inventory);

        //    return inventory;
        //}

        public bool RemoveShopInventory(int shopInventoryId, bool belongToAGlad)
        {
            //bool succeeded = false;
            //ShopInventory inventory = FindShopInventory(shopInventoryId, false);

            //Shop.Shops.Remove(inventory);

            //foreach (var item in inventory.WeaponsInShop)
            //{
            //    _weaponRepo.Delete(item);
            //}
            //foreach (var item in inventory.ArmorsInShop)
            //{
            //    _armorRepo.Delete(item);
            //}

            //succeeded = _gameRepo.RemoveShopInvenotry(inventory);

            //return succeeded;
            bool succeeded = false;
            ShopInventory inventory = FindShopInventory(shopInventoryId, belongToAGlad);

            if (inventory != null)
            {
                _weaponRepo.DeleteAll(inventory);
                _armorRepo.DeleteAll(inventory);

                Shop.Shops.Remove(inventory);
                succeeded = _gameRepo.RemoveShopInvenotry(inventory);
            }

            return succeeded;
        }

        public ShopInventory FindShopInventory(int inventoryId, bool belongToAGladiator)
        {
            ShopInventory inv;

            if (belongToAGladiator)
            {
                foreach (var item in Shop.Shops)
                {
                    if (item.GladiatorId == inventoryId)
                        return item;
                }

                inv = _gameRepo.FindGladiatorsInventory(inventoryId);
            }
            else
            {
                foreach (var item in Shop.Shops)
                {
                    if (item.Id == inventoryId)
                        return item;
                }

                inv = _gameRepo.FindShopInventory(inventoryId);
            }

            inv.WeaponsInShop = _weaponRepo.ReadAllInventory(inv.Id);
            inv.ArmorsInShop = _armorRepo.ReadAllInventory(inv.Id);

            if (inv != null)
                Shop.Shops.Add(inv);

            return inv;
        }

        public ShopInventory GladLvledUp(PlayerGladiator glad)
        {
            if (glad.InventoryId > 0)
            {
                RemoveShopInventory(glad.InventoryId, true);
                ShopInventory inv = CreateAShop(glad.Level, glad.Id);
                glad.InventoryId = inv.Id;
            }

            return null;
        }

        //public ShopInventory FindGladiatorsInventory(int gladiatorId)
        //{
        //    foreach (var item in Shop.Shops)
        //    {
        //        if (item.GladiatorId == gladiatorId)
        //            return item;
        //    }

        //    ShopInventory inv = _gameRepo.FindGladiatorsInventory(gladiatorId);
        //    inv = ReadGearToShop(inv);

        //    if (inv != null)
        //        Shop.Shops.Add(inv);

        //    return inv;
        //}

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
                    Weapon buyingThis = inventory.WeaponsInShop[idOfItem];

                    if (goldAvailable >= buyingThis.Cost)
                    {
                        _playerService.EditAmountOfGold(playersGladiator.Player, buyingThis.Cost * -1);
                        _playerService.UpdateGladiatorGear(playersGladiator, buyingThis);

                        //inventory.WeaponsInShop.RemoveAt(idOfItem);
                        bool removed = inventory.WeaponsInShop.Remove(buyingThis);

                        if(removed)
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
                    Armor buyingThis = inventory.ArmorsInShop[idOfItem];

                    if (goldAvailable >= buyingThis.Cost)
                    {
                        _playerService.EditAmountOfGold(playersGladiator.Player, buyingThis.Cost * -1);
                        _playerService.UpdateGladiatorGear(playersGladiator, buyingThis);

                        bool removed = inventory.ArmorsInShop.Remove(buyingThis);

                        if (removed)
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
            //if (_weaponRepo.Read(1) == null)
            //{
            //    Weapon weapon = _weaponRepo.Create("Fist", 0, 0, 0);
            //    PlayerGladiatorRepo.DefaultWId = weapon.Id;

            //}
            //if (_armorRepo.Read(1) == null)
            //{
            //    Armor armor = _armorRepo.Create("Skin", 0, 0, 0);
            //    PlayerGladiatorRepo.DefaultAId = armor.Id;
            //}
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
