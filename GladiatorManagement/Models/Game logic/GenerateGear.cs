using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lexicon.CSharp.InfoGenerator;

namespace GladiatorManagement.Models.Game_logic
{
    public static class GenerateGear
    {
        static InfoGenerator generator = new InfoGenerator();

        public static Gear GenerateAGearObject(string typeOfGear, int lvlOfGladiator)
        {
            Gear newGear = null;

            string name = "";

            int minValue = 1 + lvlOfGladiator / 2;
            int maxValue = 2 + lvlOfGladiator / 2;
            int attribute1 = generator.Next(minValue, maxValue); //XPAndGoldFormula.Randomize(minValue, maxValue);
            int attribute2 = generator.Next(minValue, maxValue);//XPAndGoldFormula.Randomize(minValue, maxValue);

            int cost = 50;
            cost += (attribute1 + attribute2) * 10;

            if (typeOfGear == "Weapon")
            {
                newGear = new Weapon(name, cost, attribute1, attribute2);
                name = $"{typeOfGear}: Strength +{attribute1} & Accuracy+{attribute2}";
            }
            else if (typeOfGear == "Armor")
            {
                newGear = new Armor(name, cost, attribute1, attribute2);
                name = $"{typeOfGear}: Defence +{attribute1} & Health+{attribute2}";
            }

            return newGear;
        }
    }
}
