using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic.GameRepo
{
    public interface IGameRepo
    {
        public ShopInventory FindShopInventory(int id);
        public ShopInventory SaveShopInventory(ShopInventory shopInventory);
        public bool RemoveShopInvenotry(ShopInventory shopInventory);
        public List<ShopInventory> All();
        public ShopInventory Update(ShopInventory shopInventory);
    }
}
