using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class PlayerHighScore
    {
        public int PlayerScore { get; set; }
        public string PlayerName { get; set; }

        public PlayerHighScore(int playerScore, string playerName)
        {
            PlayerScore = playerScore;
            PlayerName = playerName;
        }
    }
}
