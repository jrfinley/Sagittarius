using UnityEngine;
using System.Collections;
using System;

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

    public BaseMonster baseMonster;                    

    public void InitializeStatusEffect(BaseCharacter _baseCharacter)
    {
        baseCharacter = _baseCharacter;
        baseCharacter.Strength += strengthChange;
        baseCharacter.Dexterity += dexterityChange;
        baseCharacter.Intelect += intelectChange;
        if (buffType == EBuffType.EXP_BOOST)
            baseCharacter.ExpMultipier = experienceMultiplier;

        if (expirationType == EBuffExpiration.TIME_BASED)
            StartCoroutine(TimeExpire());
    }
    public void InitializeStatusEffect2(BaseMonster _baseMonster)
    {
        baseMonster = _baseMonster;
        baseMonster.statusEffects.Remove(this);
        baseMonster.statusEffectNames.Remove(statusName);
        Destroy(this);
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
        baseMonster.statusEffects.Remove(this);
        baseMonster.statusEffectNames.Remove(statusName);
        Destroy(this);
    }
    public void CountDownExpiration()
    {
        expirationTime--;

        if (expirationTime <= 0)
            RemoveStatusEffect();
    }

    IEnumerator TimeExpire()
    {
        yield return new WaitForSeconds(expirationTime);

        RemoveStatusEffect();
    }


}
