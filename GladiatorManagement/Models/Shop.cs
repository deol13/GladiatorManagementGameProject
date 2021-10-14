using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public List<ShopInventory> Shops { get; set; }

        public Shop()
        {
            Shops = new List<ShopInventory>();
        }
    }
}
