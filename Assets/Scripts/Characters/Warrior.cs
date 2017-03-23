using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : BaseCharacter
{
    private void Start()
    {
        Strength = (int)(Strength * 1.2f);
    }

    void BreakOpenDoor(int strength)
    {
        //Need to see how doors will work to advance
    }
}
