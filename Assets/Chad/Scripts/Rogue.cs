using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    private BaseCharacter character;

    public void GiveCharStats(BaseCharacter _character)
    {
        character = _character;
    }

    void PickLock()
    {
        //Need to see how door/loot system works to advance
    }
}
