using UnityEngine;
using System.Collections;

public class ItemStats {
    #region Variables
    private float weight = 0;
    private float health = 0; //These will work like stat modifyers
    private float attack = 0;
    private float strength = 0;
    private float intelect = 0;
    private float dexterity = 0;
    private float equipLoad = 0;
    private float durability = 0;
    private float goldValue = 0;
    private float scrapValue = 0;
    #endregion

    #region Properties
    public float Weight {
        get {
            return weight;
        }
        set {
            weight = value;
        }
    }
    public float Health {
        get {
            return health;
        }
        set {
            health = value;
        }
    }
    public float Attack
    {
        get
        {
            return attack;
        }
        set
        {
            attack = value;
        }
    }
    public float Strength {
        get {
            return strength;
        }
        set {
            strength = value;
        }
    }
    public float Intelect {
        get {
            return intelect;
        }
        set {
            intelect = value;
        }
    }
    public float Dexterity {
        get {
            return dexterity;
        }
        set {
            dexterity = value;
        }
    }
    public float EquipLoad {
        get {
            return equipLoad;
        }
        set {
            equipLoad = value;
        }
    }
    public float Durability {
        get {
            return durability;
        }
        set {
            durability = value;
        }
    }
    public float GoldValue {
        get {
            return goldValue;
        }
        set {
            goldValue = value;
        }
    }
    public float ScrapValue {
        get {
            return scrapValue;
        }
        set {
            scrapValue = value;
        }
    }
    #endregion

    #region Constructors
    public ItemStats(float weight, float health, float attack, float strength, float intelect, float dexterity, float equipLoad, float durability, float goldValue, float scrapValue) {
        this.weight = weight;
        this.health = health;
        this.attack = attack;
        this.strength = strength;
        this.intelect = intelect;
        this.dexterity = dexterity;
        this.equipLoad = equipLoad;
        this.durability = durability;
        this.goldValue = goldValue;
        this.scrapValue = scrapValue;
    }
    public ItemStats() {

    }
    public ItemStats(ItemStats itemStats) {
        weight = itemStats.weight;
        attack = itemStats.attack;
        health = itemStats.health;
        strength = itemStats.strength;
        intelect = itemStats.intelect;
        dexterity = itemStats.dexterity;
        equipLoad = itemStats.equipLoad;
        durability = itemStats.durability;
        goldValue = itemStats.goldValue;
        scrapValue = itemStats.scrapValue;
    }
    #endregion

    #region Methods
    public void AddToAll(float number) {
        weight += number;
        health += number;
        attack += number;
        strength += number;
        intelect += number;
        dexterity += number;
        equipLoad += number;
        durability += number;
        goldValue += number;
        scrapValue += number;
    }
    public void MultiplyByAll(float number) {
        weight *= number;
        health *= number;
        attack *= number;
        strength *= number;
        intelect *= number;
        dexterity *= number;
        equipLoad *= number;
        durability *= number;
        goldValue *= number;
        scrapValue *= number;
    }
    public void AddStats(ItemStats statsToAdd) {
        weight += statsToAdd.weight;
        health += statsToAdd.health;
        attack += statsToAdd.attack;
        strength += statsToAdd.strength;
        intelect += statsToAdd.intelect;
        dexterity += statsToAdd.dexterity;
        equipLoad += statsToAdd.equipLoad;
        durability += statsToAdd.durability;
        goldValue += statsToAdd.goldValue;
        scrapValue += statsToAdd.scrapValue;
    }
    #endregion
}
