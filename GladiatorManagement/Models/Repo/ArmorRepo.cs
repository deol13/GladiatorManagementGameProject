using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GladiatorManagement.Models.Repo
{
    public class ArmorRepo : IArmorRepo
    {
        ApplicationDbContext _appDbContext;

        public ArmorRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public Armor Create(string name, int cost, int defence, int health)
        {
            Armor arm = new Armor(name, cost, defence, health);
            _appDbContext.Armors.Add(arm);
            _appDbContext.SaveChanges();
            return arm;
        }

        public Armor Create(Armor armor)
        {
            _appDbContext.Armors.Add(armor);
            _appDbContext.SaveChanges();

            return armor;
        }

        public bool Delete(Armor armor)
        {
            if (_appDbContext.Armors.Contains(armor))// && armor.Id != 1)
            {
                _appDbContext.Armors.Remove(armor);
                _appDbContext.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool DeleteAll(ShopInventory inventory)
        {
            foreach (var item in inventory.ArmorsInShop)
            {
                if (_appDbContext.Armors.Contains(item))
                {
                    _appDbContext.Armors.Remove(item);
                }
            }
            _appDbContext.SaveChanges();
            return true;
        }

        public Armor Read(int id)
        {
            return _appDbContext.Armors.AsNoTracking().FirstOrDefault(a => a.Id == id);
        }
        
        public List<Armor> Read()
        {
            return _appDbContext.Armors.AsNoTracking().ToList();
            //return _appDbContext.Armors.ToList();
        }
        public List<Armor> ReadAllInventory(int inventoryId)
        {
            return _appDbContext.Armors.AsNoTracking().Where(a => a.ShopInventoryId == inventoryId).ToList();
        }

        public Armor Update(Armor armor)
        {
            EntityEntry ee = _appDbContext.Entry(armor);

            if (ee.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                _appDbContext.Armors.Update(armor);

            int changes = _appDbContext.SaveChanges();
            ee.State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            return armor;
        }
    }
}
