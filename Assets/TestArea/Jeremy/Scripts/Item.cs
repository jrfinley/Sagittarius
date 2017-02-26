using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    #region Variables
    private int id = 0;
    private string name = string.Empty;
    private string flavorText = string.Empty;
    private string iconName = string.Empty; //Why a string? It is so we can utilize the Resources folder, using refrences could cause crashes while in development (ie refrencing something that doesn't exist).
    private EItemType itemType = EItemType.AMULET;
    private EEquipmentType equipmentType = EEquipmentType.AMULET;
    private EItemRarity itemRarity = EItemRarity.COMMON;
    private int itemLevel = 0;
    private float weight = 0;
    private float health = 0; //These will work like stat modifyers
    private float strength = 0;
    private float intelect = 0;
    private float dexterity = 0;
    private float equipLoad = 0;
    private float durability = 0;
    private float goldValue = 0;
    private float scrapValue = 0;

    private bool statProtection = true;

    //pg added
    public Sprite spriteNeutral;
    public Sprite spriteHighLighted;

    public int maxSize;

    public string nameTester;
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
    public bool StatProtection {
        get {
            return statProtection;
        }
    }
    public float GoldValue {
        get {
            return goldValue;
        }
        set {
            if(!statProtection)
                goldValue = value;
        }
    }
    public float ScrapValue {
        get {
            return scrapValue;
        }
        set {
            if(!statProtection)
                scrapValue = value;
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
    #endregion
    
    #region Constructors
    public Item(int id, string name, string flavorText, string iconName, EItemType itemType, EEquipmentType equipmentType, EItemRarity itemRarity, int itemLevel,  
            float weight, float health, float strength, float intelect, float dexterity, float equipLoad, float goldValue, float scrapValue) {
        this.id = id;
        this.name = name;
        this.flavorText = flavorText;
        this.iconName = iconName;
        this.itemType = itemType;
        this.equipmentType = equipmentType;
        this.itemRarity = itemRarity;
        this.itemLevel = itemLevel;
        this.weight = weight;
        this.health = health;
        this.strength = strength;
        this.intelect = intelect;
        this.dexterity = dexterity;
        this.equipLoad = equipLoad;
        this.goldValue = goldValue;
        this.scrapValue = scrapValue;
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
        this.weight = item.weight;
        this.health = item.health;
        this.strength = item.strength;
        this.intelect = item.intelect;
        this.dexterity = item.dexterity;
        this.equipLoad = item.equipLoad;
        this.goldValue = item.goldValue;
        this.scrapValue = item.scrapValue;
        this.statProtection = true;
    }
    public Item(bool statProtection) { //used in generating items
        this.statProtection = statProtection;
    }
    #endregion

    #region Methods
    public void DebugLog() {
        string spc = "   ";
        Debug.Log(
            "ID: " + id + spc +
            "Name: " + name + spc +
            "Flavor Text: " + flavorText + spc + "\n" +
            "Icon Name: " + iconName + spc +
            "Item Type: " + itemType + spc +
            "Equipment Type: " + equipmentType + spc + 
            "Rarity: " + itemRarity + spc + "\n" +
            "Weight: " + weight + spc + 
            "Equip Load: " + equipLoad + spc +
            "Gold Value: " + goldValue + spc +
            "Scrap Value: " + scrapValue + spc + "\n" +
            "Health: " + health + spc +
            "Intelect: " + Intelect + spc +
            "Dexterity: " + dexterity + spc +
            "Stat Protection: " + statProtection
            );
    }
    #endregion

    //Phil added
    /*
    Note for Jeremy: the reason this function isn't currently 
    working is due to this item class not actually giving items their names yet, so once they 
    actually have names generated then just change these case strings into 
    the items names and then give them appropriate functionality i.e. equip/ consume 
    */

    #region UseItem method
        //function that will either consume or equip items, will need connection to player for health and mana recovery, and the equipment menu for item equipping
    public void UseItem()
    {
        switch (name)//checks items name
        {
            case "HealthPotion":
                Debug.Log("Health Potion Consumed");
                Debug.Log(name);
                break;
            case "ManaPotion":
                Debug.Log("Mana Potion Consumed");
                break;
            case "Food":
                Debug.Log("Food Consumed");
                break;
            case "Water":
                Debug.Log("Water Consumed");
                break;
            case "shuriken":
                Debug.Log("shuriken Thrown");
                break;            
            case "ThrowingStar":
                Debug.Log("Throwing Star Used");
                break;
            case "Ore":
                Debug.Log("Ore");
                break;
            case "Dagger":
                Debug.Log("Dagger Equipped");
                break;
            case "BroadSword":
                Debug.Log("BroadSword Equipped");
                break;
            case "Spear":
                Debug.Log("Spear Equipped");
                break;
            case "Helm":
                Debug.Log("Helm Equipped");
                break;
            case "ChestArmor":
                Debug.Log("ChestArmor Equipped");
                break;
            case "Amulet":
                Debug.Log("Amulet Equipped");
                break;
        }
    }

    //creates the text for the tooltip that allows player to see item name, quality, stats, etc
    public string GetToolTip()
    {
        string stats = string.Empty;
        string color = string.Empty;
        string newLine = string.Empty;

        if (flavorText != string.Empty)
        {
            newLine = "\n";
        }
        switch (itemRarity)
        {
            case EItemRarity.COMMON:
                color = "white";
                break;
            case EItemRarity.RARE:
                color = "navy";
                break;
            case EItemRarity.EPIC:
                color = "magenta";
                break;
            case EItemRarity.LEGENDARY:
                color = "orange";
                break;
        }
        if (health > 0)
        {
            stats += "\n+" + health.ToString() + " Health";
        }
        if (strength > 0)
        {
            stats += "\n+" + strength.ToString() + " Strength";
        }
        if (intelect > 0)
        {
            stats += "\n+" + intelect.ToString() + " Intellect";
        }
        if (dexterity > 0)
        {
            stats += "\n+" + dexterity.ToString() + " Dexterity";
        }
        if (weight > 0)
        {
            stats += "\n+" + weight.ToString() + " Weight";
        }
        if (durability > 0)
        {
            stats += "\n+" + durability.ToString() + " Durability";
        }
        if (goldValue > 0)
        {
            stats += "\n+" + goldValue.ToString() + " GoldValue";
        }
        if (scrapValue > 0)
        {
            stats += "\n+" + scrapValue.ToString() + " ScrapValue";
        }

        //returns the formateed string
        return string.Format("<color=" + color + "><size=24>{0}</size></color><size=20><i><color=lime>" + newLine + "{1}</color></i>{2}</size>", nameTester, flavorText, stats);
    }
    #endregion
}
