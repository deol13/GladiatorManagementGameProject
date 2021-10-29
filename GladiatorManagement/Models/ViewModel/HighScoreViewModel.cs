using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.ViewModel
{
    public class HighScoreViewModel
    {
        public List<GladHighScore> GladHighScoreList { get; set; }
        public List<PlayerHighScore> PlayerHighScoreList { get; set; }

        public HighScoreViewModel()
        {
            GladHighScoreList = new List<GladHighScore>();
            PlayerHighScoreList = new List<PlayerHighScore>();
        }
    }
}
