using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoSingleton<ItemGenerator> {
    #region Variables
    private Item item = new Item(false);
    private NameGenerator nameGenerator = new NameGenerator();

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
        GenerateItemLevel();
        GenerateItemName();
        GenerateFlavorText();
        GenerateIcon();
        GenerateWeight();
        GenerateHealth();
        GenereateStrength();
        GenereateIntelect();
        GenerateDexterity();
        GenerateEquipLoad();
        GenerateGoldValue();
        GenerateScrapValue();
        return new Item(item);
    }
    private void GenerateItemID() { //The idea is that we need id to diferentiate items. This will check agaist all current items for id's and assign one that isn't taken
        do {
            item.ID = Random.Range(1, int.MaxValue);
        }
        while(ItemIDDatabase.Instance.ContainsID(item.ID)); //Genereate an ID while it is a duplicate
        ItemIDDatabase.Instance.AddID(item.ID);
    }
    private void GenerateItemRarity() {
        item.ItemRarity = (EItemRarity)Random.Range(0, 4);
    }
    private void GenerateItemType() {
        item.ItemType = (EItemType)Random.Range(0, 4);
    }
    private void GenereteEquipmentType() {
        switch(item.ItemType) {
            case EItemType.CONSUMABLE:
                item.EquipmentType = (EEquipmentType)Random.Range(etConsumable, etWeapon);
                break;
            case EItemType.WEAPON:
                item.EquipmentType = (EEquipmentType)Random.Range(etWeapon, etArmor);
                break;
            case EItemType.ARMOR:
                item.EquipmentType = (EEquipmentType)Random.Range(etArmor, etAmulet);
                break;
            case EItemType.AMULET:
                item.EquipmentType = (EEquipmentType)Random.Range(etAmulet, etQuest);
                break;
            case EItemType.QUEST:
                item.EquipmentType = (EEquipmentType)Random.Range(etQuest, etEnd);
                break;
            default:
                Debug.LogError("Invalid case.");
                break;
        }
    }
    private void GenerateItemLevel() {
        item.ItemLevel = 1;
    }
    private void GenerateItemName() {
        item.Name = nameGenerator.GenerateName(item);
    }
    private void GenerateFlavorText() {
        item.FlavorText = "Mild flavor";
    }
    private void GenerateIcon() {
        item.IconName = "Default_Icon";
    }
    //Following are all set to 1, for testing purposes
    private void GenerateWeight() {
        item.Weight = 1;
    }
    private void GenerateHealth() {
        item.Health = 1;
    }
    private void GenereateStrength() {
        item.Strength = 1;
    }
    private void GenereateIntelect() {
        item.Intelect = 1;
    }
    private void GenerateDexterity() {
        item.Dexterity = 1;
    }
    private void GenerateEquipLoad() {
        item.EquipLoad = 1;
    }
    private void GenerateGoldValue() {
        item.GoldValue = 1;
    }
    private void GenerateScrapValue() {
        item.ScrapValue = 1;
    }
}