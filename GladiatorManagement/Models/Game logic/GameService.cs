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
        //public void LaunchCombat(int playerGladiatorId, int opponentGladiatorId)
        //{
        //    Gladiator player = null;
        //    Gladiator opponent = null;

        //    player = new PlayerGladiator("Dennis", 5, 5, 10, 2);
        //    opponent = new Gladiator("Jojje", 5, 6, 11, 3);

        //    player = FindGladiator(playerGladiatorId);
        //    opponent = FindGladiator(opponentGladiatorId);


        //    PlayerGladiator p = player as PlayerGladiator;
        //    PlayerGladiator o = opponent as PlayerGladiator;

        //    Combat combat = null;

        //    //Player should always be of PlayerGladiator so maybe the first if-statement can be removed
        //    if (p != null)
        //    {
        //        p.Weapon.Strength += 1;
        //        p.Weapon.Accuracy += 1;
        //        p.Armor.Defence += 1;
        //        p.Armor.Health += 1;

        //        player.Strength += p.Weapon.Strength;
        //        player.Accuracy += p.Weapon.Accuracy;
        //        player.Defence += p.Armor.Defence;
        //        player.Health += p.Armor.Health;
        //    }
        //    if (o != null)
        //    {
        //        opponent.Strength += o.Weapon.Strength;
        //        opponent.Accuracy += o.Weapon.Accuracy;
        //        opponent.Defence += o.Armor.Defence;
        //        opponent.Health += o.Armor.Health;
        //    }

        //    combat = new Combat(player, opponent);

        //    List<CombatInfo> listOfCombatDetails = combat.StartCombat();

        //    CombatInfo info = listOfCombatDetails.Last();


        //    if (p != null)
        //    {
        //        player.Strength -= p.Weapon.Strength;
        //        player.Accuracy -= p.Weapon.Accuracy;
        //        player.Defence -= p.Armor.Defence;
        //        player.Health -= p.Armor.Health;

        //        //Work in progress
        //        if (info.Winner == "Player")
        //        {
        //            int gold = HowMuchGoldWon(p.Level);
        //            _playerService.EditAmountOfGold(p.Player, gold);

        //            _playerService.LevelUp(p);

        //            if (o == null)
        //                _playerService.RemoveOpponent(opponent);
        //            else
        //                _playerService.RemoveGladiator(o);
        //        }
        //    }
        //    if (o != null)
        //    {
        //        opponent.Strength -= o.Weapon.Strength;
        //        opponent.Accuracy -= o.Weapon.Accuracy;
        //        opponent.Defence -= o.Armor.Defence;
        //        opponent.Health -= o.Armor.Health;

        //        //Work in progress
        //        if (info.Winner == "Opponent")
        //        {
        //            int gold = HowMuchGoldWon(o.Level);
        //            _playerService.EditAmountOfGold(o.Player, gold);
        //            _playerService.LevelUp(o);
        //        }

        //        _playerService.RemoveGladiator(p);
        //    }
        //}

        //public int HowMuchGoldWon(int lvl)
        //{
        //    int gold = 0;

        //    if ((lvl-1) > 0 && (lvl-1) < XPAndGoldFormula.GoldToGive.Length)
        //        gold = XPAndGoldFormula.GoldToGive[lvl-1];

        //    return gold;
        //}

        //public ShopInventory GenerateInventoryForAShop(int lvlOfGladiator, int nrOfGears)
        //{
        //    Gear newGear = null;
        //    ShopInventory inventory = new ShopInventory();

        //    for (int i = 0; i < nrOfGears/2; i++)
        //    {
        //        newGear = GenerateGear.GenerateAGearObject("Weapon", lvlOfGladiator);
        //        inventory.GearsInShop.Add(newGear);
        //        newGear = null;
        //    }
        //    for (int i = 0; i < nrOfGears/2; i++)
        //    {
        //        newGear = GenerateGear.GenerateAGearObject("Armor", lvlOfGladiator);
        //        inventory.GearsInShop.Add(newGear);
        //        newGear = null;
        //    }

        //    return inventory;
        //}
        
        //public Shop CreateAShop(Shop shop, int lvlOfGladiator)
        //{
        //    ShopInventory inventory = GenerateInventoryForAShop(lvlOfGladiator, 10);
        //    shop.Shops.Add(inventory);

        //    return shop;
        //}

        ///// <summary>
        ///// Send ShopInventory inventory in as a ref, changes to it are made.
        ///// </summary>
        ///// <param name="inventory">Specific inventory gladiator sees</param>
        ///// <param name="playersGladiator">The gladiator buying</param>
        ///// <param name="idOfItem">The index of the gear in the inventory</param>
        ///// <returns></returns>
        //public bool BuyAPieceOfGear(ShopInventory inventory, PlayerGladiator playersGladiator, int idOfItem)
        //{
        //    bool succeeded = false;

        //    if(idOfItem >= 0 && idOfItem < inventory.GearsInShop.Count)
        //    {
        //        int goldAvailable = playersGladiator.Player.Gold;

        //        if(goldAvailable >= inventory.GearsInShop[idOfItem].Cost)
        //        {
        //            _playerService.EditAmountOfGold(playersGladiator.Player, inventory.GearsInShop[0].Cost * -1);
        //            _playerService.UpdateGladiatorGear(playersGladiator, inventory.GearsInShop[idOfItem]);

        //            inventory.GearsInShop.RemoveAt(idOfItem);

        //            succeeded = true;
        //        }
                
        //    }

        //    return succeeded;
        //}
    }
}
