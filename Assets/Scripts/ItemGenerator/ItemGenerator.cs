using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoSingleton<ItemGenerator> {
    #region Variables
    private Item item = new Item(false);
    private NameGenerator nameGenerator = new NameGenerator();
    private FlavorTextGenerator flavorGenerator = new FlavorTextGenerator();
    private EquipmentTypeGenerator equipmentGenerator = new EquipmentTypeGenerator();
    private ItemStatsGenerator itemStatsGenerator = new ItemStatsGenerator();
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
        GenerateItemStats();
        return new Item(item);
    }
    public Item ReforgeItem(Item itemToReforge) {
        item = new Item(itemToReforge, false);
        GenerateItemID();
        item.ItemRarity = (EItemRarity)(Mathf.Min((int)item.ItemRarity + 1, 3));
        GenerateItemName();
        GenerateFlavorText();
        GenerateIcon();
        GenerateItemStats();
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
        item.EquipmentType = equipmentGenerator.GenereteEquipmentType(item.ItemType);
    }
    private void GenerateItemLevel() {
        item.ItemLevel = Random.Range((int)1, 100);
    }
    private void GenerateItemName() {
        item.Name = nameGenerator.GenerateName(item.EquipmentType, item.ItemRarity);
    }
    private void GenerateFlavorText() {
        item.FlavorText = flavorGenerator.GenerateFlavor(item.EquipmentType);
    }
    private void GenerateIcon() {
        item.IconName = "Default_Icon";
    }
    //Following are all set to 1, for testing purposes
    private void GenerateItemStats() {
        item.ItemStats = new ItemStats(itemStatsGenerator.GenerateItemStats(item.EquipmentType, item.ItemRarity, item.ItemLevel)); //new to avoid refrence
    }
}