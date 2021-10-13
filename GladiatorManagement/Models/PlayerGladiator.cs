using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class PlayerGladiator : Gladiator
    {
        [Required]
        public Weapon Weapon { get; set; }
        [Required]
        public Armor Armor { get; set; }

        [Required]
        public int Experience { get; set; }
        [Required]
        public int Level { get; set; }

        public int Score { get; set; }

        public PlayerGladiator(int Strength, int Accuracy, int Health, int Defence) : base(Strength, Accuracy, Health, Defence)
        {
            Weapon = new Weapon();
            Armor = new Armor();

            Experience = 0;
            Level = 1;
            Score = 0;
        }
    }
}
