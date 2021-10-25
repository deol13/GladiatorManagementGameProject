using GladiatorManagement.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public class PlayerGladiatorRepo : IPlayerGladiatorRepo
    {
        ApplicationDbContext _appDbContext;
        //public static int DefaultWId { get; set; } = 1;
        //public static int DefaultAId { get; set; } = 1;

        public PlayerGladiatorRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public PlayerGladiator Create(Player player, string name, int strength, int accuracy, int health, int defence)
        {
            Weapon defaultWeapon = new Weapon("Fist", 0, 0, 0);//_appDbContext.Weapons.Find(DefaultWId);
            Armor defaultArmor = new Armor("Skin", 0, 0, 0);//_appDbContext.Armors.Find(DefaultAId);
            _appDbContext.Weapons.Add(defaultWeapon);
            _appDbContext.Armors.Add(defaultArmor);
            _appDbContext.SaveChanges();

            PlayerGladiator gladiator = new PlayerGladiator
            {
                //PlayerId = player.PlayerId,
                Name = name,
                Strength = strength,
                Accuracy = accuracy,
                Health = health,
                Defence = defence,
                Weapon = defaultWeapon,
                Armor = defaultArmor,
                WeaponID = defaultWeapon.Id,
                ArmorID = defaultArmor.Id
            };

            if (player != null)
                gladiator.PlayerId = player.PlayerId;
            
            _appDbContext.PlayerGladiators.Add(gladiator);
            _appDbContext.SaveChanges();
            return gladiator;
        }

        public PlayerGladiator Read(int id)
        {
            return _appDbContext.PlayerGladiators.FirstOrDefault(p => p.Id == id);
        }

        public List<PlayerGladiator> Read()
        {
            return _appDbContext.PlayerGladiators.ToList();
        }
        public List<PlayerGladiator> ReadRelatedToPlayer(int id)
        {
            return _appDbContext.PlayerGladiators.Where(g => g.PlayerId == id).ToList();
        }

        public PlayerGladiator Update(PlayerGladiator gladiator)
        {
            //PlayerGladiator glad = _appDbContext.PlayerGladiators.Find(gladiator.Id);
            //glad.Name = gladiator.Name;
            //glad.Experience = gladiator.Experience;
            //glad.Level = gladiator.Level;
            //glad.Score = gladiator.Score;
            //glad.Strength = gladiator.Strength;
            //glad.Accuracy = gladiator.Accuracy;
            //glad.Health = gladiator.Health;
            //glad.Defence = gladiator.Defence;
            //glad.Armor = gladiator.Armor;
            //glad.Weapon = gladiator.Weapon;

            EntityEntry ee = _appDbContext.Entry(gladiator);

            if(ee.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                _appDbContext.Update(gladiator);

            int changes = _appDbContext.SaveChanges();
            return gladiator;
        }


        public bool Delete(PlayerGladiator playerGladiator)
        {
            if (_appDbContext.PlayerGladiators.Contains(playerGladiator))
            {
                _appDbContext.PlayerGladiators.Remove(playerGladiator);
                
                int changes = _appDbContext.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
