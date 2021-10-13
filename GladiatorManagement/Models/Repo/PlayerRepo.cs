using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Models;

namespace GladiatorManagement.Data
{
    public class PlayerRepo
    {
        ApplicationDbContext _appDbContext;

        public PlayerRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Player Create(string name)
        {
            Player player = new Player
            {
                Name = name
            };

            _appDbContext.Players.Add(player);
            _appDbContext.SaveChanges();

            return player;
        }


    }
}
