using UnityEngine;
using System.Collections;

public class StatusEffectManager : MonoBehaviour
{
    public GameObject[] statusEffects;

    public void AddStatusEffect(BaseCharacter character, int statusEffect)
    {
        GameObject newStatusEffect = Instantiate(statusEffects[statusEffect]);

        newStatusEffect.GetComponent<IStatusEffect>().InitializeStatusEffect(character);
    }
}
