using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleArea;
    public Transform enemyBattleArea;

    Fighter playerFighter;
    Fighter enemyFighter;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleArea);
        playerFighter = playerGO.GetComponent<Fighter>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleArea);
        enemyFighter = enemyGO.GetComponent<Fighter>();

        Debug.Log("Encountered a " + enemyFighter.fighterName + " enemy");

        playerHUD.SetHUD(playerFighter);
        enemyHUD.SetHUD(enemyFighter);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        // Damage the enemy
        bool isDead = enemyFighter.TakeDamage(playerFighter.damage);

        enemyHUD.SetHP(enemyFighter.currentHP);
        Debug.Log("Hero strikes at " + enemyFighter.fighterName);

        yield return new WaitForEndOfFrame();

        if(isDead)
        {
            // End the battle
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            // Enemy turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);

        Debug.Log(enemyFighter.fighterName + " attacks!");

        yield return new WaitForSeconds(1f);

        bool isDead = playerFighter.TakeDamage(playerFighter.damage);

        playerHUD.SetHP(playerFighter.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            Debug.Log("BATTLE WON!");
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("YOU WERE DEFEATED");
        }
    }

    void PlayerTurn()
    {
        Debug.Log("Choose and action");
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());

    }
}
