using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Creature
    {
        public enum Element { fire, ice, water, air, earth, lightning };
        public enum Characteristic { hidden, mighty, agile, wise };
        public enum Rarity { common, rare, unique, ancient, legendary, mythical };
        public enum CreatureType { wywern, dragon, bear, wolf };

        /*
         * Creature has stats f.e. mana, hp, stamina, resistances, 
         */

        public Element element;

        public Characteristic characteristic;

        public Rarity rarity;

        public CreatureType type;

        public string name;

        public CreatureStats creatureStats;  

        public Creature() { }

        public Creature(Element aElement, Characteristic aCharacteristic, Rarity aRarity, CreatureType aCreatureType)
        {
            element = aElement;
            characteristic = aCharacteristic;
            rarity = aRarity;
            type = aCreatureType;

            name = aRarity.ToString() + " " + aCharacteristic.ToString() + " " + aElement.ToString() + " " + aCreatureType.ToString();

            creatureStats = new CreatureStats().GetRandomStats(element, rarity);
        }

        public Creature GetRandomCreature()
        {
            var elementsLenght = Enum.GetNames(typeof(Element)).Length;
            var characteristicLenght = Enum.GetNames(typeof(Characteristic)).Length;
            var rarityLenght = Enum.GetNames(typeof(Rarity)).Length;
            var creatureTypeLenght = Enum.GetNames(typeof(CreatureType)).Length;

            System.Random rnd = new System.Random();
            int element = rnd.Next(0, elementsLenght);
            int characteristic = rnd.Next(0, characteristicLenght);
            int rarity = rnd.Next(0, rarityLenght);
            int type = rnd.Next(0, creatureTypeLenght);

            Creature randomCreature = new Creature((Element)element, (Characteristic)characteristic, (Rarity)rarity, (CreatureType)type);

            return randomCreature;
        }

        public Creature GetCreature(Creature creature)
        {
            return creature;
        }

    }
}
