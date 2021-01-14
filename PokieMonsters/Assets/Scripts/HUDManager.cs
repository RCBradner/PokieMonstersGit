using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI nameText, levelText;
    public Slider hpBar;
    public TextMeshProUGUI hpValueText;
    public Slider xpBar;
    public bool isPlayer;

    public void SetData(Monster monster)
    {
        nameText.text = monster.nickName;
        levelText.text = "Lvl " + monster.level;
        hpBar.value = (float)(monster.hpCurrent / monster.MaxHP);

        if(isPlayer)
        {
            hpValueText.text = monster.hpCurrent + "/" + monster.MaxHP;
            xpBar.value = (float)(monster.xpCurrent - monster.XPForLevel(monster.level)) / (monster.XPForLevel(monster.level + 1) - monster.XPForLevel(monster.level));
        }
    }
}
