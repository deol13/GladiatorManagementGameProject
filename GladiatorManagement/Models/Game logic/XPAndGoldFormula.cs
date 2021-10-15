using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public static class XPAndGoldFormula
    {
        private static Random rng;
        public static int MaxLvl { get; set; } = 20;

        /// <summary>
        /// Index 0 is the xp amount to lvl 2, index 1 to lvl 3 and so on.
        /// So use lvl-1. For example if you are lvl 1, you do XpToLVl[lvl-1], lvl-1=0 and index 0 is
        /// The amount to lvl 2.
        /// </summary>
        public static int[] XpToLVl { get; set; }
        /// <summary>
        /// The amount of gold an enemy of a specific lvl gives, index 0 is for a lvl 1 enemy.
        /// So use lvl-1. For example, you defeated a lvl 1 enemy, you do GoldToGive[lvl-1], lvl-1=0 and index 0
        /// is for a lvl 1 enemy.
        /// </summary>
        public static int[] GoldToGive { get; set; }

        public static int[] XPToGive { get; set; }

        public static void Setup()
        {
            rng = new Random();
            XpToLVl = new int[MaxLvl];
            GoldToGive = new int[MaxLvl];

            for (int i = 0; i < MaxLvl; i++)
            {
                XpToLVl[i] = 100*(i+1);
                GoldToGive[i] = 15 * (i + 1);
                XPToGive[i] = 105 * (i + 1);
            }
        }


        public static int Randomize(int minValue, int maxValue)
        {
            return rng.Next(minValue, maxValue);
        }
    }
}
