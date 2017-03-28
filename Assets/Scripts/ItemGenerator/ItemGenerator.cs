using UnityEngine;
using System.Collections;

public static class ItemGenerator {
    #region Variables
    private static Item item = new Item(false);
    private static NameGenerator nameGenerator = new NameGenerator();
    private static FlavorTextGenerator flavorGenerator = new FlavorTextGenerator();
    private static ItemTypesGenerator itemTypesGenerator = new ItemTypesGenerator();
    private static ItemStatsGenerator itemStatsGenerator = new ItemStatsGenerator();
    private static IconGenerator iconGenerator = new IconGenerator();
    #endregion
    
    public static Item GenerateItem() {
        GenerateItemID();
        GenerateItemTypes();
        GenerateItemRarity();
        GenerateItemLevel();
        GenerateItemName();
        GenerateFlavorText();
        GenerateIcon();
        GenerateItemStats();
        return new Item(item);
    }
    private static Item GenerateItemDrop(int monsterLevel, int dungeonLevel) {
        GenerateItemID();
        GenerateItemTypes();
        GenerateItemRarity();
        GenerateItemLevel(monsterLevel, dungeonLevel);
        GenerateItemName();
        GenerateFlavorText();
        GenerateIcon();
        GenerateItemStats();
        return new Item(item);
    }
    public static Item ReforgeItem(Item itemToReforge) {
        item = new Item(itemToReforge, false);
        GenerateItemID();
        item.ItemTypes.ItemRarity = (EItemRarity)(Mathf.Min((int)item.ItemTypes.ItemRarity + 1, 3));
        GenerateItemName();
        GenerateFlavorText();
        GenerateIcon();
        GenerateItemStats();
        return new Item(item);
    }
    public static Item ReforgeItem(Item itemToReforge, float successChance)
    { 
        item = new Item(itemToReforge, false);
        GenerateItemID();
        item.ItemTypes.ItemRarity = (EItemRarity)(int)(Mathf.Clamp(Mathf.Floor((float)item.ItemTypes.ItemRarity) + (Random.Range(-1.5f + successChance, 2)), 0, 3));
        GenerateItemName();
        GenerateFlavorText();
        GenerateIcon();
        GenerateItemStats();
        return new Item(item);
    }

    private static void GenerateItemID() { //The idea is that we need id to diferentiate items. This will check agaist all current items for id's and assign one that isn't taken
        do {
            item.ID = Random.Range(1, int.MaxValue);
        }
        while(ItemIDDatabase.Instance.ContainsID(item.ID)); //Genereate an ID while it is a duplicate
        ItemIDDatabase.Instance.AddID(item.ID);
    }
    private static void GenerateItemRarity() {
        item.ItemTypes.ItemRarity = (EItemRarity)Random.Range(0, 4);
    }
    private static void GenerateItemTypes() {
        item.ItemTypes = new ItemTypes(itemTypesGenerator.GenerateItemTypes());
    }
    private static void GenerateItemLevel() {
        item.ItemLevel = Random.Range((int)1, 100);
    }
    private static void GenerateItemLevel(int monsterLevel, int dungeonLevel) {
        item.ItemLevel = Random.Range((int)dungeonLevel * 5, monsterLevel + dungeonLevel * 5);
    }
    private static void GenerateItemName() {
        item.Name = nameGenerator.GenerateName(item.ItemTypes.EquipmentType, item.ItemTypes.ItemRarity);
    }
    private static void GenerateFlavorText() {
        item.FlavorText = flavorGenerator.GenerateFlavor(item.ItemTypes.EquipmentType);
    }
    private static void GenerateIcon() {
        item.IconName = iconGenerator.GenerateIcon(item.ItemTypes.EquipmentType);
    }
    private static void GenerateItemStats() {
        item.ItemStats = new ItemStats(itemStatsGenerator.GenerateItemStats(item.ItemTypes.EquipmentType, item.ItemTypes.ItemRarity, item.ItemLevel)); //new to avoid refrence
    }
}