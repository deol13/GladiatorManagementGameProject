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
        List<Gear> GearsInShop { get; set; }

        public ShopInventory()
        {
            GearsInShop = new List<Gear>();
        }
    }
}
