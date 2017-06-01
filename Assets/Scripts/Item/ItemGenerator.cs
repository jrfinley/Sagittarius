using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ItemGeneratorHelpers;
using JsonJunk;

public static class ItemGenerator {
    //todo: remove stats from ids because base stats

    #region Variables
    private static Item item = new Item(false);

    private static ItemStatsCalculator itemStatsCalculator = new ItemStatsCalculator();

    private static int idVersion = 0;
    private static char seperationChar = '|';

    private static char itemModifyerNameSplitChar = '%';

    #region EquipmentTypeIndexes
    private static int etConsumable = 0;
    private static int etHeld = 2;
    private static int etArmor = 13;
    private static int etAmulet = 15;
    private static int etQuest = 16;
    private static int etEnd = 17;
    #endregion

    #region Dictionaries
    private static Dictionary<EEquipmentType, Item> baseItems = null;
    private static Dictionary<EItemModifyer, ItemModifyer> itemModifyers = null;
    private static Dictionary<EPredefinedItem, PredefinedItem> predefinedItems = null;
    #endregion

    #region ResourcePaths
    private static string baseItemsJsonPath = "JsonFiles/Items/BaseItems";
    private static string itemModifyersJsonPath = "JsonFiles/Items/ItemModifyers";
    private static string predefinedItemsJsonPath = "JsonFiles/Items/PredefinedItems";

    private static string itemIconPathRoot = "ItemIcons/";
    private static string amuletIconsPath = "Amulets/";
    private static string armorIconsPath = "Armor/";
    private static string consumablesIconsPath = "Consumables/";
    private static string weaponsIconsPath = "Weapons/";
    private static string questIconsPath = "Quest/";
    private static string defaultIcon = "Default_Icon";
    #endregion
    #endregion

    static ItemGenerator() {
        InitializeBaseItems();
        InitializeItemModifyers();
        InitializePredefinedItems();
    }

