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

    private static int idVersion = 0;
    private static char seperationChar = '|';
    #endregion

    public static Item GenerateRandomItem() {
        int prefixIndex = 0;
        int suffixIndex = 0;

        item = LookUpItem(GenerateEquipmentType());
        item.Level = GenerateItemLevel();
        item.Types.ItemRarity = GenerateItemRarity();
        GenerateIM();

        item.Name = GetIMName(item.Name, item.Types.PrefixItemModifyer, item.Types.SuffixItemModifyer, out prefixIndex, out suffixIndex);

        item.Stats = GetIMStats(item.Stats, item.Types.PrefixItemModifyer, item.Types.SuffixItemModifyer);
        item.IconPath = GetIconPath();

        CalculateItemStats();
        item.ID = GenerateID(item, prefixIndex, suffixIndex);
        return new Item(item, true);
    }
    public static Item IDToItem(string id) {
        string[] splits = id.Split(seperationChar);
        int[] values = new int[15];
        if(splits.Length != 16)
            Debug.LogError("Split failed!");
        //hard coded length because it needs to be that value

        for(int i = 1; i < 16; i++) {
            try {
                values[i - 1] = int.Parse(splits[i]);
            }
            catch(System.FormatException e) {
                Debug.LogException(e);
            }
        }

        item = LookUpItem((EEquipmentType)values[0]);
        item.Level = values[1];
        item.Types.ItemRarity = (EItemRarity)values[2];
        item.Types.PrefixItemModifyer = (EItemModifyer)values[3];
        item.Types.SuffixItemModifyer = (EItemModifyer)values[4];
        item.Name = itemModifyerGenerator.GetIMName(item.Name, item.Types.PrefixItemModifyer, item.Types.SuffixItemModifyer, values[5], values[6]);
        item.Stats = new ItemStats(item.Stats.Weight, values[7], values[8], values[9], values[10], values[11], item.Stats.EquipLoad, values[12], values[13], values[14]);
        return new Item(item);
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
    public static string GetIMName(string inputName, EItemModifyer prefixIM, EItemModifyer suffixIM, out int prefixIndex, out int suffixIndex) {
        return itemModifyerGenerator.GetIMName(inputName, prefixIM, suffixIM, out prefixIndex, out suffixIndex);
    }
    public static ItemStats GetIMStats(ItemStats inputStats, EItemModifyer prefixIM, EItemModifyer suffixIM) {
        return itemModifyerGenerator.GetIMStats(inputStats, prefixIM, suffixIM);
    }
    
    private static ItemStats CalculateItemStats() {
        return itemStatsCalculator.CalculateItemStats(item.Stats, item.Types.ItemRarity, item.Level);
    }

    private static string GenerateID(Item item, int prefixIndex, int suffixIndex) {
        return (
            idVersion.ToString("D3") + seperationChar +
            ((int)item.Types.EquipmentType).ToString("D3") + seperationChar + //0
            item.Level.ToString("D5") + seperationChar + //1
            ((int)item.Types.ItemRarity).ToString("D1") + seperationChar + //2
            ((int)item.Types.PrefixItemModifyer).ToString("D3") + seperationChar + //3
            ((int)item.Types.SuffixItemModifyer).ToString("D3") + seperationChar + //4
            prefixIndex.ToString("D3") + seperationChar + //5
            suffixIndex.ToString("D3") + seperationChar + //6
            Mathf.FloorToInt(item.Stats.Health).ToString("D4") + seperationChar + //7
            Mathf.FloorToInt(item.Stats.Attack).ToString("D4") + seperationChar + //8
            Mathf.FloorToInt(item.Stats.Strength).ToString("D4") + seperationChar + //9
            Mathf.FloorToInt(item.Stats.Intelect).ToString("D4") + seperationChar + //10
            Mathf.FloorToInt(item.Stats.Dexterity).ToString("D4") + seperationChar + //11
            Mathf.FloorToInt(item.Stats.Durability).ToString("D4") + seperationChar + //12
            Mathf.FloorToInt(item.Stats.GoldValue).ToString("D4") + seperationChar + //13
            Mathf.FloorToInt(item.Stats.ScrapValue).ToString("D4") //14
        );
    }
    
}