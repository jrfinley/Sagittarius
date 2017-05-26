using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : BaseCharacter,IAbilityCharacter
{
    private void Start()
    {
        Intelect = (int)(Intelect * 1.2f);

    }

    public void ActivateAbility()
    {
        
    }
}
