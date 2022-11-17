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

    public TMPro.TextMeshProUGUI dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private SceneChange sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        sceneChange = FindObjectOfType<SceneChange>();

        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleArea);
        playerFighter = playerGO.GetComponent<Fighter>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleArea);
        enemyFighter = enemyGO.GetComponent<Fighter>();

        dialogueText.text = "Encountered a " + enemyFighter.fighterName + " enemy";

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
        dialogueText.text = "Hero strikes at " + enemyFighter.fighterName;

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

    IEnumerator PlayerHeal()
    {
        playerFighter.Heal(5);

        playerHUD.SetHP(playerFighter.currentHP);
        dialogueText.text = "You healed 5 HP";

        yield return new WaitForEndOfFrame();

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerDidNothing()
    {
        dialogueText.text = "You wasted your turn";

        yield return new WaitForEndOfFrame();

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerRunAway()
    {
        dialogueText.text = "Run for your life!";

        yield return new WaitForSeconds(2f);
        sceneChange.SwitchScene();
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);

        dialogueText.text = enemyFighter.fighterName + " attacks!";

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
            dialogueText.text = "BATTLE WON!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "YOU WERE DEFEATED";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());

    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());

    }

    public void OnDoNothing()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerDidNothing());
    }

    public void OnEscape()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerRunAway());
    }
}
