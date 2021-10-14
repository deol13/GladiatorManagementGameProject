using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public interface IGladiatorRepo
    {
        public Gladiator Create(string name, int strength, int accuracy, int health, int defence);
        public Gladiator Read(int id);
        public List<Gladiator> Read();
        public bool Delete(Gladiator gladiator);
    }
}
