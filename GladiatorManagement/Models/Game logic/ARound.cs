using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public static class ARound
    {
        private static int minRoll = 1;
        private static int maxRoll = 7;

        public static Gladiator Player { get; set; }
        public static Gladiator Opponent { get; set; }

        static InfoGenerator generator = new InfoGenerator();

        /// <summary>
        /// Starts a round of combat
        /// </summary>
        /// <param name="combatInfo">Saves the details of the round</param>
        /// <param name="player">Players gladiator</param>
        /// <param name="opponent">Opponent gladiator</param>
        /// <returns></returns>
        public static CombatInfo Fight()
        {
            CombatInfo combatInfo = new CombatInfo();

            int playerRoll = DiceRoll();
            int opponentRoll = DiceRoll();

            combatInfo = SaveRollInfo(combatInfo, playerRoll, opponentRoll);

            combatInfo = Hit(combatInfo);

            combatInfo.Winner = null;
            return combatInfo;
        }

        private static CombatInfo SaveRollInfo(CombatInfo combatInfo, int playerRoll, int opponentRoll)
        {
            combatInfo.PlayerRollResult = playerRoll + Player.Accuracy;
            combatInfo.OpponentRollResult = opponentRoll + Opponent.Accuracy;

            combatInfo.PlayerRollDetails = $"{playerRoll} + {Player.Accuracy}";
            combatInfo.OpponentRollDetails = $"{opponentRoll} + {Opponent.Accuracy}";

            combatInfo.PlayerHealthLeft = Player.Health;
            combatInfo.OpponentHealthLeft = Opponent.Health;

            return combatInfo;
        }

        private static CombatInfo Hit(CombatInfo combatInfo)
        {
            if (combatInfo.PlayerRollResult > combatInfo.OpponentRollResult)
            {
                //If player rolls higher
                combatInfo.Hit = "Player";

                if (Player.Strength > Opponent.Defence)
                {
                    combatInfo.DamageDone = (Player.Strength - Opponent.Defence);
                    Opponent.Health -= combatInfo.DamageDone;

                    combatInfo.DamageDoneDetails = $"{Player.Strength} - {Opponent.Defence}";
                }
                else
                {
                    combatInfo.DamageDone = 0;
                    combatInfo.DamageDoneDetails = $"{Player.Strength} - {Opponent.Defence}";
                }

                combatInfo.OpponentHealthLeft = Opponent.Health;
            }
            else if (combatInfo.OpponentRollResult > combatInfo.PlayerRollResult)
            {
                //If opponent rolls higher
                combatInfo.Hit = "Opponent";

                if (Opponent.Strength > Player.Defence)
                {
                    combatInfo.DamageDone = (Opponent.Strength - Player.Defence);
                    Player.Health -= combatInfo.DamageDone;

                    combatInfo.DamageDoneDetails = $"{Opponent.Strength} - {Player.Defence}";
                }
                else
                {
                    combatInfo.DamageDone = 0;
                    combatInfo.DamageDoneDetails = $"{Opponent.Strength} - {Player.Defence}";
                }

                combatInfo.PlayerHealthLeft = Player.Health;
            }
            else
            {
                //Even
                combatInfo.Hit = "Even";
                combatInfo.DamageDone = 0;
            }

            return combatInfo;
        }

        private static int DiceRoll()
        {
            return generator.Next(minRoll, maxRoll);
        }
    }
}
