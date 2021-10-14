using GladiatorManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Repo
{
    public class GladiatorRepo : IGladiatorRepo
    {
        ApplicationDbContext _appDbContext;
        
        public GladiatorRepo(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Gladiator Create(string name, int strength, int accuracy, int health, int defence)
        {
            Gladiator gladiator = new Gladiator(name, strength, accuracy, health, defence);
            _appDbContext.Gladiators.Add(gladiator);
            _appDbContext.SaveChanges();
            return gladiator;
        }

        public Gladiator Read(int id)
        {
            return _appDbContext.Gladiators.FirstOrDefault(g => g.Id == id);
        }

        public List<Gladiator> Read()
        {
            return _appDbContext.Gladiators.ToList();
        }


    }
}
