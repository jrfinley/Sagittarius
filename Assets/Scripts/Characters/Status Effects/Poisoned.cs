using UnityEngine;
using System.Collections;

public class Poisoned : BaseStatusEffect
{
    public void ApplyPoison()
    {
        baseCharacter.Health += healthChange;
    }
}
