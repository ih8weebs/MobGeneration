using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class CreatureAbilities
    {
    
        public enum ActiveSpell {damage, heal, buff, debuff }
        public enum PassiveTalent {damage, heal, buff, debuff }
       
        public ActiveSpell spell;
        public PassiveTalent talent;

        public int effectTime;
        public double spellImpactValue;
        public double cost;

        public bool targetEnemies;
        public bool targetAlies;

        public bool costMana;
        public bool costHealth;
        public bool costStamina;

        public CreatureAbilities()
        {

        }


    }
}
