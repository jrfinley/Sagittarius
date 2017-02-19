using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    private BaseCharacter character;

    public void GiveCharStats(BaseCharacter _character)
    {
        character = _character;
    }
}
