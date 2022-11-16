using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI maxHPValue;
    public TMPro.TextMeshProUGUI hpValue;

    public void SetHUD(Fighter fighter)
    {
        nameText.text = fighter.fighterName;
        maxHPValue.text = $"/ {fighter.maxHP.ToString()}";
        hpValue.text = $"HP: {fighter.currentHP.ToString()}";
    }
    public void SetHP(int hp)
    {
        hpValue.text = $"HP: {hp.ToString()}";
    }
}
