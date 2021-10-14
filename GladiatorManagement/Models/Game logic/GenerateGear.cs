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

            //string name = ""; //Some type of generator of names

            //int minValue = 1 + () / lvlOfGladiator;
            //int maxValue = ;
            //int attribute1 = XPAndGoldFormula.Randomize(minValue, maxValue);
            //int attribute2 = XPAndGoldFormula.Randomize(minValue, maxValue);

            //int cost = XPAndGoldFormula.Randomize();

            //if(typeOfGear == "Weapon")
            //{
            //    newGear = new Weapon(name, cost, attribute1, attribute2);
            //}
            //else if(typeOfGear == "Armor")
            //{
            //    newGear = new Armor(name, cost, attribute1, attribute2);
            //}

            return newGear;
        }
    }
}
