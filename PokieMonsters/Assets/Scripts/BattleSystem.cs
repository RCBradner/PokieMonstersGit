using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleUnit playerUnit, enemyUnit;
    public HUDManager playerHUD, enemyHUD;
    MonsterParty playerParty;

    public void StartBattle(MonsterParty party, Monster enemy)
    {
        playerParty = party;
        Monster playerMon = party.NextUsableMonster();

        playerUnit.SetSprite(playerMon, true);
        enemyUnit.SetSprite(enemy, false);

        playerHUD.SetData(playerMon);
        enemyHUD.SetData(enemy);
    }

}
