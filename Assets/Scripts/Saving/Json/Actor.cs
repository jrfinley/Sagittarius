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

    public static PlayerParty playerParty;


    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();

        inventoryDisplay = GetComponent<InventoryDisplay>();
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

        //Saves player party info
        foreach (BaseCharacter character in playerParty.characters)
        {
            data.characters = new BaseCharacter[3];
            data.characters = playerParty.characters;
            Debug.Log("Saved BaseCharacters = " + data.characters[0]);
            Debug.Log("Saved BaseCharacters = " + data.characters[1]);
            Debug.Log("Saved BaseCharacters = " + data.characters[2]);

        }
    }

    void LoadData()
    {
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

        foreach(BaseCharacter character in data.characters)
        {
            int count = 0;
            //playerParty.characters = new BaseCharacter[3];
            playerParty.characters = data.characters;
            playerParty.characters[count] = data.characters[count];
            Debug.Log("Saved BaseCharacters = " + data.characters[0]);
            Debug.Log("Saved BaseCharacters = " + data.characters[1]);
            Debug.Log("Saved BaseCharacters = " + data.characters[2]);

            /*playerParty.AddPartyMember(count, playerParty.characters[count].name,
                playerParty.characters[count].CharacterType, playerParty.characters[count].Level);*/

            #region
            /*playerParty.characters[count].MaxHealth = data.characters[count].MaxHealth;
            playerParty.characters[count].Level = data.characters[count].Level;
            playerParty.characters[count].Strength = data.characters[count].Strength;
            playerParty.characters[count].Intelect = data.characters[count].Intelect;
            playerParty.characters[count].Dexterity = data.characters[count].Dexterity;
            playerParty.characters[count].Experience = data.characters[count].Experience;
            playerParty.characters[count].EquipmentCapacity = data.characters[count].EquipmentCapacity;



            Debug.Log("Loaded BaseCharacter" + playerParty.characters[count]);
            Debug.Log("Loaded BaseCharacter Health = " + playerParty.characters[count].MaxHealth);
            Debug.Log("Loaded BaseCharacter level = " + playerParty.characters[count].Level);
            Debug.Log("Loaded BaseCharacter strength = " + playerParty.characters[count].Strength);
            Debug.Log("Loaded BaseCharacter dexterity = " + playerParty.characters[count].Dexterity);
            Debug.Log("Loaded BaseCharacter intellect = " + playerParty.characters[count].Intelect);
            Debug.Log("Loaded BaseCharacter experience = " + playerParty.characters[count].Experience);
            Debug.Log("Loaded BaseCharacter equipCap = " + playerParty.characters[count].EquipmentCapacity);
            */
            #endregion
            count++;

        }
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
}
