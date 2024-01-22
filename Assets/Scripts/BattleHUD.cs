using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BattleHUD : MonoBehaviour
    {
        // Start is called before the first frame update
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI levelText;

        public TextMeshProUGUI hpText;

        public Slider hpSlider;

        private float maxHP;
        private float curHP;

        public void SetHUD(Unit unit)
        {
            nameText.text = unit.unitName;
            levelText.text = "Lvl " + unit.unitLevel;

            maxHP = unit.maxHealth;
            curHP = unit.curHealth;

            hpText.text = (curHP).ToString() + "/" + (maxHP).ToString();

            hpSlider.maxValue = maxHP;
            hpSlider.value = curHP;

        }

        public void SetHp(float hp)
        {
            curHP = hp;
            UpdateHUD();
        }

        private void UpdateHUD()
        {
            hpText.text = (curHP).ToString() + "/" + (maxHP).ToString();

            hpSlider.maxValue = maxHP;
            hpSlider.value = curHP;
        }

    }
}
