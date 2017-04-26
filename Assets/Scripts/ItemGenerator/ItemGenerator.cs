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
    
    //todo: impre and imsuf values in id
    public static Item GenerateRandomItem() {
        item = LookUpItem(GenerateEquipmentType());
        item.Level = GenerateItemLevel();
        item.Types.ItemRarity = GenerateItemRarity();
        GenerateIM();

        item.Name = GetIMName(item.Name, item.Types.PrefixItemModifyer, item.Types.SuffixItemModifyer);
        item.Stats = GetIMStats(item.Stats, item.Types.PrefixItemModifyer, item.Types.SuffixItemModifyer);
        item.IconPath = GetIconPath();

        CalculateItemStats();
        item.ID = GenerateID(item);
        return new Item(item, true);
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
    
    private static int GenerateRandomID() { 
        return Random.Range(1, int.MaxValue);
    }
    private static int GenerateRandomID(int monsterLevel, int dungeonLevel) {
        int id = Random.Range(1, int.MaxValue);
        return (id - id % 100 + Mathf.Clamp(Random.Range((int)dungeonLevel, monsterLevel + dungeonLevel), 0, 99));
    }
    */
    private static EEquipmentType GenerateEquipmentType() {
        return itemTypeGenerator.GenereteRandomEquipmentType(itemTypeGenerator.GenerateRandomItemType());
    }
    private static Item LookUpItem(EEquipmentType itemToLookUp) {
        return new Item(itemLookUp.ItemLookUpTable[itemToLookUp]);
    }
    private static string GetIconPath() {
        return iconPathLookUp.GetPathName(item.Types.ItemType) + item.IconPath;
    }

    private static EItemRarity GenerateItemRarity() {
        return (EItemRarity)(Random.Range((int)0, 4));
    }
    private static int GenerateItemLevel() {
        return Random.Range((int)0, 100);
    }
    public static void GenerateIM() {
        EItemModifyer prefixIM = EItemModifyer.NONE;
        EItemModifyer suffixIM = EItemModifyer.NONE;

        itemModifyerGenerator.GenerateIM(item.Types.ItemRarity, ref prefixIM, ref suffixIM);

        item.Types.PrefixItemModifyer = prefixIM;
        item.Types.SuffixItemModifyer = suffixIM;
    }
    public static string GetIMName(string inputName, EItemModifyer prefixIM, EItemModifyer suffixIM) {
        return itemModifyerGenerator.GetIMName(inputName, prefixIM, suffixIM);
    }
    public static ItemStats GetIMStats(ItemStats inputStats, EItemModifyer prefixIM, EItemModifyer suffixIM) {
        return itemModifyerGenerator.GetIMStats(inputStats, prefixIM, suffixIM);
    }
    
    private static ItemStats CalculateItemStats() {
        return itemStatsCalculator.CalculateItemStats(item.Stats, item.Types.ItemRarity, item.Level);
    }
    private static string GenerateID(Item item) {
        return (
            ((int)item.Types.EquipmentType).ToString("D3") +
            item.Level.ToString("D5") +
            ((int)item.Types.ItemRarity).ToString("D1") +
            ((int)item.Types.PrefixItemModifyer).ToString("D3") +
            ((int)item.Types.SuffixItemModifyer).ToString("D3") + 
            item.Stats.Health.ToString("D4") +
            item.Stats.Attack.ToString("D4") +
            item.Stats.Strength.ToString("D4") +
            item.Stats.Intelect.ToString("D4") +
            item.Stats.Dexterity.ToString("D4") +
            item.Stats.Durability.ToString("D4") +
            item.Stats.GoldValue.ToString("D4") +
            item.Stats.ScrapValue.ToString("D4")
        );
    }
}