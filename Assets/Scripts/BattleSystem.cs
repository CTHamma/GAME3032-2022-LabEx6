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

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();

    }

    void SetupBattle()
    {
        Instantiate(playerPrefab, playerBattleArea);
        Instantiate(enemyPrefab, enemyBattleArea);
    }
}
