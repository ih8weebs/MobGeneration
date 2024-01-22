using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class BehaviourCCard : MonoBehaviour
    {

        public TextMeshProUGUI cardNameTMP;
        public TextMeshProUGUI healthTMP;
        public TextMeshProUGUI manaTMP;
        public TextMeshProUGUI attackTMP;
        public TextMeshProUGUI defenceTMP;
        public TextMeshProUGUI strengthTMP;
        public TextMeshProUGUI agilityTMP;
        public TextMeshProUGUI intellectTMP;

        Creature creature;

        void Start()
        {
            creature = new Creature().GetRandomCreature();
            ChangeProperties(RandomCreatureCard());
        }

        CreatureCard RandomCreatureCard()
        {
            CreatureCard creatureCard = new CreatureCard().CreatureCardFromCreature(creature);
            return creatureCard;
        }

        void ChangeProperties(CreatureCard creatureCard)
        {
            cardNameTMP.text = creatureCard.cardName;
            healthTMP.text = creatureCard.health.ToString();
            manaTMP.text = creatureCard.mana.ToString();
            attackTMP.text = creatureCard.attack.ToString();
            defenceTMP.text = creatureCard.defence.ToString();
            strengthTMP.text = creatureCard.strenght.ToString();
            agilityTMP.text = creatureCard.agility.ToString();
            intellectTMP.text = creatureCard.intellect.ToString();
        }

        void DebugLogShowCreature(Creature creature)
        {
            Debug.Log("------Creature-----");
            Debug.Log("Name: " + creature.name);
            Debug.Log("Element: " + creature.element);
            Debug.Log("Characteristic: " + creature.characteristic);
            Debug.Log("Rarity: " + creature.rarity);
            Debug.Log("-------Stats----- ");
            Debug.Log("HP: " + creature.creatureStats.health.maxValue);
            Debug.Log("Mana: " + creature.creatureStats.mana.maxValue);
            Debug.Log("Attack: " + creature.creatureStats.attack.baseValue);
            Debug.Log("Defence: " + creature.creatureStats.defence.baseValue);
            Debug.Log("Strength: " + creature.creatureStats.strength.baseValue);
            Debug.Log("Agility: " + creature.creatureStats.agility.baseValue);
            Debug.Log("Intellect: " + creature.creatureStats.intellect.baseValue);
            Debug.Log("------Resists------");
            Debug.Log("Fire: " + creature.creatureStats.creatureResistance.fire.baseValue);
            Debug.Log("Ice: " + creature.creatureStats.creatureResistance.ice.baseValue);
            Debug.Log("Water: " + creature.creatureStats.creatureResistance.water.baseValue);
            Debug.Log("Air: " + creature.creatureStats.creatureResistance.air.baseValue);
            Debug.Log("Earth: " + creature.creatureStats.creatureResistance.earth.baseValue);
            Debug.Log("Lightning: " + creature.creatureStats.creatureResistance.lightning.baseValue);
        }

    }
}

