using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public string fighterName;
    public int damage;
    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        // check if the figher has died
        if (currentHP <= 0)
        {
            return true; // Has died
        }
        else 
            return false; // Not dead yet
    }

    public void Heal (int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
