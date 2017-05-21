using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatusEffectManager : MonoBehaviour
{
    public GameObject[] statusEffects;

    public List<GameObject> activeStatusEffects;

    public void AddStatusEffect(BaseCharacter character, int statusEffect)
    {
        GameObject newStatusEffect = Instantiate(statusEffects[statusEffect]);

        newStatusEffect.GetComponent<IStatusEffect>().InitializeStatusEffect(character, statusEffect);
    }
    public void AddStatusEffect(BaseCharacter character, string statusEffectName)
    {
        //GameObject newStatusEffect = Instantiate(statusEffects[statusEffect]);

        //newStatusEffect.GetComponent<IStatusEffect>().InitializeStatusEffect(character);
    }
}
