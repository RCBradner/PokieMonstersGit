using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "Create new Move")]
public class MoveBase : ScriptableObject
{
    public new string name;
    [TextArea]
    public string description;
    public int power, accuracy, staminaBase;
    public MonsterType type;

}