    #region Methods
    #region InitializationMethods
    private static void InitializeBaseItems() {
        BaseItemsRow[] rows = JsonUtility.FromJson<BaseItemsRowWrapper>(Resources.Load<TextAsset>(baseItemsJsonPath).text).BaseItemsRow;
        Item tmpItem = new Item(false);
        baseItems = new Dictionary<EEquipmentType, Item>();
        foreach(BaseItemsRow row in rows) {
            //Set base Item info
            tmpItem.Name = row.ItemName;
            tmpItem.FlavorText = row.FlavorText;
            tmpItem.IconPath = row.IconPath;
            //Set ItemStats
            tmpItem.Stats.Health = row.Health;
            tmpItem.Stats.Attack = row.Attack;
            tmpItem.Stats.Strength = row.Strength;
            tmpItem.Stats.Intelect = row.Intelect;
            tmpItem.Stats.Dexterity = row.Dexterity;
            tmpItem.Stats.Durability = row.Durability;
            tmpItem.Stats.Weight = row.Weight;
            tmpItem.Stats.EquipLoad = row.EquipLoad;
            tmpItem.Stats.GoldValue = row.GoldValue;
            tmpItem.Stats.ScrapValue = row.ScrapValue;
            //Set ItemTypes, which need Enum parsing
            tmpItem.Types.EquipmentType = (EEquipmentType)System.Enum.Parse(typeof(EEquipmentType), row.EEquipmentType);
            tmpItem.Types.ItemType = (EItemType)System.Enum.Parse(typeof(EItemType), row.EItemType);
            tmpItem.Types.EquipSlot = (EItemEquipSlot)System.Enum.Parse(typeof(EItemEquipSlot), row.EItemEquipSlot);
            tmpItem.Types.DamageType = (EWeaponDamageType)System.Enum.Parse(typeof(EWeaponDamageType), row.EWeaponDamageType);
            tmpItem.Types.WeaponRange = (EWeaponRange)System.Enum.Parse(typeof(EWeaponRange), row.EWeaponRange);
            tmpItem.Types.WeightClass = (EItemWeightClass)System.Enum.Parse(typeof(EItemWeightClass), row.EItemWeightClass);
            //Add tmpItem to dictionary
            baseItems.Add(tmpItem.Types.EquipmentType, new Item(tmpItem));
        }
    }
    private static void InitializeItemModifyers() {
        ItemModifyersRow[] rows = JsonUtility.FromJson<ItemModifyersRowWrapper>(Resources.Load<TextAsset>(itemModifyersJsonPath).text).ItemModifyersRow;
        ItemStats stats = new ItemStats();
        string[] prefixes;
        string[] suffixes;
        EItemModifyer itemModifyer;
        itemModifyers = new Dictionary<EItemModifyer, ItemModifyer>();
        foreach(ItemModifyersRow row in rows) {
            //Split PrefixNames and SuffixNames to get array of name modifyers
            prefixes = row.PrefixNames.Split(itemModifyerNameSplitChar);
            suffixes = row.SuffixNames.Split(itemModifyerNameSplitChar);
            //Set values of stats
            stats.Health = row.Health;
            stats.Attack = row.Attack;
            stats.Strength = row.Strength;
            stats.Intelect = row.Intelect;
            stats.Dexterity = row.Dexterity;
            stats.Durability = row.Durability;
            stats.Weight = row.Weight;
            stats.EquipLoad = row.EquipLoad;
            stats.GoldValue = row.GoldValue;
            stats.ScrapValue = row.ScrapValue;
            //Parse EItemModifyer
            itemModifyer = (EItemModifyer)System.Enum.Parse(typeof(EItemModifyer), row.EItemModifyer);
            //Create new ItemModifyer and add to dictionary
            itemModifyers.Add(itemModifyer, new ItemModifyer(stats, prefixes, suffixes));
        }
    }
    private static void InitializePredefinedItems() {
        PredefinedItemRow[] rows = JsonUtility.FromJson<PredefinedItemRowWrapper>(Resources.Load<TextAsset>(predefinedItemsJsonPath).text).PredefinedItemsRow;
        ItemStats stats = new ItemStats();
        EPredefinedItem predefinedItem;
        EEquipmentType equipmentType;
        EItemRarity rarity;
        EItemModifyer prefixModifyer;
        EItemModifyer suffixModifyer;
        predefinedItems = new Dictionary<EPredefinedItem, PredefinedItem>();
        foreach(PredefinedItemRow row in rows) {
            //Set stats values
            stats.Health = row.Health;
            stats.Attack = row.Attack;
            stats.Strength = row.Strength;
            stats.Intelect = row.Intelect;
            stats.Dexterity = row.Dexterity;
            stats.Durability = row.Durability;
            stats.Weight = row.Weight;
            stats.EquipLoad = row.EquipLoad;
            stats.GoldValue = row.GoldValue;
            stats.ScrapValue = row.ScrapValue;
            //Parse enums
            predefinedItem = (EPredefinedItem)System.Enum.Parse(typeof(EPredefinedItem), row.EPredefinedItem);
            equipmentType = (EEquipmentType)System.Enum.Parse(typeof(EEquipmentType), row.EEquipmentType);
            rarity = (EItemRarity)System.Enum.Parse(typeof(EItemRarity), row.Rarity);
            prefixModifyer = (EItemModifyer)System.Enum.Parse(typeof(EItemModifyer), row.PrefixModifyer);
            suffixModifyer = (EItemModifyer)System.Enum.Parse(typeof(EItemModifyer), row.SuffixModifyer);
            //Create new PredefinedItem and add to dictionary
            predefinedItems.Add(predefinedItem, new PredefinedItem(row.Level, row.Seed, equipmentType, rarity, prefixModifyer, suffixModifyer, row.PrefixIndex, row.SuffexIndex, row.OverrideBaseStats, stats));
        }
    }
    #endregion

    #region ItemGeneration
    public static Item GeneratePredefinedItem(EPredefinedItem predefinedItem) {
        PredefinedItem pdItem = predefinedItems[predefinedItem];
        item = new Item(baseItems[pdItem.EquipmentType]);
        item.Seed = pdItem.Seed;
        item.Types.Rarity = pdItem.Rarity;
        item.Types.PrefixModifyer = pdItem.PrefixModifyer;
        item.Types.SuffixModifyer = pdItem.SuffixModifyer;
        item.PrefixIndex = pdItem.PrefixIndex;
        item.SuffixIndex = pdItem.SuffixIndex;

        if(pdItem.OverrideBaseStats)
            item.Stats = new ItemStats(pdItem.Stats);

        item.Name = GetItemModifyerName(item.Name, pdItem.PrefixModifyer, pdItem.SuffixModifyer, pdItem.PrefixIndex, pdItem.SuffixIndex);
        item.Stats = GetItemModifyerStats(item.Stats, pdItem.PrefixModifyer, pdItem.SuffixModifyer);
        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);

