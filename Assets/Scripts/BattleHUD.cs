using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TMPro.TextMeshPro nameText;
    public TMPro.TextMeshPro maxHPValue;
    public TMPro.TextMeshPro hpValue;

    public void SetHUD(Fighter fighter)
    {
        nameText.text = fighter.fighterName;
        maxHPValue.text = fighter.maxHP.ToString();
        hpValue.text = fighter.currentHP.ToString();
    }
}
