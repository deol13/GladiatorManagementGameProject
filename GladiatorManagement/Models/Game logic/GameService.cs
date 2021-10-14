using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Models.Service;

namespace GladiatorManagement.Models.Game_logic
{
    public class GameService
    {
        PlayerService _playerService;

        public GameService(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public void LaunchCombat(int playerGladiatorId, int opponentGladiatorId)
        {
            Gladiator player = null;
            Gladiator opponent = null;

            player = new PlayerGladiator("Dennis", 5, 5, 10, 2);
            opponent = new Gladiator("Jojje", 5, 6, 11, 3);

            //player = FindGladiator(playerGladiatorId);
            //opponent = FindGladiator(opponentGladiatorId);
  

            PlayerGladiator p = player as PlayerGladiator;
            PlayerGladiator o = opponent as PlayerGladiator;

            Combat combat = null;

            if (p != null)
            {
                p.Weapon.Strength += 1;
                p.Weapon.Accuracy += 1;
                p.Armor.Defence += 1;
                p.Armor.Health += 1;

                player.Strength += p.Weapon.Strength;
                player.Accuracy += p.Weapon.Accuracy;
                player.Defence += p.Armor.Defence;
                player.Health += p.Armor.Health;
            }
            if(o != null)
            {
                opponent.Strength += o.Weapon.Strength;
                opponent.Accuracy += o.Weapon.Accuracy;
                opponent.Defence += o.Armor.Defence;
                opponent.Health += o.Armor.Health;
            }

            combat = new Combat(player, opponent);

            List<CombatInfo> listOfCombatDetails = combat.StartCombat();

            CombatInfo info = listOfCombatDetails.Last();

            
            if (p != null)
            {
                player.Strength -= p.Weapon.Strength;
                player.Accuracy -= p.Weapon.Accuracy;
                player.Defence -= p.Armor.Defence;
                player.Health -= p.Armor.Health;

                //Work in progress
                if(info.Winner == "Player")
                {
                    int gold = HowMuchGoldWon(p.Level);
                    _playerService.EditAmountOfGold(p.Player, gold);
                    _playerService.LevelUp(p);

                    //_playerService.RemoveGladiator(opponent);
                }
            }
            if (o != null)
            {
                opponent.Strength -= o.Weapon.Strength;
                opponent.Accuracy -= o.Weapon.Accuracy;
                opponent.Defence -= o.Armor.Defence;
                opponent.Health -= o.Armor.Health;

                //Work in progress
                if (info.Winner == "Opponent")
                {
                    int gold = HowMuchGoldWon(o.Level);
                    _playerService.EditAmountOfGold(o.Player, gold);
                    _playerService.LevelUp(o);
                }

                //_playerService.RemoveGladiator(player);
            }

            //TODO
            //Remove gladiator when they die
        }

        public int HowMuchGoldWon(int lvl)
        {
            int gold = 0;

            if ((lvl-1) > 0 && (lvl-1) < XPAndGoldFormula.GoldToGive.Length)
                gold = XPAndGoldFormula.GoldToGive[lvl-1];

            return gold;
        }

        public ShopInventory GenerateInventoryForAShop(ShopInventory inventory)
        {


            return inventory;
        }
        
    }
}
