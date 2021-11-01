using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public  class ARound
    {
        private int minRoll = 1;
        private int maxRoll = 7;

        private PlayerGladiator player;
        private PlayerGladiator opponent;

        private static InfoGenerator generator = new InfoGenerator();

        public ARound(PlayerGladiator player, PlayerGladiator opponent)
        {
            this.player = player;
            this.opponent = opponent;
        }

        /// <summary>
        /// Starts a round of combat
        /// </summary>
        /// <param name="combatInfo">Saves the details of the round</param>
        /// <param name="player">Players gladiator</param>
        /// <param name="opponent">Opponent gladiator</param>
        /// <returns></returns>
        public CombatInfo Fight()
        {
            CombatInfo combatInfo = new CombatInfo();

            int playerRoll = generator.Next(minRoll, maxRoll);
            int opponentRoll = generator.Next(minRoll, maxRoll);

            combatInfo = SaveRollInfo(combatInfo, playerRoll, opponentRoll);

            combatInfo = Hit(combatInfo);

            combatInfo.Winner = null;
            return combatInfo;
        }

        private CombatInfo SaveRollInfo(CombatInfo combatInfo, int playerRoll, int opponentRoll)
        {
            combatInfo.PlayerRollResult = playerRoll + player.Accuracy + player.Weapon.Accuracy;
            combatInfo.OpponentRollResult = opponentRoll + opponent.Accuracy + opponent.Weapon.Accuracy;

            combatInfo.PlayerRollDetails = $"{playerRoll} + {player.Accuracy + player.Weapon.Accuracy}";
            combatInfo.OpponentRollDetails = $"{opponentRoll} + {opponent.Accuracy + opponent.Weapon.Accuracy}";

            combatInfo.PlayerHealthLeft = player.Health;
            combatInfo.OpponentHealthLeft = opponent.Health;

            return combatInfo;
        }

        private CombatInfo Hit(CombatInfo combatInfo)
        {
            if (combatInfo.PlayerRollResult > combatInfo.OpponentRollResult)
            {
                //If player rolls higher
                combatInfo.Hit = "Player";
                int playerTotalStr = player.Strength + player.Weapon.Strength;
                int opponentTotalDef = opponent.Defence + opponent.Armor.Defence;

                if (playerTotalStr > opponentTotalDef)
                {
                    combatInfo.DamageDone = (playerTotalStr - opponentTotalDef);
                    opponent.Health -= combatInfo.DamageDone;

                    combatInfo.DamageDoneDetails = $"{playerTotalStr} - {opponentTotalDef}";
                }
                else
                {
                    combatInfo.DamageDone = 1;
                    opponent.Health -= combatInfo.DamageDone;

                    combatInfo.DamageDoneDetails = "Opponent's defence higher than players strength. Damage done 1.";
                }

                combatInfo.OpponentHealthLeft = opponent.Health;
            }
            else if (combatInfo.OpponentRollResult > combatInfo.PlayerRollResult)
            {
                //If opponent rolls higher
                combatInfo.Hit = "Opponent";
                int playerTotalDef = player.Defence + player.Armor.Defence;
                int opponentTotalStr = opponent.Strength + opponent.Weapon.Strength;

                if (opponentTotalStr > playerTotalDef)
                {
                    combatInfo.DamageDone = (opponentTotalStr - playerTotalDef);
                    player.Health -= combatInfo.DamageDone;

                    combatInfo.DamageDoneDetails = $"{opponentTotalStr} - {playerTotalDef}";
                }
                else
                {
                    combatInfo.DamageDone = 1;
                    player.Health -= combatInfo.DamageDone;

                    combatInfo.DamageDoneDetails = "Players's defence higher than opponents strength. Damage done 1.";
                }

                combatInfo.PlayerHealthLeft = player.Health;
            }
            else
            {
                //Even
                combatInfo.Hit = "Even";
                combatInfo.DamageDone = 1;
                player.Health -= combatInfo.DamageDone;
                opponent.Health -= combatInfo.DamageDone;

                combatInfo.DamageDoneDetails = "Even, both takes 1 damage.";
            }

            return combatInfo;
        }
    }
}