        item.ID = GenerateID(item);
        item.Stats = CalculateItemStats(item);
        return new Item(item, true);
    }
    public static Item GenerateRandomItem() {
        EItemModifyer prefixIM = EItemModifyer.NONE;
        EItemModifyer suffixIM = EItemModifyer.NONE;
        int prefixIndex = 0;
        int suffixIndex = 0;

        item = new Item(baseItems[GenerateEquipmentType()]);
        item.Level = GenerateItemLevel();
        item.Types.Rarity = GenerateItemRarity();

        GenerateIM(item.Types.Rarity, out prefixIM, out suffixIM);
        item.Types.PrefixModifyer = prefixIM;
        item.Types.SuffixModifyer = suffixIM;

        item.Name = GetItemModifyerName(item.Name, item.Types.PrefixModifyer, item.Types.SuffixModifyer, out prefixIndex, out suffixIndex);
        item.PrefixIndex = prefixIndex;
        item.SuffixIndex = suffixIndex;

        item.Stats = GetItemModifyerStats(item.Stats, item.Types.PrefixModifyer, item.Types.SuffixModifyer);
        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);

        item.Seed = Random.Range(0, 9999);

        //following need to be called last to override base stats in id>item, and save base stats in id
        item.ID = GenerateID(item); 
        item.Stats = CalculateItemStats(item);

        return new Item(item, true);
    }
    public static Item ReforgeItem(Item item, float successChance) {
        item = new Item(item, false);
        item.Types.Rarity = (EItemRarity)(int)(Mathf.Clamp(Mathf.Floor((float)item.Types.Rarity) + (Random.Range(-1.5f + successChance, 2)), 0, 3));
        item.ID = GenerateID(item);
        item.Stats = CalculateItemStats(item);

        return new Item(item, true);
    }
    public static Item IDToItem(string id) {
        string[] splits = id.Split(seperationChar);
        int[] values = new int[16];
        if(splits.Length != 17)
            Debug.LogError("Split failed!");
        //hard coded length because it needs to be that value

        for(int i = 1; i < 17; i++) {
            try {
                values[i - 1] = int.Parse(splits[i]);
            }
            catch(System.FormatException e) {
                Debug.LogException(e);
            }
        }

        item = new Item(baseItems[(EEquipmentType)values[0]]);
        item.Level = values[1];
        item.Types.Rarity = (EItemRarity)values[2];
        item.Types.PrefixModifyer = (EItemModifyer)values[3];
        item.Types.SuffixModifyer = (EItemModifyer)values[4];
        item.PrefixIndex = values[5];
        item.SuffixIndex = values[6];
        item.Name = GetItemModifyerName(item.Name, item.Types.PrefixModifyer, item.Types.SuffixModifyer, values[5], values[6]);
        item.Stats = new ItemStats(item.Stats.Weight, values[7], values[8], values[9], values[10], values[11], item.Stats.EquipLoad, values[12], values[13], values[14]);
        item.Seed = values[15];
        item.Stats = CalculateItemStats(item);

        item.IconPath = GetIconPath(item.Types.ItemType, item.IconPath);
        item.ID = id;
        return new Item(item, true);
    }
    #endregion

    #region ItemModifyers
    private static void GenerateIM(EItemRarity rarity, out EItemModifyer prefixIM, out EItemModifyer suffixIM) {
        bool getSuffix;
        int imToGen = Mathf.Clamp((int)rarity - 1, 0, 2);

        if(imToGen <= 0) {
            prefixIM = EItemModifyer.NONE;
            suffixIM = EItemModifyer.NONE;
        }
        else {
            getSuffix = (Random.Range((int)0, 2) == 0);

            if(imToGen == 1) {
                if(getSuffix) {
                    prefixIM = EItemModifyer.NONE;
                    suffixIM = (EItemModifyer)Random.Range(1, System.Enum.GetValues(typeof(EItemModifyer)).Length);
                }
                else {
                    suffixIM = EItemModifyer.NONE;
                    prefixIM = (EItemModifyer)Random.Range(1, System.Enum.GetValues(typeof(EItemModifyer)).Length);
                }
            }
            else {
                suffixIM = (EItemModifyer)Random.Range(1, System.Enum.GetValues(typeof(EItemModifyer)).Length);
                prefixIM = (EItemModifyer)Random.Range(1, System.Enum.GetValues(typeof(EItemModifyer)).Length);
            }
        }
    }
    private static string GetItemModifyerName(string inputName, EItemModifyer prefixIM, EItemModifyer suffixIM, out int prefixIndex, out int suffixIndex) {
        if(prefixIM != EItemModifyer.NONE)
            inputName = itemModifyers[prefixIM].GetPrefix(out prefixIndex) + " " + inputName;
        else
            prefixIndex = 0;
        if(suffixIM != EItemModifyer.NONE)
            inputName = inputName + " " + itemModifyers[suffixIM].GetSuffix(out suffixIndex);
        else
            suffixIndex = 0;
        return inputName;
    }
    private static string GetItemModifyerName(string inputName, EItemModifyer prefixIM, EItemModifyer suffixIM, int prefixIndex, int suffixIndex) {
        if(prefixIM != EItemModifyer.NONE)
            inputName = itemModifyers[prefixIM].GetPrefix(prefixIndex) + " " + inputName;
        if(suffixIM != EItemModifyer.NONE)
            inputName = inputName + " " + itemModifyers[suffixIM].GetSuffix(suffixIndex);
        return inputName;
    }
    private static ItemStats GetItemModifyerStats(ItemStats inputStats, EItemModifyer prefixIM, EItemModifyer suffixIM) {
        if(prefixIM != EItemModifyer.NONE)
            inputStats.AddStats(itemModifyers[prefixIM].StatModifyer);
        else if(suffixIM != EItemModifyer.NONE)
            inputStats.AddStats(itemModifyers[suffixIM].StatModifyer);
        return inputStats;
    }

    private static ItemModifyer GetItemModifyer(EItemModifyer modifyer) {
        return itemModifyers[modifyer];
    }
    #endregion

    #region RandomTypeMethods
    private static EEquipmentType GenerateEquipmentType() {
        return GenereteRandomEquipmentType(GenerateRandomItemType());
    }
    private static EItemType GenerateRandomItemType() {
        return (EItemType)Random.Range(0, 4);
    }
    private static EEquipmentType GenereteRandomEquipmentType(EItemType itemType) {
        switch(itemType) {
            case EItemType.CONSUMABLE:
                return (EEquipmentType)Random.Range(etConsumable, etHeld);
            case EItemType.HELD:
                return (EEquipmentType)Random.Range(etHeld, etArmor);
            case EItemType.ARMOR:
                return (EEquipmentType)Random.Range(etArmor, etAmulet);
            case EItemType.ACCESSORY:
                return (EEquipmentType)Random.Range(etAmulet, etQuest);
            case EItemType.QUEST:
                return (EEquipmentType)Random.Range(etQuest, etEnd);
            default:
                Debug.LogError("Invalid case.");
                return EEquipmentType.AMULET;
        }
    }
    private static EItemRarity GenerateItemRarity() {
        return (EItemRarity)(Random.Range((int)0, 4));
    }
    #endregion

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

    private static string GetIconPath(EItemType itemType, string baseIconName) {
        switch(itemType) {
            case EItemType.ACCESSORY:
                return itemIconPathRoot + amuletIconsPath + baseIconName;
            case EItemType.ARMOR:
                return itemIconPathRoot + armorIconsPath + baseIconName;
            case EItemType.CONSUMABLE:
                return itemIconPathRoot + consumablesIconsPath + baseIconName;
            case EItemType.QUEST:
                return itemIconPathRoot + questIconsPath + baseIconName;
            case EItemType.HELD:
                return itemIconPathRoot + weaponsIconsPath + baseIconName;
            default:
                Debug.LogError("Invalid item type");
                return itemIconPathRoot + defaultIcon;
        }
    }

    private static int GenerateItemLevel() {
        return Random.Range((int)0, 100);
    }
    
    private static ItemStats CalculateItemStats(Item item) {
        return itemStatsCalculator.CalculateItemStats(item.Stats, item.Types.Rarity, item.Level, item.Seed);
    }
    #endregion
}