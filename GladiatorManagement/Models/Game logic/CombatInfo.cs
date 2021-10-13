using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public class CombatInfo
    {
        public int PlayerRollResult { get; set; }
        public int OpponentRollResult { get; set; }

        public string PlayerRollDetails { get; set; }
        public string OpponentRollDetails { get; set; }

        

    }
}
