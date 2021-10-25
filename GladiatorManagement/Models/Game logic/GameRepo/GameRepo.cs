using GladiatorManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic.GameRepo
{
    public class GameRepo : IGameRepo
    {
        ApplicationDbContext _appDbContext;

        public GameRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<ShopInventory> All()
        {
            return _appDbContext.ShopInventories.ToList();
        }

        public ShopInventory FindShopInventory(int id)
        {
            return _appDbContext.ShopInventories.Find(id);
        }

        public ShopInventory FindGladiatorsInventory(int gladiatorId)
        {
            return _appDbContext.ShopInventories.Single(b => b.GladiatorId == gladiatorId);
        }

        public bool RemoveShopInvenotry(ShopInventory shopInventory)
        {
            if (_appDbContext.ShopInventories.Contains(shopInventory))
            {
                _appDbContext.ShopInventories.Remove(shopInventory);
                _appDbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public ShopInventory SaveShopInventory(ShopInventory shopInventory)
        {
            _appDbContext.ShopInventories.Add(shopInventory);
            _appDbContext.SaveChanges();

            return shopInventory;
        }

        public ShopInventory Update(ShopInventory shopInventory)
        {
            //_appDbContext.ShopInventories.Update(shopInventory);
            _appDbContext.SaveChanges();

            return shopInventory;
        }
    }
}
