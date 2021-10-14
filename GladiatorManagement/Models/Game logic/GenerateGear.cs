using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public static class GenerateGear
    {
        public static Gear GenerateAGearObject(string typeOfGear, int lvlOfGladiator)
        {
            Gear newGear = null;

            string name = ""; //Some type of generator of names

            int minValue = 1 + lvlOfGladiator / 2;
            int maxValue = 2 + lvlOfGladiator / 2;
            int attribute1 = XPAndGoldFormula.Randomize(minValue, maxValue);
            int attribute2 = XPAndGoldFormula.Randomize(minValue, maxValue);

            int cost = 50;
            cost += (attribute1 + attribute2) * 10;

            if (typeOfGear == "Weapon")
            {
                newGear = new Weapon(name, cost, attribute1, attribute2);
            }
            else if (typeOfGear == "Armor")
            {
                newGear = new Armor(name, cost, attribute1, attribute2);
            }

            return newGear;
        }
    }
}
