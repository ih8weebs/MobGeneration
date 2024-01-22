using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{

    public class CreatureCard
    {
        public string cardName;

        public double health;
        public double mana;

        public double attack;
        public double defence;

        public double strenght;
        public double agility;
        public double intellect;

        public Creature reference; //idk why I added this, it is useless i guess

        public CreatureCard() { }
        public CreatureCard(string aCardName, double aHealth, double aMana, double aAttack, double aDefence, double aStrenght, double aAgility, double aIntellcet, Creature aReference)
        {
            cardName = aCardName;

            health = aHealth;

            mana = aMana;

            attack = aAttack;

            defence = aDefence;

            strenght = Math.Round(aStrenght);

            agility = Math.Round(aAgility);

            intellect = Math.Round(aIntellcet);

            reference = aReference;
        }

        public CreatureCard CreatureCardFromCreature(Creature creature)
        {
            CreatureCard creatureCard = new CreatureCard(creature.name, creature.creatureStats.health.baseValue, creature.creatureStats.mana.baseValue,
               creature.creatureStats.attack.baseValue, creature.creatureStats.defence.baseValue,
               creature.creatureStats.strength.baseValue, creature.creatureStats.agility.baseValue, creature.creatureStats.intellect.baseValue, 
               creature);
            return creatureCard;
        }

    }
}

