using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class PlayerGladiator
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Player Player { get; set; }
        public int? PlayerId { get; set; }
        public int Strength { get; set; }
        public int Accuracy { get; set; }
        public int Health { get; set; }
        public int Defence { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        [Required]
        public int Experience { get; set; }
        [Required]
        public int Level { get; set; }

        public int Score { get; set; }

        public PlayerGladiator()
        {
            //Default weapon and armor aka you got nothing.
            Weapon = null;
            Armor = null;

            Experience = 0;
            Level = 1;
            Score = 0;
        }
    }
}
