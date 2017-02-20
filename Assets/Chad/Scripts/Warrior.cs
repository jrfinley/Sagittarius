using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    private BaseCharacter character;

    public void GiveCharStats(BaseCharacter _character)
    {
        character = _character;
    }

    void BreakOpenDoor()
    {
        //Need to see how doors will work to advance
    }
}
