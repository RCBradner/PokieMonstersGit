using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParty : MonoBehaviour
{
    public List<Monster> party = new List<Monster>();
    public bool isFull = false;

    public void AddMonster(Monster mon)
    {
        if(isFull)
        {
            Debug.Log("Party is full.");
            return;
        }
        party.Add(mon);

        if(party.Count == 6)
        {
            isFull = true;
        }
    }

    public Monster NextUsableMonster()
    {
        Monster mon = party[0];
        for (int i = 1; i < party.Count - 1; i++)
        {
            if (mon.isFainted)
            {
                mon = party[i];
            }
        }
        return mon;
    }

    public bool OutOfMonsters()
    {
        bool isOut = true;
        foreach (Monster mon in party)
        {
            if (mon.isFainted)
            {
                continue;
            }
            else isOut = false;
        }
        return isOut;
    }
}
