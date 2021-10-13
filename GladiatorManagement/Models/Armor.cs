using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class Armor : Gear
    {
        [Required]
        public int Defence { get; set; }

        [Required]
        public int Health { get; set; }

        public Armor(int Cost, string Name, int Defence, int Health) : base(Cost, Name)
        {
            this.Defence = Defence;
            this.Health = Health;
        }
    }
}
