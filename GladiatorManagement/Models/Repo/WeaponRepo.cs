using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GladiatorManagement.Models.Repo
{
    public class WeaponRepo : IWeaponRepo
    {
        ApplicationDbContext _appDbContext;

        public WeaponRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Weapon Create(string name, int cost, int strength, int accuracy)
        {
            Weapon wp = new Weapon(name, cost, strength, accuracy);
            _appDbContext.Weapons.Add(wp);
            _appDbContext.SaveChanges();
            return wp;
        }

        public Weapon Create(Weapon weapon)
        {
            _appDbContext.Weapons.Add(weapon);
            _appDbContext.SaveChanges();
            return weapon;
        }

        public bool Delete(Weapon weapon)
        {
            if (_appDbContext.Weapons.Contains(weapon) && weapon.Id != 1)
            {
                //_appDbContext.Entry(weapon).State = EntityState.Deleted;
                _appDbContext.Weapons.Remove(weapon);
                _appDbContext.SaveChanges();
                return true;
            }
            else return false;
        }

        public Weapon Read(int id)
        {
            return _appDbContext.Weapons.FirstOrDefault(w => w.Id == id);
        }

        public List<Weapon> Read()
        {
            return _appDbContext.Weapons.ToList();
        }
    }
}
