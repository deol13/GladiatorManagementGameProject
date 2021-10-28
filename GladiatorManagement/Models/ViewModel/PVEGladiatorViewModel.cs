using GladiatorManagement.Models.Game_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.ViewModel
{
    public class PVEGladiatorViewModel
    {
        public int PlayerId { get; set; }
        public string GladiatorName { get; set; }
        public string OpponentName { get; set; }
        public List<CombatInfo> CombatLog { get; set; }
    }
}
