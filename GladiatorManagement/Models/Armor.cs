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
        public int? ShopInventoryId { get; set; }

        public Armor(string Name, int Cost, int Defence, int Health) : base(Name, Cost)
        {
            this.Defence = Defence;
            this.Health = Health;
        }
    }
}
