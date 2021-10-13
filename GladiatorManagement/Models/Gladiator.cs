using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class Gladiator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Strength { get; set; }
        [Required]
        public int Accuracy { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public int Defence { get; set; }

        public Gladiator(int Strength, int Accuracy, int Health, int Defence)
        {
            this.Strength = Strength;
            this.Accuracy = Accuracy;
            this.Health = Health;
            this.Defence = Defence;
        }
    }
}
