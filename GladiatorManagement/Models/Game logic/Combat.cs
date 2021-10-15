using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public class Combat
    {
        //private Gladiator player;
        //private Gladiator opponent;

        //private int playerMaxHealth;
        //private int OpponentMaxHealth;

        //public Combat(Gladiator player, Gladiator opponent)
        //{
        //    this.player = player;
        //    this.opponent = opponent;

        //    playerMaxHealth = player.Health;
        //    OpponentMaxHealth = opponent.Health;
        //}

        //public List<CombatInfo> StartCombat()
        //{
        //    bool combatInprogress = true;
        //    List<CombatInfo> combatDetails = new List<CombatInfo>();

        //    ARound.Player = player;
        //    ARound.Opponent = opponent;

        //    //Combat loop
        //    while(combatInprogress)
        //    {
        //        //Start A round of fighting and gets the details back
        //        CombatInfo details = ARound.Fight();
        //        combatInprogress = CheckHealth(ref details);
        //        combatDetails.Add(details);
        //    }

        //    //Reset their health to max
        //    player.Health = playerMaxHealth;
        //    opponent.Health = OpponentMaxHealth;

        //    return combatDetails;
        //}

        //private bool CheckHealth(ref CombatInfo combatDetails)
        //{
        //    if (opponent.Health <= 0)
        //    {
        //        combatDetails.Winner = "Player";
        //        return false;
        //    }
        //    else if (player.Health <= 0)
        //    {
        //        combatDetails.Winner = "Opponent";
        //        return false;
        //    }

        //    return true;
        //}
    }
}
