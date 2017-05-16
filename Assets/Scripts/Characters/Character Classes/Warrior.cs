using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : BaseCharacter, IAbilityCharacter
{
    private void Start()
    {
        Strength = (int)(Strength * 1.2f);
    }

    public void ActivateAbility()
    {
        
    }
}
