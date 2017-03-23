using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : BaseCharacter
{
    private void Start()
    {
        Intelect = (int)(Intelect * 1.2f);
    }

    void RevealRoom(int intelect)
    {
        //Need to see how fog of war system works to advance
    }
}
