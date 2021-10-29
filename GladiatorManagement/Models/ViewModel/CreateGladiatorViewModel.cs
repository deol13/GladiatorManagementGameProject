using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.ViewModel
{
    public class CreateGladiatorViewModel
    {   
        PlayerGladiator newGladiator;
        public CreateGladiatorViewModel(Player player)
        {
            newGladiator = new PlayerGladiator();
            newGladiator.Strength = 3;
            newGladiator.Defence = 3;
            newGladiator.Accuracy = 3;
            newGladiator.Health = 3;
            AvailablePoints = 8;
            Player = player;
        }
        
        public string ChosenStat { get; set; }
        public int AvailablePoints { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Player Player { get; set; }
        public int? PlayerId { get; set; }
        public int Strength { get; set; }
        public int Accuracy { get; set; }
        public int Health { get; set; }
        public int Defence { get; set; }

    }
}
