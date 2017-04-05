using UnityEngine;
using System.Collections;

public class Item {
    #region Variables
    private int id = 0;
    private string name = string.Empty;
    private string flavorText = string.Empty;
    private string iconName = string.Empty; //Why a string? It is so we can utilize the Resources folder, using refrences could cause crashes while in development (ie refrencing something that doesn't exist).
    private int itemLevel = 0;
    private ItemTypes itemTypes;
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
    public int ItemLevel {
        get {
            return itemLevel;
        }
        set {
            if(!statProtection)
                itemLevel = value;
        }
    }
    public ItemTypes ItemTypes {
        get {
            return itemTypes;
        }
        set {
            if(!statProtection)
                itemTypes = value;
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
    public Item(int id, string name, string flavorText, string iconName, int itemLevel, ItemTypes itemTypes, ItemStats itemStats) {
        this.id = id;
        this.name = name;
        this.flavorText = flavorText;
        this.iconName = iconName;
        this.itemLevel = itemLevel;
        this.itemTypes = new ItemTypes(ItemTypes);
        this.itemStats = new ItemStats(ItemStats);
        this.statProtection = true;
    }
    public Item(Item item) {
        this.id = item.id;
        this.name = item.name;
        this.flavorText = item.flavorText;
        this.iconName = item.iconName;
        this.itemLevel = item.itemLevel;
        this.itemTypes = new ItemTypes(item.ItemTypes);
        this.itemStats = new ItemStats(item.ItemStats);
        this.statProtection = true;
    }
    public Item(Item item, bool statProtection) {
        this.id = item.id;
        this.name = item.name;
        this.flavorText = item.flavorText;
        this.iconName = item.iconName;
        this.itemLevel = item.itemLevel;
        this.itemTypes = new ItemTypes(item.ItemTypes);
        this.itemStats = new ItemStats(item.ItemStats);
        this.statProtection = statProtection;
    }
    public Item(bool statProtection) { //used in generating items
        this.statProtection = statProtection;
        this.itemTypes = new ItemTypes();
        itemStats = new ItemStats();
    }
    #endregion

    #region Methods
    public void DebugLog() {
        string col = ": ";
        string spc = "  ";
        Debug.Log(
            "ID" + col + id + spc +
            "Name" + col + name + spc +
            "Flavor Text" + col + flavorText + spc + 
            "Icon Name" + col + iconName + spc +
            "Item Level" + col + ItemLevel + spc + "\n" +
            "Item Type" + col + itemTypes.ItemType + spc +
            "Equipment Type" + col + itemTypes.EquipmentType + spc + 
            "Equip Slot" + col + itemTypes.EquipSlot + spc +
            "Weight Class" + col + itemTypes.WeightClass + spc +
            "Damage Type" + col + itemTypes.DamageType + spc +
            "Weapon Range" + col + itemTypes.WeaponRange + spc +
            "Rarity" + col + itemTypes.ItemRarity + spc + "\n" +
            "Weight" + col + itemStats.Weight + spc +
            "Health" + col + itemStats.Health + spc +
            "Attack" + col + itemStats.Attack + spc +
            "Intelect" + col + itemStats.Intelect + spc +
            "Dexterity" + col + itemStats.Dexterity + spc +
            "Equip Load" + col + itemStats.EquipLoad + spc +
            "Durability" + col + itemStats.Durability + spc +
            "Gold Value" + col + itemStats.GoldValue + spc +
            "Scrap Value" + col + itemStats.ScrapValue + spc +
            "Stat Protection" + col + statProtection
            );
    }
    public Sprite GetSprite()
    {
        return Resources.Load<Sprite>(iconName);
    }
    #endregion
}
