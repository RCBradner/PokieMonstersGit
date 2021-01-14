using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Create New Monster")]
[System.Serializable]
public class MonsterBase : ScriptableObject
{
    public new string name;
    [TextArea]
    public string description;
    public Sprite frontSprite, backSprite;
    public AudioClip cry;
    public MonsterType type;
    public int maxHP, attack, defense, spAttack, spDefense, speed;
    public List<LearnableMove> learnableMoves;
}

[System.Serializable]
public class LearnableMove
{
    public MoveBase moveBase;
    public int levelLearned;
}

public enum MonsterType
{
    none,
    normal,
    fire,
    water,
    plant,
    lightning,
    earth,
    air
}
