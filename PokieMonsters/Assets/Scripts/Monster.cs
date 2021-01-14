using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public string nickName;
    public MonsterBase monsterBase;
    public int level;
    public int hpCurrent;
    public int xpCurrent;
    public int xpToNextLevel;

    public List<Move> knownMoves;

    public bool isFainted = false;

    public Monster(MonsterBase pBase, int pLevel)
    {
        nickName = pBase.name;
        monsterBase = pBase;
        level = pLevel;
        hpCurrent = MaxHP;
        xpCurrent = XPForLevel(pLevel);
        xpToNextLevel = XPForLevel(pLevel + 1) - xpCurrent;
        knownMoves = new List<Move>();

        foreach(LearnableMove lMove in pBase.learnableMoves)
        {
            if(pLevel <= lMove.levelLearned)
            {
                Move move = new Move(lMove.moveBase);
                knownMoves.Add(move);
                if (knownMoves.Count > 4)
                {
                    knownMoves.RemoveAt(0);
                }
            }
        }
    }

    public int MaxHP
    {
        get { return Mathf.FloorToInt((monsterBase.maxHP * level) / 100f) + 10; }
    }
    public int Attack
    {
        get { return Mathf.FloorToInt((monsterBase.attack * level) / 100f) + 5; }
    }
    public int Defense
    {
        get { return Mathf.FloorToInt((monsterBase.defense * level) / 100f) + 5; }
    }
    public int SpAttack
    {
        get { return Mathf.FloorToInt((monsterBase.spAttack * level) / 100f) + 5; }
    }
    public int SpDefense
    {
        get { return Mathf.FloorToInt((monsterBase.spDefense * level) / 100f) + 5; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((monsterBase.speed * level) / 100f) + 5; }
    }
    public int XPForLevel(int level)
    {
        return ((int)Mathf.Pow(level, 3));
    }
}
