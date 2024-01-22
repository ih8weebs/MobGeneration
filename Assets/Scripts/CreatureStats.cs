using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class CreatureStats
    {
        public Attribute health;
        public Attribute mana;

        public Stat attack;
        public Stat defence;

        public Stat strength;
        public Stat agility;
        public Stat intellect;

        private int statMultiplier;

        //???????????
        private const int max_baseHealth = 2000;
        private const int max_baseMana = 2000;
        private const double max_strength = 100;
        private const double max_agility = 100;
        private const double max_intellect = 100;

        private const int min_baseHealth = 100;
        private const int min_baseMana = 100;
        private const double min_strength = 1;
        private const double min_agility = 1;
        private const double min_intellect = 1;


        public CreatureResistance creatureResistance;
  
        public CreatureStats() { }

        public CreatureStats(int aBaseHealth, int aBaseMana, double aStrenght, double aAgility, double aIntellect, Creature.Element aElement, Creature.Rarity aRarity) 
        {
            health = new Attribute();
            mana = new Attribute();

            attack = new Stat();
            defence = new Stat();
            strength = new Stat();
            agility = new Stat();
            intellect = new Stat();


            health.baseValue = aBaseHealth; 
            mana.baseValue = aBaseMana;
            strength.baseValue = aStrenght;
            agility.baseValue = aAgility;
            intellect.baseValue = aIntellect;

            attack.baseValue = 1 + Math.Round(strength.baseValue + agility.baseValue) / 2.0;
            defence.baseValue = 1 + Math.Round((intellect.baseValue + agility.baseValue) / 2.0);

            health.maxValue = health.baseValue + 25 * Math.Round(strength.baseValue + (agility.baseValue / 2.0));
            mana.maxValue = mana.baseValue + 20 * Math.Round(intellect.baseValue + (agility.baseValue / 2.0));

            //TODO: health and mana class

            creatureResistance = new CreatureResistance().GetRandomResistance(aElement);


        }

        public CreatureStats GetRandomStats(Creature.Element element, Creature.Rarity rarity) 
        {
            System.Random rnd = new System.Random();
            int baseHealth = (int)Math.Round(SetStatMultiplier(rarity) * rnd.Next(min_baseHealth, max_baseHealth));
            int baseMana = (int)Math.Round(SetStatMultiplier(rarity) * rnd.Next(min_baseMana, max_baseMana));
            double strength = SetStatMultiplier(rarity) * rnd.NextDouble()*(max_strength - min_strength) + min_strength;
            double agility = SetStatMultiplier(rarity) * rnd.NextDouble()*(max_agility - min_agility) + min_agility;
            double intellect = SetStatMultiplier(rarity) * rnd.NextDouble()*(max_intellect - min_intellect) + min_intellect;


            CreatureStats randomStats = new CreatureStats(baseHealth, baseMana, strength, agility, intellect, element, rarity); 
            return randomStats;
        }
        //public enum Rarity { common, rare, unique, ancient, legendary, mythical };
        private double SetStatMultiplier(Creature.Rarity rarity)
        {
            double multiplier = 1.0;
            switch (rarity)
            {
                case Creature.Rarity.common:
                    break;
                case Creature.Rarity.rare:
                    multiplier = 1.5; break;
                case Creature.Rarity.ancient:
                    multiplier = 2; break;
                case Creature.Rarity.mythical:
                    multiplier = 2.5; break;
                case Creature.Rarity.legendary:
                    multiplier = 3; break;
                case Creature.Rarity.unique:
                    multiplier = 3.5; break;
                default: break;
            }

            return multiplier;
        }

    }
}
