using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public abstract class Gear
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public string Name { get; set; }

        public Gear(int Cost, string Name)
        {
            this.Cost = Cost;
            this.Name = Name;
        }

    }
}
