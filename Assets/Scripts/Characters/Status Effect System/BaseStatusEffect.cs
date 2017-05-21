using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatusEffect : MonoBehaviour
{
    public EBuffExpiration expireType;
    public EBuffType buffType;

    [SerializeField]
    private int healthChange,
                strengthChange,
                dexterityChange,
                intelectChange,
                experienceChange,
                equipmentCapacityChange;

    private int iterationNumber;

    [SerializeField]
    private float expireTime,
                  expMultiplierChange;

    private BaseCharacter character;
    private PlayerEventManager eventManager;
    private StatusEffectManager effectManager;

    //properties
    public EBuffExpiration ExpireType
    {
        get { return expireType; }
        set { expireType = value; }
    }
    public EBuffType BuffType
    {
        get { return buffType; }
        set { buffType = value; }
    }
    public int HealthChange
    {
        get { return healthChange; }
        set { healthChange = value; }
    }
    public int StrengthChange
    {
        get { return strengthChange; }
        set { strengthChange = value; }
    }
    public int DexterityChange
    {
        get { return dexterityChange; }
        set { dexterityChange = value; }
    }
    public int IntelectChange
    {
        get { return intelectChange; }
        set { intelectChange = value; }
    }
    public int ExperienceChange
    {
        get { return experienceChange; }
        set { experienceChange = value; }
    }
    public int EquipmentCapacityChange
    {
        get { return equipmentCapacityChange; }
        set { equipmentCapacityChange = value; }
    }
    public int IterationNumber
    {
        get { return iterationNumber; }
        set { iterationNumber = value; }
    }
    public float ExpireTime
    {
        get { return expireTime; }
        set { expireTime = value; }
    }
    public float ExpMultiplierChange
    {
        get { return expMultiplierChange; }
        set { expMultiplierChange = value; }
    }
    public BaseCharacter Character
    {
        get { return character; }
        set { character = value; }
    }
    public PlayerEventManager EventManager
    {
        get { return eventManager; }
        set { eventManager = value; }
    }
    public StatusEffectManager EffectManager
    {
        get { return effectManager; }
        set { effectManager = value; }
    }
}
