using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public interface IPlayerGladiatorRepo
    {
        public PlayerGladiator Create(Player player, string name, int strength, int accuracy, int health, int defence);

        public PlayerGladiator Read(int id);
        public List<PlayerGladiator> Read();
        public List<PlayerGladiator> ReadRelatedToPlayer(int id);
        public List<PlayerGladiator> ReadEnemyGlad(int id);

        public PlayerGladiator Update(PlayerGladiator gladiator);


        public bool Delete(PlayerGladiator playerGladiator);
    }
}
