using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class Armor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public int Defence { get; set; }

        [Required]
        public int Health { get; set; }
    }
}
