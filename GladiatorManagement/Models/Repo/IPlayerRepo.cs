using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public interface IPlayerRepo
    {
        public Player Create(string name);
        public Player Read(int id);
        public List<Player> Read();
        public Player Update(Player player);
        public bool Delete(Player player);

    }
}
