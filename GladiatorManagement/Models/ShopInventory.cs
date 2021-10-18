using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class ShopInventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GladiatorId { get; set; }

        /// <summary>
        /// Can be made into an array since it will always be exact size
        /// </summary>
        [Required]
        public List<Weapon> WeaponsInShop { get; set; }
        [Required]
        public List<Armor> ArmorsInShop { get; set; }

        public ShopInventory()
        {
            WeaponsInShop = new List<Weapon>();
            ArmorsInShop = new List<Armor>();
        }
    }
}
