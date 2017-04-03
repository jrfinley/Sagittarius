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

    public static CurrencyManager currencyManager;

    public int gold;
    public int scrap;
    public int food;


    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();
        currencyManager = FindObjectOfType<CurrencyManager>();

        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
        inventoryItem = FindObjectsOfType<InventoryItem>();
    }

    public void StoreData()
    {
        data.food = currencyManager.food;
        data.scrap = currencyManager.scrap;
        data.gold = currencyManager.gold;


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
        /*foreach (BaseCharacter character in playerParty.characters)
        {
            int counter = 0;
           // data.characters = new BaseCharacter[3];
            data.characters = playerParty.characters;
            data.characters[counter].Name = playerParty.characters[counter].Name;
            data.characters[counter].Level = playerParty.characters[counter].Level;
            data.characters[counter].Health = playerParty.characters[counter].Health;
            counter++;
        }*/
        #endregion
    }

    void LoadData()
    {
        data.playerParty = FindObjectOfType<PlayerParty>();
        if (this.gameObject.GetComponent<DestroyOnLoad>())
        {
            Destroy(this.gameObject);
        }

        currencyManager.gold = data.gold;
        currencyManager.scrap = data.scrap;
        currencyManager.food = data.food;


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

        /*playerParty.AddPartyMember(1, "Chad", ECharacterType.MAGE, 100);
        playerParty.AddPartyMember(1 + 1, "Bob", ECharacterType.ROGUE, 100);
        playerParty.AddPartyMember(1 + 2, "Rando", ECharacterType.WARRIOR, 100);*/

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

    public BaseCharacter[] characters;

    public PlayerParty playerParty;

    public static CurrencyManager currencyManager;

    public int gold;
    public int scrap;
    public int food;


}
