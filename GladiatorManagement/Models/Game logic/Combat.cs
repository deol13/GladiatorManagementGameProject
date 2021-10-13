using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public class Combat
    {
        private PlayerGladiator player;
        private Gladiator opponent;  

        public Combat(PlayerGladiator player, Gladiator opponent)
        {
            this.player = player;
            this.opponent = opponent;
        }

        public List<CombatInfo> StartCombat()
        {
            bool combatInprogress = true;
            List<CombatInfo> combatDetails = new List<CombatInfo>();

            while(combatInprogress)
            {
                //CombatInfo combatDetails = ;

                //combatInprogress = CheckHealth(combatDetails);
            }

            return combatDetails;
        }

        private bool CheckHealth(CombatInfo combatDetails)
        {
            if (opponent.Health <= 0)
            {
                //combatDetails.Winner = Player;
                return false;
            }
            else if (player.Health <= 0)
            {
                //combatDetails.Winner = Opponent;
                return false;
            }

            return true;
        }
    }
}
