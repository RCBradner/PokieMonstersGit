using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    public void SetSprite(Monster monster, bool isPlayer)
    {
        if(isPlayer)
        {
            GetComponent<Image>().sprite = monster.monsterBase.backSprite;
        }
        else
        {
            GetComponent<Image>().sprite = monster.monsterBase.frontSprite;
        }
    }
}
