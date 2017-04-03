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
    public string GenerateIM(EItemRarity itemRarity, string itemName) {
        imToGen = Mathf.Clamp((int)itemRarity - 1, 0, 2);
        
        if(imToGen <= 0)
            return itemName;
        getSuffix = true;
        if(Random.Range((int)0, 2) == 0)
            getSuffix = false;
        for(int i = 0; i < imToGen; i++) {
            itemModifyer = EItemModifyer.STRENGTH;// (EItemModifyer)Random.Range(0, System.Enum.GetValues(typeof(EItemModifyer)).Length);
            if(getSuffix)
                itemName = itemName + " " + itemModifyers[itemModifyer].GetSuffix();
            else
                itemName = itemModifyers[itemModifyer].GetPrefix() + " " + itemName;
            getSuffix = !getSuffix;
            //itemStats.AddStats(itemModifyers[itemModifyer].StatModifyer);
        }
        return itemName;
    }
    private string GetIMPrefix(EItemModifyer modifyer) {
        return GetIM(modifyer).GetPrefix();
    }
    private string GetIMSuffix(EItemModifyer modifyer) {
        return GetIM(modifyer).GetSuffix();
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
                new ItemStats(0, 0, 0, 0, 1, 0, 0, 0, 0),
                new string[] { "Nimble", "Hardy", "Dexterous" },
                new string[] { "of Dexterity", "of Dodging", "of Nimbleness" }
                )
            );
    }
    private void AddIMEquipLoad() {
        itemModifyers.Add(
            EItemModifyer.EQUIP_LOAD,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 0, -1, 0, 0, 0, 0),
                new string[] { "Light", "Hole Filled" },
                new string[] { "of Low Equip Weight" }
                )
            );
    }
    private void AddIMGoldValue() {
        itemModifyers.Add(
            EItemModifyer.GOLD_VALUE,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 0, 0, 0, 0, 1, 0),
                new string[] { "Gold Plated", "Golden", "Extravagent" },
                new string[] { "of Wealth", "of the Wealthy", "of Gold" }
                )
            );
    }
    private void AddIMHealth() {
        itemModifyers.Add(
            EItemModifyer.HEALTH,
            new ItemModifyer(
                new ItemStats(0, 1, 0, 0, 0, 0, 0, 0, 0),
                new string[] { "Sturdy", "Hardy", "Tough" },
                new string[] { "of Sturdyness", "of Good Health" }
                )
            );
    }
    private void AddIMIntelect() {
        itemModifyers.Add(
            EItemModifyer.INTELECT,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 1, 0, 0, 0, 0, 0),
                new string[] { "Witty", "Educated" },
                new string[] { "That Is Smarter Than You", "of Intelect", "of Information" }
                )
            );
    }
    private void AddIMScrapValue() {
        itemModifyers.Add(
            EItemModifyer.SCRAP_VALUE,
            new ItemModifyer(
                new ItemStats(0, 0, 0, 0, 0, 0, 0, 0, 1),
                new string[] { "sCrappy", "Junky", "Junkyark" },
                new string[] { "of Junk", "of Metal Scraps" }
                )
            );
    }
    private void AddIMStrength() {
        itemModifyers.Add(
            EItemModifyer.STRENGTH,
            new ItemModifyer(
                new ItemStats(0, 0, 1, 0, 0, 0, 0, 0, 0),
                new string[] { "Strong", "Swole", "Bulky" },
                new string[] { "of Swoleness", "of Power", "of Ripped Abs" }
                )
            );
    }
    #endregion
}
