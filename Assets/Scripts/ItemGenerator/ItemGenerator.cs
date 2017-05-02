using UnityEngine;
using System.Collections;
using ItemGeneratorHelpers;

public static class ItemGenerator {
    //Todo: add 4 char seed for rand

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
        item.PrefixIndex = prefixIndex;
        item.SuffixIndex = suffixIndex;

        item.Stats = GetIMStats(item.Stats, item.Types.PrefixItemModifyer, item.Types.SuffixItemModifyer);
        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);

        item.ID = GenerateID(item);

        item.Stats = CalculateItemStats(item);
        
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
        item.PrefixIndex = values[5];
        item.SuffixIndex = values[6];
        item.Name = itemModifyerGenerator.GetIMName(item.Name, item.Types.PrefixItemModifyer, item.Types.SuffixItemModifyer, values[5], values[6]);
        item.Stats = new ItemStats(item.Stats.Weight, values[7], values[8], values[9], values[10], values[11], item.Stats.EquipLoad, values[12], values[13], values[14]);
        item.Stats = CalculateItemStats(item);

        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);
        item.ID = id;
        return new Item(item, true);
    }
    public static Item ReforgeItem(string id, float successChance)
    {
        item = IDToItem(id);
        item.DebugLog();
        item.Types.ItemRarity = (EItemRarity)(int)(Mathf.Clamp(Mathf.Floor((float)item.Types.ItemRarity) + (Random.Range(-1.5f + successChance, 2)), 0, 3));
        item.DebugLog();
        item.ID = GenerateID(item);
        item.Stats = CalculateItemStats(item);

        return new Item(item, true);
    }
    private static EEquipmentType GenerateEquipmentType() {
        return itemTypeGenerator.GenereteRandomEquipmentType(itemTypeGenerator.GenerateRandomItemType());
    }
    private static Item LookUpItem(EEquipmentType itemToLookUp) {
        return new Item(itemLookUp.ItemLookUpTable[itemToLookUp]);
    }
    private static string GetIconPath(EItemType itemType, string baseIconPath) {
        return iconPathLookUp.GetPathName(itemType) + baseIconPath;
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

        itemModifyerGenerator.GenerateIM(item.Types.ItemRarity, out prefixIM, out suffixIM);

        item.Types.PrefixItemModifyer = prefixIM;
        item.Types.SuffixItemModifyer = suffixIM;
    }
    public static string GetIMName(string inputName, EItemModifyer prefixIM, EItemModifyer suffixIM, out int prefixIndex, out int suffixIndex) {
        return itemModifyerGenerator.GetIMName(inputName, prefixIM, suffixIM, out prefixIndex, out suffixIndex);
    }
    public static ItemStats GetIMStats(ItemStats inputStats, EItemModifyer prefixIM, EItemModifyer suffixIM) {
        return itemModifyerGenerator.GetIMStats(inputStats, prefixIM, suffixIM);
    }
    
    private static ItemStats CalculateItemStats(Item item) {
        return itemStatsCalculator.CalculateItemStats(item.Stats, item.Types.ItemRarity, item.Level);
    }

    private static string GenerateID(Item item) {
        return (
            idVersion.ToString("D3") + seperationChar +
            ((int)item.Types.EquipmentType).ToString("D3") + seperationChar + //0
            item.Level.ToString("D5") + seperationChar + //1
            ((int)item.Types.ItemRarity).ToString("D1") + seperationChar + //2
            ((int)item.Types.PrefixItemModifyer).ToString("D3") + seperationChar + //3
            ((int)item.Types.SuffixItemModifyer).ToString("D3") + seperationChar + //4
            item.PrefixIndex.ToString("D3") + seperationChar + //5
            item.SuffixIndex.ToString("D3") + seperationChar + //6
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