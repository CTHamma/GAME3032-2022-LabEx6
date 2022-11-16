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

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();

    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleArea);
        playerFighter = playerGO.GetComponent<Fighter>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleArea);
        enemyFighter = enemyGO.GetComponent<Fighter>();

        Debug.Log("Encountered a " + enemyFighter.fighterName + " enemy");
    }
}
