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
               experienceChange;

    public BaseCharacter baseCharacter;

    private void Start()
    {
        if (expirationType == EBuffExpiration.TIME_BASED)
        {

        }
    }

    IEnumerator Expire()
    {
        yield return new WaitForSeconds(expirationTime);


    }
}
