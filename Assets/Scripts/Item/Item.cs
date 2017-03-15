using UnityEngine;
using System.Collections;

public class Item {
    #region Variables
    private int id = 0;
    private string name = string.Empty;
    private string flavorText = string.Empty;
    private string iconName = string.Empty; //Why a string? It is so we can utilize the Resources folder, using refrences could cause crashes while in development (ie refrencing something that doesn't exist).
    private EItemType itemType = EItemType.AMULET;
    private EEquipmentType equipmentType = EEquipmentType.AMULET;
    private EItemEquipSlot equipSlot = EItemEquipSlot.NONE;
    private EItemWeightClass weightClass = EItemWeightClass.NONE;
    private EWeaponDamageType damageType = EWeaponDamageType.NONE;
    private EWeaponRange weaponRange = EWeaponRange.NONE;
    private EItemRarity itemRarity = EItemRarity.COMMON;
    private int itemLevel = 0;
    private ItemStats itemStats;

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
    public string FlavorText {
        get {
            return flavorText;
        }
        set {
            if(!statProtection)
                flavorText = value;
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
    public ItemStats ItemStats {
        get {
            return itemStats;
        }
        set {
            if(!statProtection)
                itemStats = value;
        }
    }
    public bool StatProtection {
        get {
            return statProtection;
        }
    }
    #endregion
    
    #region Constructors
    public Item(int id, string name, string flavorText, string iconName, EItemType itemType, EEquipmentType equipmentType, EItemRarity itemRarity, int itemLevel,  
            float weight, float health, float strength, float intelect, float dexterity, float equipLoad, float durability, float goldValue, float scrapValue) {
        this.id = id;
        this.name = name;
        this.flavorText = flavorText;
        this.iconName = iconName;
        this.itemType = itemType;
        this.equipmentType = equipmentType;
        this.itemRarity = itemRarity;
        this.itemLevel = itemLevel;
        this.itemStats = new ItemStats(weight, health, strength, intelect, dexterity, equipLoad, durability, goldValue, scrapValue);
        this.statProtection = true;
    }
    public Item(Item item) {
        this.id = item.id;
        this.name = item.name;
        this.flavorText = item.flavorText;
        this.iconName = item.iconName;
        this.itemType = item.itemType;
        this.equipmentType = item.equipmentType;
        this.itemRarity = item.itemRarity;
        this.itemLevel = item.itemLevel;
        this.itemStats = new ItemStats(item.ItemStats);
        this.statProtection = true;
    }
    public Item(Item item, bool statProtection) {
        this.id = item.id;
        this.name = item.name;
        this.flavorText = item.flavorText;
        this.iconName = item.iconName;
        this.itemType = item.itemType;
        this.equipmentType = item.equipmentType;
        this.itemRarity = item.itemRarity;
        this.itemLevel = item.itemLevel;
        this.itemStats = new ItemStats(item.ItemStats);
        this.statProtection = statProtection;
    }
    public Item(bool statProtection) { //used in generating items
        this.statProtection = statProtection;
        itemStats = new ItemStats();
    }
    #endregion

    #region Methods
    public void RemoveFromIDDatabase() {
        ItemIDDatabase.Instance.RemoveID(id);
    }
    public void DebugLog() {
        string spc = "  ";
        Debug.Log(
            "ID: " + id + spc +
            "Name: " + name + spc +
            "Flavor Text: " + flavorText + spc + 
            "Icon Name: " + iconName + spc +
            "Item Type: " + itemType + spc +
            "Equipment Type: " + equipmentType + spc + 
            "Rarity: " + itemRarity + spc + "\n" +
            "Item Level: " + ItemLevel + spc +
            "Weight: " + itemStats.Weight + spc + 
            "Equip Load: " + itemStats.EquipLoad + spc +
            "Gold Value: " + itemStats.GoldValue + spc +
            "Scrap Value: " + itemStats.ScrapValue + spc +
            "Health: " + itemStats.Health + spc +
            "Intelect: " + itemStats.Intelect + spc +
            "Dexterity: " + itemStats.Dexterity + spc +
            "Stat Protection: " + statProtection
            );
    }
    #endregion
}
