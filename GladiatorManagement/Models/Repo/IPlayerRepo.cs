using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public interface IPlayerRepo
    {
        public Player Create(string name, string email);
        public Player Read(int id);
        public Player Read(string email);
        public List<Player> Read();
        public Player Update(Player player);
        public bool Delete(Player player);

    }
}
