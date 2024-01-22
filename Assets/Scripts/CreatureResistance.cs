using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Unity.VisualScripting;

namespace Assets.Scripts
{
    public class CreatureResistance
    {
        //{ fire, ice, water, air, earth, lightning }
        public Resistance fire;
        public Resistance ice;
        public Resistance water;
        public Resistance air;
        public Resistance earth;
        public Resistance lightning;
        public Resistance magical;
        public Resistance physical;
        public Resistance anyDamage;
        public Resistance stun;
        public Resistance effect;


        private static double max_ResistanceValue = 45.0;
        private static double min_ResistanceValue = 10.0;

        public CreatureResistance() { } 

        public CreatureResistance(double aFire, double aIce, double aWater, double aAir, double aEarth, double aLightning, double aMagical, double aPhysical, double aStun, double aEffect) 
        {
            fire = new Resistance();
            ice = new Resistance();
            water = new Resistance();
            air = new Resistance();
            earth = new Resistance();
            lightning = new Resistance();
            magical = new Resistance();
            physical = new Resistance();
            anyDamage = new Resistance();
            stun = new Resistance();
            effect = new Resistance();

            fire.baseValue = aFire;
            ice.baseValue = aIce;
            water.baseValue = aWater;
            air.baseValue = aAir;
            earth.baseValue = aEarth;
            lightning.baseValue = aLightning;
            magical.baseValue = aMagical;
            physical.baseValue = aPhysical;
            stun.baseValue = aStun;
            effect.baseValue = aEffect;

        }

        public CreatureResistance GetRandomResistance(Creature.Element element)
        {
            // Element { fire, ice, water, air, earth, lightning };
            // TODO: Resistance based on Creature.Element

            double fire=0;
            double ice=0;
            double water = 0;
            double air = 0;
            double earth = 0;
            double lightning = 0;

            double _big_buff = 20;
            double _small_buff = 10;
            double _small_debuff = -5;
            double _big_debuff = -10;


            switch (element) 
            {
                case Creature.Element.fire:
                    fire = _big_buff;
                    ice = _small_debuff;
                    water = _big_debuff;
                    air = _small_debuff;
                    earth = _small_debuff;
                    lightning = 0;
                    break;

                case Creature.Element.ice:
                    fire = _big_debuff;
                    ice = _big_buff;
                    water = _small_buff;
                    air = _small_buff;
                    earth = _big_debuff;
                    lightning = _small_debuff;
                    break;

                case Creature.Element.water:
                    fire = _small_debuff;
                    ice = _big_debuff;
                    water = _big_buff;
                    air = _small_debuff;
                    earth = _small_buff;
                    lightning = 0;
                    break;

                case Creature.Element.air:
                    fire = 0;
                    ice = 0;
                    water = 0;
                    air = 0;
                    earth = 0;
                    lightning = 0;
                    break;

                case Creature.Element.earth:
                    fire = 0;
                    ice = 0;
                    water = _small_debuff;
                    air = _small_debuff;
                    earth = _big_buff;
                    lightning = _big_debuff;
                    break;

                case Creature.Element.lightning:
                    fire = _big_debuff;
                    ice = 0;
                    water = 0;
                    air = 0;
                    earth = _big_buff;
                    lightning = _big_buff;
                    break;

                default: break;

            }


            System.Random rnd = new System.Random();
            fire += rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            ice += rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            water += rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            air += rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            earth += rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            lightning += rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            double magical = rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            double physical = rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            double stun = rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;
            double effect = rnd.NextDouble() * (max_ResistanceValue - min_ResistanceValue) + min_ResistanceValue;

            CreatureResistance randomResistance = new CreatureResistance(fire, ice, water, air, earth, lightning, magical, physical, stun, effect);
            return randomResistance;
        }

    }
}
