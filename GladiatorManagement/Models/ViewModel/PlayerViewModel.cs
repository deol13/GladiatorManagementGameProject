using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.ViewModel
{
    public class PlayerViewModel
    {

        public Player Player { get; set; }
        public List<PlayerGladiator> Gladiators { get; set; }

    }
}
