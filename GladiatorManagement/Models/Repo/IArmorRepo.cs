using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public interface IArmorRepo
    {
        public Armor Create(string name, int cost, int defence, int health);
        public Armor Create(Armor armor);
        public Armor Read(int id);
        public List<Armor> Read();
        public List<Armor> ReadAllInventory(int inventoryId);

        public bool Delete(Armor armor);
        public bool DeleteAll(ShopInventory inventory);
    }
}
