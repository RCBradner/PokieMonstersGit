using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public MoveBase Base {get; set;}
    public int staminaCurrent;

    public Move(MoveBase pBase)
    {
        Base = pBase;
        staminaCurrent = pBase.staminaBase;
    }
}
