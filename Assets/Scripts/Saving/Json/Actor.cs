using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    public InventoryItemDisplay inventoryItemDisplayPrefab;

    private InventoryItem[] inventoryItem;
    public static InventoryDisplay inventoryDisplay;

    public Vector3 pos;

    public static Transform targetTransform;

    public List<int> ids = new List<int>();
    public List<EItemType> itemTypes = new List<EItemType>();

    public PlayerParty playerParty;

    public CurrencyManager currencyManager;

    public CurrencyUI currencyUI;

    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();
        data.playerParty = FindObjectOfType<PlayerParty>();
        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
        inventoryItem = FindObjectsOfType<InventoryItem>();
        currencyManager = GetComponent<CurrencyManager>();
        currencyUI = FindObjectOfType<CurrencyUI>();
        Debug.Log("Gold: " + currencyManager.Gold.Value);
        Debug.Log("Scrap: " + currencyManager.Scrap.Value);
        Debug.Log("Food: " + currencyManager.Food.Value);    
    }

    public void StoreData()
    {
        //saved currencies
        data.goldValue += currencyManager.Gold.Value;
        data.scrapValue += currencyManager.Scrap.Value;
        data.foodValue += currencyManager.Food.Value;

        //stores item/ inventory info
        data.items = inventoryDisplay.items;

        foreach(InventoryItem inventoryItem in inventoryDisplay.items)
        {
            //data.inventoryItemDisplayPrefab = inventoryItemDisplayPrefab;
            //data.targetTransform = targetTransform;
            //data.inventoryItemDisplayPrefab = inventoryItemDisplayPrefab;
            //data.targetTransform = targetTransform;
            data.ids.Add(inventoryItem.id);
            data.itemTypes.Add(inventoryItem.itemType);
            Debug.Log("inventoryItemID = " + inventoryItem.id);
            Debug.Log("inventoryItemType = " + inventoryItem.itemType);

        }

        #region
        //Saves player party info
        foreach (BaseCharacter character in playerParty.characters)
        {
            int counter = 1;

            data.charName1 = playerParty.characters[0].Name;
            data.charLevel1 = playerParty.characters[0].Level;
            data.charHealth1 = playerParty.characters[0].MaxHealth;
            data.charStr1 = playerParty.characters[0].Strength;
            data.charDex1 = playerParty.characters[0].Dexterity;
            data.charInt1 = playerParty.characters[0].Intelect;
            data.charExp1 = playerParty.characters[0].Experience;
            data.charEquipCap1 = playerParty.characters[0].EquipmentCapacity;
            data.charType1 = playerParty.characters[0].CharacterType;

            data.charName2 = playerParty.characters[1].Name;
            data.charLevel2 = playerParty.characters[1].Level;
            data.charHealth2 = playerParty.characters[1].MaxHealth;
            data.charStr2 = playerParty.characters[1].Strength;
            data.charDex2 = playerParty.characters[1].Dexterity;
            data.charInt2 = playerParty.characters[1].Intelect;
            data.charExp2 = playerParty.characters[1].Experience;
            data.charEquipCap2 = playerParty.characters[1].EquipmentCapacity;
            data.charType2 = playerParty.characters[1].CharacterType;

            data.charName3 = playerParty.characters[2].Name;
            data.charLevel3 = playerParty.characters[2].Level;
            data.charHealth3 = playerParty.characters[2].MaxHealth;
            data.charStr3 = playerParty.characters[2].Strength;
            data.charDex3 = playerParty.characters[2].Dexterity;
            data.charInt3 = playerParty.characters[2].Intelect;
            data.charExp3 = playerParty.characters[2].Experience;
            data.charEquipCap3 = playerParty.characters[2].EquipmentCapacity;
            data.charType3 = playerParty.characters[2].CharacterType;
            counter++;
        }
        #endregion
    }

    void LoadData()
    {
        //currencies loaded
        currencyManager = GetComponent<CurrencyManager>();
        currencyUI = FindObjectOfType<CurrencyUI>();
        currencyManager.Gold.Value = data.goldValue;
        currencyManager.Scrap.Value = data.scrapValue;
        currencyManager.Food.Value = data.foodValue;
        Debug.Log("gold: " + currencyManager.Gold.Value);
        Debug.Log("scrap: " + currencyManager.Scrap.Value);
        Debug.Log("food: " + currencyManager.Food.Value);

        data.playerParty = FindObjectOfType<PlayerParty>();
        playerParty = FindObjectOfType<PlayerParty>();

        //kills this object if its the first version
        if (this.gameObject.GetComponent<DestroyOnLoad>())
        {
            Destroy(this.gameObject);
        }

        //loads item/ inventory info
        inventoryDisplay.items = data.items;

        foreach (int id in data.ids)
        {
            #region
            //inventoryItemDisplayPrefab = data.inventoryItemDisplayPrefab;
            //InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(data.inventoryItemDisplayPrefab);
            //targetTransform = data.targetTransform;
            //display.transform.SetParent(targetTransform, false);
            //display.Prime(inventoryItem);
            #endregion
            ids.Add(id);
            Debug.Log("inventoryItemID = " + id.ToString());
        }
        foreach(EItemType itemType in data.itemTypes)
        {
            itemTypes.Add(itemType);
            Debug.Log("InventoryItemType = " + itemType.ToString());
        }


        playerParty.AddPartyMember(1, "Chad", ECharacterType.WARRIOR, 100);
        //assign stuff
        playerParty.characters[0].Name = data.charName1;
        playerParty.characters[0].Level = data.charLevel1;
        playerParty.characters[0].MaxHealth = data.charHealth1;
        playerParty.characters[0].Strength = data.charStr1;
        playerParty.characters[0].Dexterity = data.charDex1;
        playerParty.characters[0].Intelect = data.charInt1;
        playerParty.characters[0].Experience = data.charExp1;
        playerParty.characters[0].EquipmentCapacity = data.charEquipCap1;
        playerParty.characters[0].CharacterType = data.charType1;

        playerParty.AddPartyMember(2, "bob", ECharacterType.WARRIOR, 100);
        //assign stuff
        playerParty.characters[1].Name = data.charName2;
        playerParty.characters[1].Level = data.charLevel2;
        playerParty.characters[1].MaxHealth = data.charHealth2;
        playerParty.characters[1].Strength = data.charStr2;
        playerParty.characters[1].Dexterity = data.charDex2;
        playerParty.characters[1].Intelect = data.charInt2;
        playerParty.characters[1].Experience = data.charExp2;
        playerParty.characters[1].EquipmentCapacity = data.charEquipCap2;
        playerParty.characters[1].CharacterType = data.charType2;

        playerParty.AddPartyMember(3, "Chad", ECharacterType.WARRIOR, 100);
        //assign stuff
        playerParty.characters[2].Name = data.charName3;
        playerParty.characters[2].Level = data.charLevel3;
        playerParty.characters[2].MaxHealth = data.charHealth3;
        playerParty.characters[2].Strength = data.charStr3;
        playerParty.characters[2].Dexterity = data.charDex3;
        playerParty.characters[2].Intelect = data.charInt3;
        playerParty.characters[2].Experience = data.charExp3;
        playerParty.characters[2].EquipmentCapacity = data.charEquipCap3;
        playerParty.characters[2].CharacterType = data.charType3;

    }

    public void ApplyData()
    {
        SaveData.AddActorData(data);
    }

    void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }
    void OnDisable()
    {
        SaveData.OnLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }
}

[Serializable]
public class ActorData
{
    //public InventoryItemDisplay inventoryItemDisplayPrefab;

    public List<int> ids = new List<int>();
    public List<InventoryItem> items = new List<InventoryItem>();
    public List<EItemType> itemTypes = new List<EItemType>();

    public Vector3 pos;

    public Transform targetTransform;

    //currencies
    public float goldValue;
    public float scrapValue;
    public float foodValue;

    //player party statistics
    public PlayerParty playerParty;
    //1
    public string charName1;
    public int charLevel1;
    public int charHealth1;
    public int charStr1;
    public int charDex1;
    public int charInt1;
    public int charExp1;
    public int charEquipCap1;
    public ECharacterType charType1; 
    //2
    public string charName2;
    public int charLevel2;
    public int charHealth2;
    public int charStr2;
    public int charDex2;
    public int charInt2;
    public int charExp2;
    public int charEquipCap2;
    public ECharacterType charType2;

    //3
    public string charName3;
    public int charLevel3;
    public int charHealth3;
    public int charStr3;
    public int charDex3;
    public int charInt3;
    public int charExp3;
    public int charEquipCap3;
    public ECharacterType charType3;

}
