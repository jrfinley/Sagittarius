using UnityEngine;
using System.Collections;
using ItemGeneratorHelpers;

public static class ItemGenerator {
    #region Variables
    private static Item item = new Item(false);

    private static ItemLookUp itemLookUp = new ItemLookUp();
    private static IconPathLookUp iconPathLookUp = new IconPathLookUp();
    private static ItemTypeGenerator itemTypeGenerator = new ItemTypeGenerator();
    private static ItemModifyerGenerator itemModifyerGenerator = new ItemModifyerGenerator();
    private static ItemStatsCalculator itemStatsCalculator = new ItemStatsCalculator();
    private static PredefinedItems predefinedItems = new PredefinedItems();

    private static int idVersion = 0;
    private static char seperationChar = '|';
    #endregion

    #region Properties
    public static PredefinedItems PredefinedItems { get { return predefinedItems; } }
    #endregion


    public static Item GeneratePredefinedItem(EPredefinedItem predefinedItem) {
        PredefinedItem pdItem = predefinedItems.PredefinedItem[predefinedItem];
        item = LookUpItem(pdItem.EquipmentType);
        item.Seed = pdItem.Seed;
        item.Types.Rarity = pdItem.Rarity;
        item.Types.PrefixModifyer = pdItem.PrefixModifyer;
        item.Types.SuffixModifyer = pdItem.SuffixModifyer;
        item.PrefixIndex = pdItem.PrefixIndex;
        item.SuffixIndex = pdItem.SuffixIndex;

        if(pdItem.OverrideBaseStats)
            item.Stats = new ItemStats(pdItem.Stats);

        item.Name = itemModifyerGenerator.GetIMName(item.Name, pdItem.PrefixModifyer, pdItem.SuffixModifyer, pdItem.PrefixIndex, pdItem.SuffixIndex);
        item.Stats = GetIMStats(item.Stats, pdItem.PrefixModifyer, pdItem.SuffixModifyer);
        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);

        item.ID = GenerateID(item);
        item.Stats = CalculateItemStats(item);
        return new Item(item, true);
    }
    public static Item GenerateRandomItem() {
        int prefixIndex = 0;
        int suffixIndex = 0;

        item = LookUpItem(GenerateEquipmentType());
        item.Level = GenerateItemLevel();
        item.Types.Rarity = GenerateItemRarity();
        GenerateIM();

        item.Name = GetIMName(item.Name, item.Types.PrefixModifyer, item.Types.SuffixModifyer, out prefixIndex, out suffixIndex);
        item.PrefixIndex = prefixIndex;
        item.SuffixIndex = suffixIndex;

        item.Stats = GetIMStats(item.Stats, item.Types.PrefixModifyer, item.Types.SuffixModifyer);
        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);

        item.Seed = Random.Range(0, 9999);

        //following need to be called last to override base stats in id>item, and save base stats in id
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
        item.Types.Rarity = (EItemRarity)values[2];
        item.Types.PrefixModifyer = (EItemModifyer)values[3];
        item.Types.SuffixModifyer = (EItemModifyer)values[4];
        item.PrefixIndex = values[5];
        item.SuffixIndex = values[6];
        item.Name = itemModifyerGenerator.GetIMName(item.Name, item.Types.PrefixModifyer, item.Types.SuffixModifyer, values[5], values[6]);
        item.Stats = new ItemStats(item.Stats.Weight, values[7], values[8], values[9], values[10], values[11], item.Stats.EquipLoad, values[12], values[13], values[14]);
        item.Seed = values[15];
        item.Stats = CalculateItemStats(item);

        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);
        item.ID = id;
        return new Item(item, true);
    }
    public static Item ReforgeItem(Item item, float successChance)
    {
        item = new Item(item, false);
        item.Types.Rarity = (EItemRarity)(int)(Mathf.Clamp(Mathf.Floor((float)item.Types.Rarity) + (Random.Range(-1.5f + successChance, 2)), 0, 3));
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

        itemModifyerGenerator.GenerateIM(item.Types.Rarity, out prefixIM, out suffixIM);

        item.Types.PrefixModifyer = prefixIM;
        item.Types.SuffixModifyer = suffixIM;
    }
    public static string GetIMName(string inputName, EItemModifyer prefixIM, EItemModifyer suffixIM, out int prefixIndex, out int suffixIndex) {
        return itemModifyerGenerator.GetIMName(inputName, prefixIM, suffixIM, out prefixIndex, out suffixIndex);
    }
    public static ItemStats GetIMStats(ItemStats inputStats, EItemModifyer prefixIM, EItemModifyer suffixIM) {
        return itemModifyerGenerator.GetIMStats(inputStats, prefixIM, suffixIM);
    }
    
    private static ItemStats CalculateItemStats(Item item) {
        return itemStatsCalculator.CalculateItemStats(item.Stats, item.Types.Rarity, item.Level, item.Seed);
    }

    private static string GenerateID(Item item) {
        return (
            idVersion.ToString("D3") + seperationChar +
            ((int)item.Types.EquipmentType).ToString("D3") + seperationChar + //0
            item.Level.ToString("D5") + seperationChar + //1
            ((int)item.Types.Rarity).ToString("D1") + seperationChar + //2
            ((int)item.Types.PrefixModifyer).ToString("D3") + seperationChar + //3
            ((int)item.Types.SuffixModifyer).ToString("D3") + seperationChar + //4
            item.PrefixIndex.ToString("D3") + seperationChar + //5
            item.SuffixIndex.ToString("D3") + seperationChar + //6
            Mathf.FloorToInt(item.Stats.Health).ToString("D4") + seperationChar + //7
            Mathf.FloorToInt(item.Stats.Attack).ToString("D4") + seperationChar + //8
            Mathf.FloorToInt(item.Stats.Strength).ToString("D4") + seperationChar + //9
            Mathf.FloorToInt(item.Stats.Intelect).ToString("D4") + seperationChar + //10
            Mathf.FloorToInt(item.Stats.Dexterity).ToString("D4") + seperationChar + //11
            Mathf.FloorToInt(item.Stats.Durability).ToString("D4") + seperationChar + //12
            Mathf.FloorToInt(item.Stats.GoldValue).ToString("D4") + seperationChar + //13
            Mathf.FloorToInt(item.Stats.ScrapValue).ToString("D4") + seperationChar + //14
            item.Seed.ToString("D4") //15
        );
    }
    
}