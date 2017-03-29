using UnityEngine;
using System.Collections;

public class BaseStatusEffect : MonoBehaviour
{
    public EBuffType buffType;
    public EBuffExpiration expirationType;

    public float expirationTime;

    public int healthChange,
               strengthChange,
               dexterityChange,
               intelectChange,
               experienceMultiplier;

    public string statusName;

    public BaseCharacter baseCharacter;

    public void InitializeStatusEffect(BaseCharacter _baseCharacter)
    {
        baseCharacter = _baseCharacter;
        baseCharacter.Strength += strengthChange;
        baseCharacter.Dexterity += dexterityChange;
        baseCharacter.Intelect += intelectChange;
        if (buffType == EBuffType.EXP_BOOST)
            baseCharacter.ExpMultipier = experienceMultiplier;

        if (expirationType == EBuffExpiration.TIME_BASED)
            StartCoroutine(Expire());
    }
    public void RemoveStatusEffect()
    {
        baseCharacter.Strength -= strengthChange;
        baseCharacter.Dexterity -= dexterityChange;
        baseCharacter.Intelect -= intelectChange;
        if (buffType == EBuffType.EXP_BOOST)
            baseCharacter.ExpMultipier = 1;

        baseCharacter.statusEffects.Remove(this);
        baseCharacter.statusEffectNames.Remove(statusName);
        Destroy(this);
    }

    IEnumerator Expire()
    {
        yield return new WaitForSeconds(expirationTime);

        RemoveStatusEffect();
    }
}
