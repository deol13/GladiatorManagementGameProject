using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public static class XPAndGoldFormula
    {
        private static Random rng;
        private static int MaxLvl { get; set; } = 20;

        public static int[] XpToLVl { get; set; }
        public static int[] GoldToGive { get; set; }

        public static void Setup()
        {
            rng = new Random();
            XpToLVl = new int[MaxLvl];
            GoldToGive = new int[MaxLvl];

            for (int i = 0; i < MaxLvl; i++)
            {
                XpToLVl[i] = 100*(i+1);
                GoldToGive[i] = 15 * (i + 1);
            }
        }


        public static int Randomize(int minValue, int maxValue)
        {
            return rng.Next(minValue, maxValue);
        }
    }
}
