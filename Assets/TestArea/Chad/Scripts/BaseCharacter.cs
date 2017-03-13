using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    //Serialized all stats for easy testing and balancing purposes

    private bool dead;

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
    private string name;
    
    [SerializeField]
    private ECharacterType charType;

    /*
    For when we have items ready
        
    public Item armor;
    public Item leftHand;
    public Item rightHand;
    public Item amulet;
    */
    
    void SetCharacterType()
    {
        switch ((int)charType)
        {
            case 0:
                Warrior classTypeA = GetComponent<Warrior>();
                if (classTypeA == null)
                {
                    classTypeA = gameObject.AddComponent<Warrior>();
                }
                break;

            case 1:

                Rogue classTypeB = GetComponent<Rogue>();
                if (classTypeB == null)
                {
                    classTypeB = gameObject.AddComponent<Rogue>();
                }
                break;

            case 2:
                Mage classTypeC = GetComponent<Mage>();
                if (classTypeC == null)
                {
                    classTypeC = gameObject.AddComponent<Mage>();
                }
                break;
        }
    }
    void SetStats()
    {
        dead = false;
        maxHealth = 10 * level;
        health = maxHealth;
        experience = level * 100 - 100;

        switch ((int)charType)
        {
            case 0:
                strength = 12 * level;
                dexterity = 10 * level;
                intelect = 10 * level;
                break;

            case 1:
                strength = 10 * level;
                dexterity = 12 * level;
                intelect = 10 * level;
                break;

            case 2:
                strength = 10 * level;
                dexterity = 10 * level;
                intelect = 12 * level;
                break;
        }
        equipmentCapacity = strength * 2;
    }

    /*
    For when we have items ready 
     
    public void EquipItem(Item item)
    {
        switch (item.itemType)
        {
            case armor:
                armor = item;
                break;

            case hand:
                Not sure how to distinguish between lft and rgt hand yet
                break;

            case amulet:
                amulet = item;
                break;
        }
    }
    */
    
    //Getters
    public string GetName()
    {
        return name;
    }
    public bool GetDeathStatus()
    {
        return dead;
    }
    public int GetLevel()
    {
        return level;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetStrength()
    {
        return strength;
    }
    public int GetDexterity()
    {
        return dexterity;
    }
    public int GetIntelect()
    {
        return intelect;
    }
    public int GetExperience()
    {
        return experience;
    }
    public int GetEquipmentCapacity()
    {
        return equipmentCapacity;
    }
    public ECharacterType GetCharType()
    {
        return charType;
    }

    //Setters
    public void AlterMaxHealth(int changeAmout)
    {
        maxHealth += changeAmout;
    }
    public void AlterHealth(int changeAmout)
    {
        health += changeAmout;

        if (health > 0)
        {
            dead = false;
        }
        else
        {
            health = 0;
            dead = true;
        }
    }
    public void AlterStrength(int changeAmout)
    {
        strength += changeAmout;
    }
    public void AlterDexterity(int changeAmout)
    {
        dexterity += changeAmout;
    }
    public void AlterIntelect(int changeAmout)
    {
        intelect += changeAmout;
    }
    public void AlterExperience(int changeAmout)
    {
        experience += changeAmout;
    }
    public void AlterEquipmentCapacity(int changeAmount)
    {
        equipmentCapacity += changeAmount;
    }
    public void LevelUp(int _level, int _maxHealth, int _health, int _strength,
                            int _dexterity, int _intelect, int _experience)
    {
        level += _level;
        maxHealth += _maxHealth;
        health += _health;
        strength += _strength;
        dexterity += _dexterity;
        intelect += _intelect;
        experience += _experience;
    }
    public void SetName(string _name)
    {
        name = _name;
    }
    public void InitializeCharacter(string _name, ECharacterType _charType, int _level)
    {
        name = _name;
        charType = _charType;
        level = _level;

        SetStats();
        SetCharacterType();
    }
}
