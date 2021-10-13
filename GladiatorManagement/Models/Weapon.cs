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

        public Weapon(int Cost, string Name, int Strength, int Accuracy) : base(Cost, Name)
        {
            this.Strength = Strength;
            this.Accuracy = Accuracy;
        }
    }
}
