using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public int Strength { get; set; }

        [Required]
        public int Accuracy { get; set; }
    }
}
