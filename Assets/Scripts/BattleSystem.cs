using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using System.Collections;

namespace Assets.Scripts
{
    enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }

    public class BattleSystem : MonoBehaviour
    {

        BattleState state;

        public Transform playerZone;
        public Transform enemyZone;

        public GameObject playerPF;
        public GameObject enemyPF;

        public BattleHUD playerHUD;
        public BattleHUD enemyHUD;

        public TextMeshProUGUI dialogText;

        Unit playerUnit;
        Unit enemyUnit;


        private void Start()
        {
            state = BattleState.Start;
            StartCoroutine(SetupBattle());
        }

        private void Update() { }

        IEnumerator SetupBattle()
        {
            SpawnCreatures();

            dialogText.text = playerUnit.unitName + " and " + enemyUnit.unitName + " are in a fight!";

            playerHUD.SetHUD(playerUnit);
            enemyHUD.SetHUD(enemyUnit);

            yield return new WaitForSeconds(2f);

            state = BattleState.PlayerTurn;
            PlayerTurn();

        }

        void SpawnCreatures()
        {
            GameObject playerGO = Instantiate(playerPF, playerZone);
            playerUnit = playerGO.GetComponent<Unit>();

            GameObject enemyGO = Instantiate(enemyPF, enemyZone);
            enemyUnit = enemyGO.GetComponent<Unit>();
        }

        void PlayerTurn()
        {
            state = BattleState.PlayerTurn;
            dialogText.text = playerUnit.unitName + " chooses an action...";
        }

        void StartEnemyTurn()
        {
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }

        public void OnAttackButton()
        {
            if (state != BattleState.PlayerTurn) return;

            StartCoroutine(PlayerAttack());

        }
        public void OnHealButton()
        {
            if (state != BattleState.PlayerTurn) return;

            StartCoroutine(PlayerHeal());

        }

        IEnumerator PlayerHeal()
        {
            playerUnit.Heal(playerUnit.unitDamage / 2f);

            playerHUD.SetHp(playerUnit.curHealth);
            dialogText.text = playerUnit.unitName + " embraces lifestrengh. :)";

            yield return new WaitForSeconds(2f);

            StartEnemyTurn();

        }

        IEnumerator PlayerAttack()
        {
            bool isEnemyDead = enemyUnit.TakeDamage(playerUnit.unitDamage);

            enemyHUD.SetHp(enemyUnit.curHealth);
            dialogText.text = playerUnit.unitName + " attacked " + enemyUnit.unitName +"!";


            yield return new WaitForSeconds(2f);

            if (isEnemyDead) {
                state = BattleState.Won;
                EndBattle();
            
            }
            else
            {
                StartEnemyTurn();
            }
        }

        IEnumerator EnemyTurn()
        {
            state = BattleState.EnemyTurn;

            bool isPlayerDead = playerUnit.TakeDamage(enemyUnit.unitDamage);
            playerHUD.SetHp(playerUnit.curHealth);
            dialogText.text = enemyUnit.unitName + " attacked " + playerUnit.unitName + "!";

            yield return new WaitForSeconds(2f);

            if (isPlayerDead)
            {
                state = BattleState.Lost;
                EndBattle();

            }
            else
            { 
                PlayerTurn();
            }

        }

        void EndBattle()
        {
            if (state == BattleState.Won)
            {
                dialogText.text = playerUnit.unitName + " defeated " +
                    enemyUnit.unitName + "!" + " It was a great battle";
            }
            if (state == BattleState.Lost)
            {
                dialogText.text = enemyUnit.unitName + " defeated " +
                   playerUnit.unitName + "!" + " What a loser you are";
            }   

        }


    }
}
