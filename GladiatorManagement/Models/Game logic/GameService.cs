using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GladiatorManagement.Models.Game_logic
{
    public class GameService
    {
        public GameService()
        {

        }

        public void LaunchCombat(int playerGladiatorId, int opponentGladiatorId)
        {
            Gladiator player = null;
            Gladiator opponent = null;

            player = new PlayerGladiator("Dennis", 5, 5, 10, 2);
            opponent = new Gladiator("Jojje", 5, 6, 11, 3);

            //player = FindGladiator(playerGladiatorId);
            //opponent = FindGladiator(opponentGladiatorId);
  

            PlayerGladiator p = player as PlayerGladiator;
            PlayerGladiator o = opponent as PlayerGladiator;

            Combat combat = null;

            if (p != null)
            {
                p.Weapon.Strength += 1;
                p.Weapon.Accuracy += 1;
                p.Armor.Defence += 1;
                p.Armor.Health += 1;

                player.Strength += p.Weapon.Strength;
                player.Accuracy += p.Weapon.Accuracy;
                player.Defence += p.Armor.Defence;
                player.Health += p.Armor.Health;
            }
            if(o != null)
            {
                opponent.Strength += o.Weapon.Strength;
                opponent.Accuracy += o.Weapon.Accuracy;
                opponent.Defence += o.Armor.Defence;
                opponent.Health += o.Armor.Health;
            }

            combat = new Combat(player, opponent);

            List<CombatInfo> listOfCombatDetails = combat.StartCombat();

            if (p != null)
            {
                player.Strength -= p.Weapon.Strength;
                player.Accuracy -= p.Weapon.Accuracy;
                player.Defence -= p.Armor.Defence;
                player.Health -= p.Armor.Health;
            }
            if (o != null)
            {
                opponent.Strength -= o.Weapon.Strength;
                opponent.Accuracy -= o.Weapon.Accuracy;
                opponent.Defence -= o.Armor.Defence;
                opponent.Health -= o.Armor.Health;
            }
        }
        
    }
}
