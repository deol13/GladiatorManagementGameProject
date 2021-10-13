using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public List<PlayerGladiator> gladiators { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int Gold { get; set; }

        public Player()
        {
            Score = 0;
            Gold = 0;
            gladiators = new List<PlayerGladiator>();
        }

    }
}
