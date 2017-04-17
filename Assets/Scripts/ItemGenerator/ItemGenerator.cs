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
    #endregion

    public static Item CreateItem(int id, EEquipmentType equipmentType) {
        string outputName;
        ItemStats outputStats;

        item = LookUpItem(equipmentType);
        item.ID = id;
        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);

        item.Types.ItemRarity = GenerateItemRarity(id);
        item.Level = GenerateItemLevel(id);
        
        GenerateItemModifyers(id, item.Types.ItemRarity, item.Name, item.Stats, out outputName, out outputStats);
        item.Name = outputName;
        item.Stats = outputStats;

        item.Stats = CalculateItemStats();
        return new Item(item, true);
    }
    public static Item GenerateRandomItem() {
        return CreateItem(GenerateRandomID(), GenerateEquipmentType());
    }
    private static Item GenerateItemDrop(int monsterLevel, int dungeonLevel) {
        return CreateItem(GenerateRandomID(monsterLevel, dungeonLevel), GenerateEquipmentType());
    }
    public static Item ReforgeItem(Item itemToReforge, float successChance)
    { 
        item = new Item(itemToReforge, false);
        GenerateRandomID();
        item.Types.ItemRarity = (EItemRarity)(int)(Mathf.Clamp(Mathf.Floor((float)item.Types.ItemRarity) + (Random.Range(-1.5f + successChance, 2)), 0, 3));
        CalculateItemStats();
        Debug.LogWarning("Reforging creates a non reproducable item.");
        return new Item(item);
    }

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
    private static Item LookUpItem(EEquipmentType itemToLookUp) {
        return new Item(itemLookUp.ItemLookUpTable[itemToLookUp]);
    }
    private static string GetIconPath(EItemType itemType, string itemPathBaseName) {
        return iconPathLookUp.GetPathName(itemType) + itemPathBaseName;
    }

    private static EItemRarity GenerateItemRarity(int id) {
        return (EItemRarity)(id % 4);
    }
    private static int GenerateItemLevel(int id) {
        return id % 100 + 1;
    }

    public static void GenerateItemModifyers(int id, EItemRarity itemRarirty, string itemName, ItemStats itemStats, out string outputName, out ItemStats outputStats) {
        outputName = string.Empty;
        outputStats = new ItemStats();
        itemModifyerGenerator.GenerateIM(id, itemRarirty, itemName, ref outputName, ref outputStats);

        outputStats.AddStats(itemStats);
    }   
    
    private static ItemStats CalculateItemStats() {
        return itemStatsCalculator.CalculateItemStats(item.Stats, item.Types.ItemRarity, item.Level);
    }
    
}