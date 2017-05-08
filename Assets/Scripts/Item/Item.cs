using UnityEngine;
using System.Collections;

public class Item {
    #region Variables
    private string id = string.Empty;
    private string name = string.Empty;
    private string flavorText = string.Empty;
    private string iconName = string.Empty; //Why a string? It is so we can utilize the Resources folder, using refrences could cause crashes while in development (ie refrencing something that doesn't exist).
    private int level = 0;
    private int prefixIndex = 0;
    private int suffixIndex = 0;
    private int seed = 0;
    private ItemTypes itemTypes;
    private ItemStats itemStats;
    private bool statProtection = true;
    #endregion

    #region Properties
    public string ID {
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
    public string IconPath {
        get {
            return iconName;
        }
        set {
            if(!statProtection)
                iconName = value;
        }
    }
    public int Level {
        get {
            return level;
        }
        set {
            if(!statProtection)
                level = value;
        }
    }
    public int PrefixIndex {
        get {
            return prefixIndex;
        }
        set {
            if(!statProtection)
                prefixIndex = value;
        }
    }
    public int SuffixIndex {
        get {
            return suffixIndex;
        }
        set {
            if(!statProtection)
                suffixIndex = value;
        }
    }
    public int Seed {
        get { return seed; }
        set { if(!statProtection) { seed = value; } }
    }
    public ItemTypes Types {
        get {
            return itemTypes;
        }
        set {
            if(!statProtection)
                itemTypes = value;
        }
    }
    public ItemStats Stats {
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
    public Item(bool statProtection = false)
    {
        this.statProtection = statProtection;
        this.itemTypes = new ItemTypes();
        this.itemStats = new ItemStats();
    }
    public Item(string name, string flavorText, string iconName, ItemStats itemStats, ItemTypes itemTypes, bool statProtection = false) {
        this.name = name;
        this.flavorText = flavorText;
        this.iconName = iconName;
        this.itemTypes = new ItemTypes(itemTypes);
        this.itemStats = new ItemStats(itemStats);
        this.statProtection = statProtection;
    }
    public Item(Item item, bool statProtection = false) {
        id = item.id;
        name = item.name;
        flavorText = item.flavorText;
        iconName = item.iconName;
        level = item.level;
        prefixIndex = item.PrefixIndex;
        suffixIndex = item.SuffixIndex;
        seed = item.Seed;

        itemTypes = new ItemTypes(item.Types);
        itemStats = new ItemStats(item.Stats);
        this.statProtection = statProtection;
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
            "Item Level" + col + Level + spc + "\n" +
            "Item Type" + col + itemTypes.ItemType + spc +
            "Equipment Type" + col + itemTypes.EquipmentType + spc + 
            "Equip Slot" + col + itemTypes.EquipSlot + spc +
            "Weight Class" + col + itemTypes.WeightClass + spc +
            "Damage Type" + col + itemTypes.DamageType + spc +
            "Weapon Range" + col + itemTypes.WeaponRange + spc +
            "Rarity" + col + itemTypes.Rarity + spc + "\n" +
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
