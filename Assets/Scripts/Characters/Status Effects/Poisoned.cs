using UnityEngine;
using System.Collections;

public class Poisoned : BaseStatusEffect
{
    private void Start()
    {
        baseCharacter.OnPartyMove += ApplyPoison;
    }

    public void ApplyPoison()
    {
        baseCharacter.Health += healthChange;
        expirationTime -= 1;

        if (expirationTime <= 0)
        {
            baseCharacter.OnPartyMove -= ApplyPoison;
            RemoveStatusEffect();
        }
    }
}
