using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public class Combat
    {
        private PlayerGladiator player;
        private PlayerGladiator opponent;

        private int playerMaxHealth;
        private int OpponentMaxHealth;

        public Combat(PlayerGladiator player, PlayerGladiator opponent)
        {
            this.player = player;
            this.opponent = opponent;

            playerMaxHealth = player.Health;
            OpponentMaxHealth = opponent.Health;
        }

        public List<CombatInfo> StartCombat()
        {
            opponent.Health += opponent.Armor.Health;
            player.Health += player.Armor.Health;

            bool combatInprogress = true;
            List<CombatInfo> combatDetails = new List<CombatInfo>();
            ARound aRound = new ARound(player, opponent);

            //Combat loop
            while (combatInprogress)
            {
                //Start A round of fighting and gets the details back
                CombatInfo details = aRound.Fight();
                combatInprogress = CheckHealth(ref details);
                combatDetails.Add(details);
            }

            //Reset their health to max
            player.Health = playerMaxHealth;
            opponent.Health = OpponentMaxHealth;

            return combatDetails;
        }

        private bool CheckHealth(ref CombatInfo combatDetails)
        {
            if (opponent.Health <= 0)
            {
                combatDetails.Winner = "Player";
                return false;
            }
            else if (player.Health <= 0)
            {
                combatDetails.Winner = "Opponent";
                return false;
            }

            return true;
        }
    }
}
