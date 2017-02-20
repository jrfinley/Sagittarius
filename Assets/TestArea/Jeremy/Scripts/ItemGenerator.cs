using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoSingleton<ItemGenerator> {
    #region Variables
    private int id = 0;
    private EItemRarity itemRarity = EItemRarity.COMMON;
    private string itemName = string.Empty;
    private EItemType itemType = EItemType.AMULET; //Amulet as a default
    private EEquipmentType equipmentType = EEquipmentType.AMOR; //Armor as default
    private string icon = string.Empty;
    private float weight = 0;
    private float health = 0; //These will work like stat modifyers
    private float strength = 0;
    private float intelect = 0;
    private float dexterity = 0;
    private float equipLoad = 0;

    private int etConsumable = 0;
    private int etWeapon = 2;
    private int etArmor = 12;
    private int etAmulet = 13;
    private int etQuest = 14;
    private int etEnd = 15;
    #endregion
    
    public Item GenerateItem() {
        GenerateItemID();
        GenerateItemRarity();
        GenerateItemType();
        GenereteEquipmentType();
        GenerateItemName();
        GenerateIcon();
        GenerateWeight();
        GenerateHealth();
        GenereateStrength();
        GenereateIntelect();
        GenerateDexterity();
        GenerateEquipLoad();
        return new Item(id, itemName, itemType, equipmentType, itemRarity, icon, weight, health, strength, intelect, dexterity, equipLoad);
    }
    private void GenerateItemID() { //The idea is that we need id to diferentiate items. This will check agaist all current items for id's and assign one that isn't taken
        id = Random.Range(1, int.MaxValue);
    }
    private void GenerateItemRarity() {
        itemRarity = (EItemRarity)Random.Range(0, 4);
        /*switch (Random.Range(0, 4)) {
            case 0:
                itemRarity = EItemRarity.COMMON;
                break;
            case 1:
                itemRarity = EItemRarity.RARE;
                break;
            case 2:
                itemRarity = EItemRarity.EPIC;
                break;
            case 3:
                itemRarity = EItemRarity.LEGENDARY;
                break;
            default:
                Debug.LogError("Invalid case. Defaulting itemType to AMULET.");
                break;
        }*/
    }
    private void GenerateItemType() {
        itemType = (EItemType)Random.Range(0, 4);
        /*switch (Random.Range(0, 4)) {
            case 0:
                itemType = EItemType.AMULET;
                break;
            case 1:
                itemType = EItemType.ARMOR;
                break;
            case 2:
                itemType = EItemType.CONSUMABLE;
                break;
            case 3:
                itemType = EItemType.WEAPON;
                break;
            default:
                Debug.LogError("Invalid case. Defaulting itemType to AMULET.");
                break;
        }*/
    }
    private void GenereteEquipmentType() {
        switch(itemType) {
            case EItemType.CONSUMABLE:
                equipmentType = (EEquipmentType)Random.Range(etConsumable, etWeapon);
                break;
            case EItemType.WEAPON:
                equipmentType = (EEquipmentType)Random.Range(etWeapon, etArmor);
                break;
            case EItemType.ARMOR:
                equipmentType = (EEquipmentType)Random.Range(etArmor, etAmulet);
                break;
            case EItemType.AMULET:
                equipmentType = (EEquipmentType)Random.Range(etAmulet, etQuest);
                break;
            case EItemType.QUEST:
                equipmentType = (EEquipmentType)Random.Range(etQuest, etEnd);
                break;
            default:
                Debug.LogError("Invalid case.");
                break;
        }
    }
    private void GenerateItemName() {
        itemName = "Default Name"; 
    }
    private void GenerateIcon() {
        icon = "Default_Icon";
    }
    //Following are all set to 1, for testing purposes
    private void GenerateWeight() {
        weight = 1;
    }
    private void GenerateHealth() {
        health = 1;
    }
    private void GenereateStrength() {
        strength = 1;
    }
    private void GenereateIntelect() {
        intelect = 1;
    }
    private void GenerateDexterity() {
        dexterity = 1;
    }
    private void GenerateEquipLoad() {
        equipLoad = 1;
    }
}