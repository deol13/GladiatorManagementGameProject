using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class GladHighScore
    {
        public int GladScore { get; set; }
        public string GladName { get; set; }
        public string PlayerName { get; set; }

        public GladHighScore(int gladScore, string gladName, string playerName)
        {
            GladScore = gladScore;
            GladName = gladName;
            PlayerName = playerName;
        }
    }
}
