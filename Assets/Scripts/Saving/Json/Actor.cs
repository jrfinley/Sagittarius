using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    public string itemName;
    [Multiline]
    public string desc;
    public int strength;
    public int intellect;
    public int dexterity;
    public int gold;
    public int scrap;
    public int id;

    public InventoryItemDisplay inventoryItemDisplayPrefab;

    private InventoryItem[] inventoryItem;
    public static InventoryDisplay inventoryDisplay;

    public Vector3 pos;

    public Transform targetTransform;


    void Start()
    {
        inventoryDisplay = GetComponent<InventoryDisplay>();
        inventoryItem = FindObjectsOfType<InventoryItem>();
    }

    public void StoreData()
    {
        data.items = inventoryDisplay.items;

        foreach(InventoryItem inventoryItem in data.items)
        {
            data.inventoryItemDisplayPrefab = inventoryItemDisplayPrefab;
            data.targetTransform = targetTransform;
            data.itemName = inventoryItem.name;
            data.desc = inventoryItem.desc;
            data.strength = inventoryItem.strength;
            data.intellect = inventoryItem.intellect;
            data.dexterity = inventoryItem.dexterity;
            data.gold = inventoryItem.gold;
            data.scrap = inventoryItem.scrap;
            data.id = inventoryItem.id;

            //data.items.Add(inventoryItem);
            
        }
    }

    void LoadData()
    {
        inventoryDisplay.items = data.items;

        foreach (InventoryItem inventoryItem in data.items)
        {
            inventoryItemDisplayPrefab = data.inventoryItemDisplayPrefab;
            InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(data.inventoryItemDisplayPrefab);
            targetTransform = data.targetTransform;
            display.transform.SetParent(targetTransform, false);
            display.Prime(inventoryItem);

            inventoryItem.name = data.itemName;
            inventoryItem.desc = data.desc;
            inventoryItem.strength = data.strength;
            inventoryItem.intellect = data.intellect;
            inventoryItem.dexterity = data.dexterity;
            inventoryItem.gold = data.gold;
            inventoryItem.scrap = data.scrap;
            inventoryItem.id = data.id;

            //inventoryDisplay.items.Add(inventoryItem);

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
    public string itemName;

    [Multiline]
    public string desc;

    public int strength;
    public int intellect;
    public int dexterity;
    public int gold;
    public int scrap;
    public int id;

    public InventoryItemDisplay inventoryItemDisplayPrefab;

    public List<InventoryItem> items = new List<InventoryItem>();

    public Vector3 pos;

    public Transform targetTransform;
}
