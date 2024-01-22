using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Unit : MonoBehaviour
    {
        public string unitName;

        public int unitLevel;

        public int unitDamage;

        public float curHealth;
        public float maxHealth;


        public bool TakeDamage(int damage)
        {
            curHealth -= damage;

            if (curHealth <= 0) return true; 
            else return false;
        }

        public void Heal(float amount) 
        {
            curHealth += amount;
            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }
        
        }

    }
}
