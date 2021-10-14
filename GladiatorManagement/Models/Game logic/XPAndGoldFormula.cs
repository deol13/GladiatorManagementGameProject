using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public static class XPAndGoldFormula
    {
        public static int[] XpToLVl;
        public static int[] GoldToGive;

        public static void Setup()
        {
            XpToLVl = new int[20];
            GoldToGive = new int[20];

            for (int i = 0; i < 20; i++)
            {
                XpToLVl[i] = 100*(i+1);
                GoldToGive[i] = 15 * (i + 1);
            }
        }
    }
}
