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

        public int PlayerHealthLeft { get; set; }
        public int OpponentHealthLeft { get; set; }

        public string Hit { get; set; }

        public int DamageDone { get; set; }

        public string DamageDoneDetails { get; set; }

        public string Winner { get; set; }
    }
}
