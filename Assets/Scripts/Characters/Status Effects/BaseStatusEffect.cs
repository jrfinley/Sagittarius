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

        if (expirationType == EBuffExpiration.TIME_BASED)
            StartCoroutine(TimeExpire());
    }
    public void RemoveStatusEffect()
    {
        baseCharacter.statusEffects.Remove(this);
        baseCharacter.statusEffectNames.Remove(statusName);
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
