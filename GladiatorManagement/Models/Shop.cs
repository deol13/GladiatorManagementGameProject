﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public List<ShopInventory> Shops { get; set; }

        public Shop()
        {
            Shops = new List<ShopInventory>();
        }
    }
}
