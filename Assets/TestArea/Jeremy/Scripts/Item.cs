using UnityEngine;
using System.Collections;

public class Item {
    #region Variables
    private int id = 0;
    private string name = string.Empty;
    private EItemType itemType = EItemType.AMULET;
    private EEquipmentType equipmentType = EEquipmentType.AMULET;
    private EItemRarity itemRarity = EItemRarity.COMMON;
    private int itemLevel = 0;
    private string iconName = string.Empty; //Why a string? It is so we can utilize the Resources folder, using refrences could cause crashes while in development (ie refrencing something that doesn't exist).
    private float weight = 0;
    private float health = 0; //These will work like stat modifyers
    private float strength = 0;
    private float intelect = 0;
    private float dexterity = 0;
    private float equipLoad = 0;

    private bool statProtection = true;
    #endregion

    #region Properties
    public int ID {
        get {
            return id;
        }
        set {
            if(!statProtection)
                id = value;
        }
    }
    public string Name {
        get {
            return name;
        }
        set {
            if(!statProtection)
                name = value;
        }
    }
    public EItemType ItemType {
        get {
            return itemType;
        }
        set {
            if(!statProtection)
                itemType = value;
        }
    }
    public EEquipmentType EquipmentType {
        get {
            return equipmentType;
        }
        set {
            if(!statProtection)
                equipmentType = value;
        }
    }
    public EItemRarity ItemRarity {
        get {
            return itemRarity;
        }
        set {
            if(!statProtection)
                itemRarity = value;
        }
    }
    public int ItemLevel {
        get {
            return itemLevel;
        }
        set {
            if(!statProtection)
                itemLevel = value;
        }
    }
    public string IconName {
        get {
            return iconName;
        }
        set {
            if(!statProtection)
                iconName = value;
        }
    }
    public float Weight {
        get {
            return weight;
        }
        set {
            if(!statProtection)
                weight = value;
        }
    }
    public float Health {
        get {
            return health;
        }
        set {
            if(!statProtection)
                health = value;
        }
    }
    public float Strength {
        get {
            return strength;
        }
        set {
            if(!statProtection)
                strength = value;
        }
    }
    public float Intelect {
        get {
            return intelect;
        }
        set {
            if(!statProtection)
                intelect = value;
        }
    }
    public float Dexterity {
        get {
            return dexterity;
        }
        set {
            if(!statProtection)
                dexterity = value;
        }
    }
    public float EquipLoad {
        get {
            return equipLoad;
        }
        set {
            if(!statProtection)
                equipLoad = value;
        }
    }
    public bool StatProtection {
        get {
            return statProtection;
        }
    }
    #endregion

    #region Constructors
    public Item(int id, string name, EItemType itemType, EEquipmentType equipmentType, EItemRarity itemRarity, int itemLevel, string iconName, 
            float weight, float health, float strength, float intelect, float dexterity, float equipLoad) {
        this.id = id;
        this.name = name;
        this.itemType = itemType;
        this.equipmentType = equipmentType;
        this.itemRarity = itemRarity;
        this.itemLevel = itemLevel;
        this.iconName = iconName;
        this.weight = weight;
        this.health = health;
        this.strength = strength;
        this.intelect = intelect;
        this.dexterity = dexterity;
        this.equipLoad = equipLoad;
        this.statProtection = true;
    }
    public Item(Item item) {
        this.id = item.id;
        this.name = item.name;
        this.itemType = item.itemType;
        this.equipmentType = item.equipmentType;
        this.itemRarity = item.itemRarity;
        this.itemLevel = item.itemLevel;
        this.iconName = item.iconName;
        this.weight = item.weight;
        this.health = item.health;
        this.strength = item.strength;
        this.intelect = item.intelect;
        this.dexterity = item.dexterity;
        this.equipLoad = item.equipLoad;
        this.statProtection = true;
    }
    public Item(bool statProtection) { //used in generating items
        this.statProtection = statProtection;
    }
    #endregion

    #region Methods
    public void DebugLog() {
        string spacing = "   ";
        Debug.Log(
            "ID: " + id + spacing +
            "Name: " + name + spacing +
            "Item Type: " + itemType + spacing +
            "Equipment Type: " + equipmentType + spacing +
            "Rarity: " + itemRarity + spacing +
            "Icon Name: " + iconName + spacing +
            "Weight: " + weight + spacing +
            "Health: " + health + spacing +
            "Intelect: " + Intelect + spacing +
            "Dexterity: " + dexterity + spacing +
            "Equip Load: " + equipLoad + spacing +
            "Stat Protection: " + statProtection
            );
    }
    #endregion
}
