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

    public GameObject loot;

    [SerializeField]
    private Sprite icon;

    void Start()
    {
        InitializeMonster();
        
    }

    void InitializeMonster()
    {       
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

            case 3:
                maxHealth = level * 12;
                attack = level * 12;
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

            if (health <= 0)
                dead = true;

            else
                dead = false;         
        }
    }

    //For testing
    public void Kill()
    {
        if (Input.GetKeyDown("k"))
        {
            health = 0;
            dead = true;
            Destroy(gameObject);
        }
           
    }

    public void Update()
    {
        Kill();
        LootDrop();
        ApplyRotation();

    }

    public void LootDrop()
    {
        if (dead == true)
        {
            Instantiate(loot, new Vector3(transform.position.x,0.10f,transform.position.z), Quaternion.Euler(90, 0, 0));          
        }
    }

    public void ApplyRotation()
    {
         transform.Rotate(Vector3.right * Time.deltaTime);
    }


}
