using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    //Serialized almost all stats for easy testing and balancing purposes
    private bool dead,
                 isPartyMember,
                 isTraining;

    [SerializeField]
    private string characterName;

    [SerializeField]
    private int level,
                maxHealth,
                health,
                strength,
                dexterity,
                intelect,
                foodConsumption,
                experience,
                maxExperience,
                equipmentCapacity,
                characterWeight,
                partyPosition;

    private float expMultiplier = 1;
    
    [SerializeField]
    private ECharacterType characterType;

    [SerializeField]
    private Sprite icon;

    private PlayerParty playerParty;

    public bool isUnlocked = true;
    public bool hasStatusEffect = false;

    public List<int> statusEffects = new List<int>();

    public Item armor;
    public Item leftHand;
    public Item rightHand;
    public Item amulet;

    private void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();
    }
    void SetStats()
    {
        dead = false;
        maxHealth = 10 * level;
        health = maxHealth;
        strength = 10 * level;
        dexterity = 10 * level;
        intelect = 10 * level;
        experience = level * 100 - 100;
        maxExperience = maxExperience * level * 2;
        equipmentCapacity = strength * 2;
    }

    public void InitializeStatusEffects(List<int> savedStatusEffects)
    {
        StatusEffectManager effectManager = FindObjectOfType<StatusEffectManager>();

        if (savedStatusEffects.Count > 0)
            for (int i = 0; i < statusEffects.Count; i++)
                effectManager.AddStatusEffect(this, statusEffects[i]);
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
                if (item.Types.ItemType != EItemType.ARMOR)
                    break;

                if (armor != null)
                    RemoveItem(1);

                armor = item;
                break;

            case 2:
                if (item.Types.ItemType != EItemType.HELD)
                    break;

                if (leftHand != null)
                    RemoveItem(2);

                leftHand = item;
                break;

            case 3:
                if (item.Types.ItemType != EItemType.HELD)
                    break;

                if (rightHand != null)
                    RemoveItem(3);

                rightHand = item;
                break;

            default:
                if (item.Types.ItemType != EItemType.AMULET)
                    break;

                if (amulet != null)
                    RemoveItem(4);

                amulet = item;
                break;
        }

        MaxHealth += (int)item.Stats.Health;
        Health += (int)item.Stats.Health;
        Strength += (int)item.Stats.Strength;
        Dexterity += (int)item.Stats.Dexterity;
        Intelect += (int)item.Stats.Intelect;
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

        MaxHealth -= (int)item.Stats.Health;
        Health -= (int)item.Stats.Health;
        Strength -= (int)item.Stats.Strength;
        Dexterity -= (int)item.Stats.Dexterity;
        Intelect -= (int)item.Stats.Intelect;
    }

    //Properties
    public bool IsPartyMember
    {
        get { return isPartyMember; }
        set { isPartyMember = value; }
    }
    public bool IsTraining
    {
        get { return isTraining; }
        set { isTraining = value; }
    }
    public bool Dead
    {
        get { return dead; }
    }
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
            {
                dead = true;
                if (IsPartyMember)
                    playerParty.equipmentLoad += characterWeight;
            }
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
        set { intelect = value; }
    }
    public int FoodConsumption
    {
        get { return foodConsumption; }
        set { foodConsumption = value; }
    }
    public int Experience
    {
        get { return experience; }
        set
        {
            experience = (int)(value * expMultiplier);

            if (experience >= maxExperience)
                Level++;
        }
    }
    public int MaxExperience
    {
        get { return MaxExperience; }
        set { maxExperience = value; }
    }
    public int EquipmentCapacity
    {
        get { return equipmentCapacity; }
        set { equipmentCapacity = value; }
    }
    public int CharacterWeight
    {
        get { return characterWeight; }
        set { characterWeight = value; }
    }
    public int PartyPosition
    {
        get { return partyPosition; }
        set { partyPosition = value; }
    }
    public float ExpMultipier
    {
        get { return expMultiplier; }
        set { expMultiplier = value; }
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
