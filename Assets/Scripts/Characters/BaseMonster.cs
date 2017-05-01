using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    public EMonsterType monsterType;

    public int level;

    private bool dead;

    public int maxHealth,
                health,
                attack,
                defense;

    public GameObject itemEx;

    [SerializeField]
    private Sprite icon;

    public List<string> statusEffectNames = new List<string>();
    public List<BaseStatusEffect> statusEffects = new List<BaseStatusEffect>();

    void Start()
    {
        InitializeMonster();
        
    }

    void InitializeMonster()
    {       
        SetStats();
        Kill();
    }
    void SetStats()
    {
        
        switch ((int)monsterType)
        {
            case 0:
                maxHealth = level * 12;
                attack = level * 10;
                defense = level * 10;
                break;

            case 1:
                maxHealth = level * 10;
                attack = level * 12;
                defense = level * 10;
                break;

            case 2:
                maxHealth = level * 10;
                attack = level * 10;
                defense = level * 12;
                break;
        }

        dead = false;
        health = maxHealth;
    }

    //Getters
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
    public int GetAttack()
    {
        return attack;
    }
    public int GetDefense()
    {
        return defense;
    }
    public Sprite GetIcon()
    {
        return icon;
    }

    //Setters
    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }
    public void SetMaxHealth(int changeAmount)
    {
        maxHealth += changeAmount;
    }
    public void SetHealth(int changeAmount)
    {
        health += changeAmount;
    }
    public void SetAttack(int changeAmount)
    {
        attack += changeAmount;
    }
    public void SetDefense(int changeAmount)
    {
        defense += changeAmount;
    }
    public void SetIcon(Sprite newIcon)
    {
        icon = newIcon;
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

            if(dead == true)
            LootDrop();
           
            else
                dead = false;
        }
    }

    public void AddStatusEffect<T>(T statusEffect) where T : BaseStatusEffect
    {
        statusEffectNames.Add(statusEffect.statusName);
        statusEffects.Add(statusEffect);
        statusEffect.InitializeStatusEffect2(this);
        print(statusEffectNames[0]);
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

    public void LootDrop()
    {
        //InventoryItem sc = gameObject.AddComponent<InventoryItem>() as InventoryItem;
        if (dead == true)
        Instantiate(itemEx, transform.position, transform.rotation);
        Debug.Log("Dropped Loot");
    }

    //For testing
    public void Kill()
    {
        if (Input.GetKeyDown("space"))
            health = 0;
    }

}
