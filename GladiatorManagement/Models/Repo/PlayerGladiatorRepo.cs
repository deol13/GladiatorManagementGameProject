﻿using GladiatorManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public class PlayerGladiatorRepo : IPlayerGladiatorRepo
    {
        ApplicationDbContext _appDbContext;

        public PlayerGladiatorRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public PlayerGladiator Create(string name, int strength, int accuracy, int health, int defence)
        {
            PlayerGladiator gladiator = new PlayerGladiator
            {
                Name = name,
                Strength = strength,
                Accuracy = accuracy,
                Health = health,
                Defence = defence
            };
            
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

        public PlayerGladiator Update(PlayerGladiator gladiator)
        {
            PlayerGladiator glad =
                (PlayerGladiator)(from p in _appDbContext.PlayerGladiators
                         where p.Id == gladiator.Id
                         select p);
            glad.Name = gladiator.Name;
            glad.Experience = gladiator.Experience;
            glad.Level = gladiator.Level;
            glad.Score = gladiator.Score;
            glad.Strength = gladiator.Strength;
            glad.Accuracy = gladiator.Accuracy;
            glad.Health = gladiator.Health;
            glad.Defence = gladiator.Defence;
            glad.Armor = gladiator.Armor;
            glad.Weapon = gladiator.Weapon;
            _appDbContext.SaveChanges();
            return glad;
        }



        public bool Delete(PlayerGladiator playerGladiator)
        {
            if (_appDbContext.PlayerGladiators.Contains(playerGladiator))
            {
                _appDbContext.Remove(playerGladiator);
                _appDbContext.SaveChanges();
                return true;
            }
            else return false;
        }
    }
}
