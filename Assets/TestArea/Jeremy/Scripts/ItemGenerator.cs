using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoSingleton<ItemGenerator> {
    #region Variables
    private int id = 0;
    private string itemName = string.Empty;
    private EItemType itemType = EItemType.AMULET; //Amulet as a default
    private string icon = string.Empty;
    private float weight = 0;
    private float health = 0; //These will work like stat modifyers
    private float strength = 0;
    private float intelect = 0;
    private float dexterity = 0;
    private float equipLoad = 0;
    #endregion
    
    public Item GenerateItem() {
        GenerateItemID();
        GenerateItemName();
        GenerateItemType();
        GenerateIcon();
        GenerateWeight();
        GenerateHealth();
        GenereateStrength();
        GenereateIntelect();
        GenerateDexterity();
        GenerateEquipLoad();
        return new Item(id, itemName, itemType, icon, weight, health, strength, intelect, dexterity, equipLoad);
    }
    private void GenerateItemID() { //The idea is that we need id to diferentiate items. This will check agaist all current items for id's and assign one that isn't taken
        id = Random.Range(1, int.MaxValue);
    }
    private void GenerateItemName() {
        itemName = "Default Name"; 
    }
    private void GenerateItemType() {
        switch(Random.Range(0, 3)) {
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
        }
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