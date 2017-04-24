using UnityEngine;
using System.Collections;

public static class ItemGenerator {
    #region Variables
    private static Item item = new Item(false);

    private static ItemLookUp itemLookUp = new ItemLookUp();
    private static IconPathLookUp iconPathLookUp = new IconPathLookUp();

    private static ItemTypeGenerator itemTypeGenerator = new ItemTypeGenerator();
    private static ItemModifyerGenerator itemModifyerGenerator = new ItemModifyerGenerator();

    private static ItemStatsCalculator itemStatsCalculator = new ItemStatsCalculator();

    private static string id = string.Empty; 
    #endregion
    
    public static Item CreateItem(int id, EEquipmentType equipmentType) {
        LookUpItem(equipmentType);
        item.ID = id;
        GetIconPath();

        GenerateItemRarity(id);
        GenerateItemLevel(id);
        GenerateItemModifyers(id);

        CalculateItemStats();
        return new Item(item, true);
    }
    public static Item GenerateRandomItem() {
        return CreateItem(GenerateRandomID(), GenerateEquipmentType());
    }
    /*
    public static Item ReforgeItem(Item itemToReforge, float successChance)
    { 
        item = new Item(itemToReforge, false);
        GenerateRandomID();
        item.Types.ItemRarity = (EItemRarity)(int)(Mathf.Clamp(Mathf.Floor((float)item.Types.ItemRarity) + (Random.Range(-1.5f + successChance, 2)), 0, 3));
        CalculateItemStats();
        Debug.LogWarning("Reforging creates a non reproducable item.");
        return new Item(item);
    }
    */
    private static int GenerateRandomID() { 
        return Random.Range(1, int.MaxValue);
    }
    private static int GenerateRandomID(int monsterLevel, int dungeonLevel) {
        int id = Random.Range(1, int.MaxValue);
        return (id - id % 100 + Mathf.Clamp(Random.Range((int)dungeonLevel, monsterLevel + dungeonLevel), 0, 99));
    }
    private static EEquipmentType GenerateEquipmentType() {
        return itemTypeGenerator.GenereteRandomEquipmentType(itemTypeGenerator.GenerateRandomItemType());
    }
    private static void LookUpItem(EEquipmentType itemToLookUp) {
        item = new Item(itemLookUp.ItemLookUpTable[itemToLookUp]);
    }
    private static void GetIconPath() {
        item.IconPath = iconPathLookUp.GetPathName(item.Types.ItemType) + item.IconPath;
    }

    private static void GenerateItemRarity(int id) {
        item.Types.ItemRarity = (EItemRarity)(id % 4);
    }
    private static void GenerateItemLevel(int id) {
        item.Level = id % 100 + 1;
    }

    public static void GenerateItemModifyers(int id) {
        string outputName = string.Empty;
        ItemStats outputStats = new ItemStats();
        itemModifyerGenerator.GenerateIM(id, item.Types.ItemRarity, item.Name, ref outputName, ref outputStats);
        item.Name = outputName;
        item.Stats.AddStats(outputStats);
    }   
    
    private static void CalculateItemStats() {
        item.Stats = itemStatsCalculator.CalculateItemStats(item.Stats, item.Types.ItemRarity, item.Level);
    }
    
}