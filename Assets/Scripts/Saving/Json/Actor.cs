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

    public PlayerParty playerParty;


    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();
        data.playerParty = FindObjectOfType<PlayerParty>();
        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
        inventoryItem = FindObjectsOfType<InventoryItem>();
    }

    public void StoreData()
    {
        //stores item/ inventory info
        data.items = inventoryDisplay.items;

        foreach(InventoryItem inventoryItem in inventoryDisplay.items)
        {
            //data.inventoryItemDisplayPrefab = inventoryItemDisplayPrefab;
            //data.targetTransform = targetTransform;
            //data.inventoryItemDisplayPrefab = inventoryItemDisplayPrefab;
            //data.targetTransform = targetTransform;
            data.ids.Add(inventoryItem.id);
            Debug.Log("inventoryItemID = " + inventoryItem.id);
        }

        #region
        //Saves player party info
        foreach (BaseCharacter character in playerParty.characters)
        {
            int counter = 1;

            data.charLevel = playerParty.characters[0].Level;
            data.charHealth = playerParty.characters[0].MaxHealth;
            data.charStr = playerParty.characters[0].Strength;
            data.charDex = playerParty.characters[0].Dexterity;
            data.charInt = playerParty.characters[0].Intelect;
            data.charExp = playerParty.characters[0].Experience;
            data.charEquipCap = playerParty.characters[0].EquipmentCapacity;


            counter++;
        }
        #endregion
    }

    void LoadData()
    {
        data.playerParty = FindObjectOfType<PlayerParty>();
        playerParty = FindObjectOfType<PlayerParty>();

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

        playerParty.AddPartyMember(1, "Chad", ECharacterType.WARRIOR, 100);
        //assign stuff
        playerParty.characters[0].Name = data.charName;
        playerParty.characters[0].Level = data.charLevel;
        playerParty.characters[0].MaxHealth = data.charHealth;
        playerParty.characters[0].Strength = data.charStr;
        playerParty.characters[0].Dexterity = data.charDex;
        playerParty.characters[0].Intelect = data.charInt;
        playerParty.characters[0].Experience = data.charExp;
        playerParty.characters[0].EquipmentCapacity = data.charEquipCap;

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
    public List<int> ids = new List<int>();

    public InventoryItemDisplay inventoryItemDisplayPrefab;

    public List<InventoryItem> items = new List<InventoryItem>();

    public Vector3 pos;

    public Transform targetTransform;

    //public BaseCharacter[] characters;

    public PlayerParty playerParty;

    public static CurrencyManager currencyManager;

    public string charName;
    public int charLevel;
    public int charHealth;
    public int charStr;
    public int charDex;
    public int charInt;
    public int charExp;
    public int charEquipCap;
   
}
