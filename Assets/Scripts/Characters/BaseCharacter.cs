﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    //Serialized almost all stats for easy testing and balancing purposes
    public delegate void BasicFunction();
    public event BasicFunction OnPartyMove;
    public event BasicFunction OnBattleStart;

    private bool dead;

    [SerializeField]
    private string characterName;

    [SerializeField]
    private int level,
                maxHealth,
                health,
                strength,
                dexterity,
                intelect,
                experience,
                equipmentCapacity;
    
    [SerializeField]
    private ECharacterType characterType;

    [SerializeField]
    private Sprite icon;
        
    public Item armor;
    public Item leftHand;
    public Item rightHand;
    public Item amulet;

    public List<string> statusEffectNames = new List<string>();
    public List<BaseStatusEffect> statusEffects = new List<BaseStatusEffect>();
    
    void SetStats()
    {
        dead = false;
        maxHealth = 10 * level;
        health = maxHealth;
        strength = 10 * level;
        dexterity = 10 * level;
        intelect = 10 * level;
        experience = level * 100 - 100;
        equipmentCapacity = strength * 2;
    }

    public void InitializeCharacter(string _name, int _level)
    {
        Name = _name;
        Level = _level;
    }
    public void EquipItem(Item item, int itemSlot)
    {
        switch (itemSlot)
        {
            case 1:
                if (item.ItemTypes.ItemType == EItemType.ARMOR)
                    break;

                if (armor != null)
                    RemoveItem(1);

                armor = item;
                break;

            case 2:
                if (item.ItemTypes.ItemType != EItemType.WEAPON)
                    break;

                if (leftHand != null)
                    RemoveItem(2);

                leftHand = item;
                break;

            case 3:
                if (item.ItemTypes.ItemType != EItemType.WEAPON)
                    break;

                if (rightHand != null)
                    RemoveItem(3);

                rightHand = item;
                break;

            default:
                if (item.ItemTypes.ItemType != EItemType.AMULET)
                    break;

                if (amulet != null)
                    RemoveItem(4);

                amulet = item;
                break;
        }

        MaxHealth += (int)item.ItemStats.Health;
        Health += (int)item.ItemStats.Health;
        Strength += (int)item.ItemStats.Strength;
        Dexterity += (int)item.ItemStats.Dexterity;
        Intelect += (int)item.ItemStats.Intelect;
    }
    public void RemoveItem(int itemPosition)
    {
        Item item;

        switch (itemPosition)
        {
            case 1:
                item = armor;
                armor = null;
                break;

            case 2:
                item = leftHand;
                leftHand = null;
                break;

            case 3:
                item = rightHand;
                rightHand = null;
                break;

            default:
                item = amulet;
                amulet = null;
                break;
        }

        MaxHealth -= (int)item.ItemStats.Health;
        Health -= (int)item.ItemStats.Health;
        Strength -= (int)item.ItemStats.Strength;
        Dexterity -= (int)item.ItemStats.Dexterity;
        Intelect -= (int)item.ItemStats.Intelect;
    }
    public void AddStatusEffect<T>(T statusEffect) where T: BaseStatusEffect
    {
        statusEffectNames.Add(statusEffect.name);
        statusEffects.Add(statusEffect);
        statusEffect.InitializeStatusEffect(this);
    }
    public void RemoveStatusEffect(EBuffType buffType)
    {
        for (int i = 0; i < statusEffects.Count; i++)
        {
            if (statusEffects[i].buffType == buffType)
            {
                statusEffects[i].RemoveStatusEffect();
                break;
            }
        }
    }
    public void OnMove()
    {
        OnPartyMove();
    }
    public void OnBattle()
    {
        OnBattleStart();
    }

    //Properties
    public int Level
    {
        get { return level; }
        set
        {
            level = value;
            SetStats();
        }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public int Health
    {
        get { return level; }
        set
        {
            health = value;
            health = Mathf.Clamp(health, 0, maxHealth);

            if (health == 0)
                dead = true;
            else
                dead = false;
        }
    }
    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }
    public int Dexterity
    {
        get { return dexterity; }
        set { dexterity = value; }
    }
    public int Intelect
    {
        get { return intelect; }
        set { dexterity = value; }
    }
    public int Experience
    {
        get { return experience; }
        set { experience = value; }
    }
    public int EquipmentCapacity
    {
        get { return equipmentCapacity; }
        set { equipmentCapacity = value; }
    }
    public string Name
    {
        get { return characterName; }
        set { characterName = value; }
    }
    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public ECharacterType CharacterType
    {
        get { return characterType; }
        set { characterType = value; }
    }
}
