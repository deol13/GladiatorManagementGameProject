using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Models.Service;

namespace GladiatorManagement.Models.Game_logic
{
    public class GameService : IGameService
    {
        IPlayerService _playerService;

        public GameService(IPlayerService playerService)
        {
            _playerService = playerService;
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
                inventory.GearsInShop.Add(newGear);
                newGear = null;
            }
            for (int i = 0; i < nrOfGears / 2; i++)
            {
                newGear = GenerateGear.GenerateAGearObject("Armor", lvlOfGladiator);
                inventory.GearsInShop.Add(newGear);
                newGear = null;
            }

            return inventory;
        }

        public ShopInventory CreateAShop(int lvlOfGladiator)
        {

            ShopInventory inventory = GenerateInventoryForAShop(lvlOfGladiator, 10);

            return inventory;
        }

        /// <summary>
        /// Send ShopInventory inventory in as a ref, changes to it are made.
        /// </summary>
        /// <param name="inventory">Specific inventory gladiator sees</param>
        /// <param name="playersGladiator">The gladiator buying</param>
        /// <param name="idOfItem">The index of the gear in the inventory</param>
        /// <returns></returns>
        public bool BuyAPieceOfGear(ShopInventory inventory, PlayerGladiator playersGladiator, int idOfItem)
        {
            bool succeeded = false;

            if (idOfItem >= 0 && idOfItem < inventory.GearsInShop.Count)
            {
                int goldAvailable = playersGladiator.Player.Gold;

                if (goldAvailable >= inventory.GearsInShop[idOfItem].Cost)
                {
                    _playerService.EditAmountOfGold(playersGladiator.Player, inventory.GearsInShop[0].Cost * -1);
                    _playerService.UpdateGladiatorGear(playersGladiator, inventory.GearsInShop[idOfItem]);

                    inventory.GearsInShop.RemoveAt(idOfItem);

                    succeeded = true;
                }

            }

            return succeeded;
        }
    }
}
