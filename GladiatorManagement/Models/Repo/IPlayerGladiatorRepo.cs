﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public interface IPlayerGladiatorRepo
    {
        public PlayerGladiator Create(string name, int strength, int accuracy, int health, int defence);

        public PlayerGladiator Read(int id);
        public List<PlayerGladiator> Read();

        public PlayerGladiator Update(PlayerGladiator gladiator);


        public bool Delete(PlayerGladiator playerGladiator);
    }
}