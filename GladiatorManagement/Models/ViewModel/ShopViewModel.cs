using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.ViewModel
{
    public class ShopViewModel
    {
        public PlayerGladiator Gladiator { get; set; }
        public Shop Shop { get; set; }

        public ShopInventory Inventory { get; set; }

    }
}
