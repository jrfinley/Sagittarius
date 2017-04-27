using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemModifyerGenerator {
    #region Varaibles
    private Dictionary<EItemModifyer, ItemModifyer> itemModifyers = new Dictionary<EItemModifyer, ItemModifyer>();
    private EItemModifyer itemModifyer;
    private int imToGen;
    private bool getSuffix;
    #endregion

    #region Properties
    public Dictionary<EItemModifyer, ItemModifyer> ItemModifyers {
        get { return itemModifyers; }
        private set { itemModifyers = value; }
    }
    #endregion

    #region Constructors
    public ItemModifyerGenerator() {
        AddAllItemModifyers();
    }
    #endregion

    #region Methods
    public void GenerateIM(EItemRarity rarity, ref EItemModifyer prefixIM, ref EItemModifyer suffixIM) {
        prefixIM = EItemModifyer.NONE;
        suffixIM = EItemModifyer.NONE;

        imToGen = Mathf.Clamp((int)rarity - 1, 0, 2);

        if(imToGen <= 0)            
            return;            

        getSuffix = true;
        if(Random.Range((int)0, 2) == 0)
            getSuffix = false;

        for(int i = 0; i < imToGen; i++) {
            itemModifyer = (EItemModifyer)Random.Range(1, System.Enum.GetValues(typeof(EItemModifyer)).Length);
            if(getSuffix)
                suffixIM = itemModifyer;
            else
                prefixIM = itemModifyer;
                getSuffix = !getSuffix;
        }
    }
    public string GetIMName(string inputName, EItemModifyer prefixIM, EItemModifyer suffixIM, out int prefixIndex, out int suffixIndex) {
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
    public string GetIMName(string inputName, EItemModifyer prefixIM, EItemModifyer suffixIM, int prefixIndex, int suffixIndex) {
        if(prefixIM != EItemModifyer.NONE)
            inputName = itemModifyers[prefixIM].GetPrefix(prefixIndex) + " " + inputName;
        if(suffixIM != EItemModifyer.NONE)
            inputName = inputName + " " + itemModifyers[suffixIM].GetSuffix(suffixIndex);
        return inputName;
    }
    public ItemStats GetIMStats(ItemStats inputStats, EItemModifyer prefixIM, EItemModifyer suffixIM) {
        if(prefixIM != EItemModifyer.NONE)
            inputStats.AddStats(itemModifyers[prefixIM].StatModifyer);
        else if(suffixIM != EItemModifyer.NONE)
            inputStats.AddStats(itemModifyers[suffixIM].StatModifyer);
        return inputStats;
    }

    private ItemModifyer GetIM(EItemModifyer modifyer) {
        return itemModifyers[modifyer];
    }

    private void AddAllItemModifyers() {
        AddIMDexterity();
        AddIMEquipLoad();
        AddIMGoldValue();
        AddIMHealth();
        AddIMIntelect();
        AddIMScrapValue();
        AddIMStrength();
    }
    private void AddIMDexterity() {
        itemModifyers.Add(
            EItemModifyer.DEXTERITY, 
            new ItemModifyer(
                new ItemStats(0, 0, 0, 0, 0, 1, 0, 0, 0, 0),
                new string[] { "Nimble", "Hardy", "Dexterous" },
                new string[] { "of Dexterity", "of Dodging", "of Nimbleness" }
                )
            );
    }
    private void AddIMEquipLoad() {
        itemModifyers.Add(
            EItemModifyer.EQUIP_LOAD,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 0, 0, -1, 0, 0, 0, 0),
                new string[] { "Light", "Hole Filled" },
                new string[] { "of Low Equip Weight" }
                )
            );
    }
    private void AddIMGoldValue() {
        itemModifyers.Add(
            EItemModifyer.GOLD_VALUE,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 0, 0, 0, 0, 0, 1, 0),
                new string[] { "Gold Plated", "Golden", "Extravagent" },
                new string[] { "of Wealth", "of the Wealthy", "of Gold" }
                )
            );
    }
    private void AddIMHealth() {
        itemModifyers.Add(
            EItemModifyer.HEALTH,
            new ItemModifyer(
                new ItemStats(0, 1, 0, 0, 0, 0, 0, 0, 0, 0),
                new string[] { "Sturdy", "Hardy", "Tough" },
                new string[] { "of Sturdyness", "of Good Health" }
                )
            );
    }
    private void AddIMIntelect() {
        itemModifyers.Add(
            EItemModifyer.INTELECT,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 0, 1, 0, 0, 0, 0, 0),
                new string[] { "Witty", "Educated" },
                new string[] { "That Is Smarter Than You", "of Intelect", "of Information" }
                )
            );
    }
    private void AddIMScrapValue() {
        itemModifyers.Add(
            EItemModifyer.SCRAP_VALUE,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 0, 0, 0, 0, 0, 0, 1),
                new string[] { "sCrappy", "Junky", "Junkyark" },
                new string[] { "of Junk", "of Metal Scraps" }
                )
            );
    }
    private void AddIMStrength() {
        itemModifyers.Add(
            EItemModifyer.STRENGTH,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 1, 0, 0, 0, 0, 0, 0),
                new string[] { "Strong", "Swole", "Bulky" },
                new string[] { "of Swoleness", "of Power", "of Ripped Abs" }
                )
            );
    }
    #endregion
}
