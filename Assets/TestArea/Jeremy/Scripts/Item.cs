using UnityEngine;
using System.Collections;

public class Item {
    #region Variables
    private int id = 0;
    private string name = string.Empty;
    private EItemType itemType;
    private EEquipmentType equipmentType;
    private EItemRarity itemRarity;
    private string iconName = string.Empty; //Why a string? It is so we can utilize the Resources folder, using refrences could cause crashes while in development (ie refrencing something that doesn't exist).
    private float weight = 0;
    private float health = 0; //These will work like stat modifyers
    private float strength = 0;
    private float intelect = 0;
    private float dexterity = 0;
    private float equipLoad = 0;
    #endregion

    #region Properties
    public int Id {
        get {
            return id;
        }
    }
    public string Name {
        get {
            return name;
        }
    }
    public EItemType ItemType {
        get {
            return itemType;
        }
    }
    public EEquipmentType EquipmentType {
        get {
            return equipmentType;
        }
    }
    public EItemRarity ItemRarity {
        get {
            return itemRarity;
        }
    }
    public string IconName {
        get {
            return iconName;
        }
    }
    public float Weight {
        get {
            return weight;
        }
    }
    public float Health {
        get {
            return health;
        }
    }
    public float Strength {
        get {
            return strength;
        }
    }
    public float Intelect {
        get {
            return intelect;
        }
    }
    public float Dexterity {
        get {
            return dexterity;
        }
    }
    public float EquipLoad {
        get {
            return equipLoad;
        }
    }    
    #endregion

    public Item(int id, string name, EItemType itemType, EEquipmentType equipmentType, EItemRarity itemRarity, string iconName, float weight, float health, 
            float strength, float intelect, float dexterity, float equipLoad) {
        this.id = id;
        this.name = name;
        this.itemType = itemType;
        this.equipmentType = equipmentType;
        this.itemRarity = itemRarity;
        this.iconName = iconName;
        this.weight = weight;
        this.health = health;
        this.strength = strength;
        this.intelect = intelect;
        this.dexterity = dexterity;
        this.equipLoad = equipLoad;
    }

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
            "Equip Load: " + equipLoad
            );
    }
    #endregion
}
