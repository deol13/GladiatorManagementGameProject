using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class Weapon : Gear
    {
        [Required]
        public int Strength { get; set; }

        [Required]
        public int Accuracy { get; set; }

        public virtual PlayerGladiator Gladiator { get; set; }
        public int? PlayerGladiatorId { get; set; }

        public Weapon(string Name, int Cost, int Strength, int Accuracy) : base(Name, Cost)
        {
            this.Strength = Strength;
            this.Accuracy = Accuracy;
            Gladiator = null;
        }
    }
}
