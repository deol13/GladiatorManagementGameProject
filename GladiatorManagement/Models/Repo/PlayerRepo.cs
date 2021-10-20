using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladiatorManagement.Data;

namespace GladiatorManagement.Models.Repo
{
    public class PlayerRepo : IPlayerRepo
    {
        ApplicationDbContext _appDbContext;

        public PlayerRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Player Create(string name, string email)
        {
            Player player = new Player
            {
                Name = name,
                EmailVerification = email
            };

            _appDbContext.Players.Add(player);
            _appDbContext.SaveChanges();

            return player;
        }

        public Player Read(int id)
        {
            return _appDbContext.Players.FirstOrDefault(p => p.PlayerId == id);
        }

        public Player Read(string email)
        {
            return _appDbContext.Players.FirstOrDefault(p => p.EmailVerification == email);
        }

        public List<Player> Read()
        {
            return _appDbContext.Players.ToList();
        }

        public Player Update(Player player)
        {
            Player pl = _appDbContext.Players.Find(player.PlayerId);

            pl.Name = player.Name;
            pl.Gold = player.Gold;
            pl.Score = player.Score;
            pl.Gladiators = player.Gladiators;
            _appDbContext.SaveChanges();
            return pl;
        }

        public bool Delete(Player player)
        {
            if (_appDbContext.Players.Contains(player))
            {
                _appDbContext.Remove(player);
                _appDbContext.SaveChanges();
                return true;
            }
            else return false;
        }


    }
}
