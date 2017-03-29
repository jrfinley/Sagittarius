using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    public EMonsterType monsterType;

    public int level;

    private bool dead;

    private int maxHealth,
                health,
                attack,
                defense;

    void Start()
    {
        InitializeMonster();
    }

    void InitializeMonster()
    {
        //Put Functionality to add a script coresponding with the 
        //selected monsters type.

        SetStats();
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
    public EMonsterType GetMonsterType()
    {
        return monsterType;
    }

    //Setters
    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }
    public void SetType(EMonsterType type)
    {
        monsterType = type;
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
}
