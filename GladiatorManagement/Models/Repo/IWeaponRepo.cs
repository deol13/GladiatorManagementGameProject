using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public interface IWeaponRepo
    {
        public Weapon Create(string name, int cost, int strength, int accuracy);
        public Weapon Create(Weapon weapon);
        public Weapon Read(int id);
        public List<Weapon> Read();
        public List<Weapon> ReadAllInventory(int inventoryId);
        public bool Delete(Weapon weapon);
    }
}
