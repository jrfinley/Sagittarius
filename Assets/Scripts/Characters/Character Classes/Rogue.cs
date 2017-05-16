using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : BaseCharacter, IAbilityCharacter
{
    private void Start()
    {
        Dexterity = (int)(Dexterity * 1.2f);
    }

    public void ActivateAbility()
    {
        
    }
}
