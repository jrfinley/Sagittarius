using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    //public int id;

    public InventoryItemDisplay inventoryItemDisplayPrefab;

    private InventoryItem[] inventoryItem;
    public static InventoryDisplay inventoryDisplay;

    public Vector3 pos;

    public static Transform targetTransform;

    public List<int> ids = new List<int>();

    public static PlayerParty playerParty;


    void Start()
    {
        inventoryDisplay = GetComponent<InventoryDisplay>();
        inventoryItem = FindObjectsOfType<InventoryItem>();       
    }

    public void StoreData()
    {
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
    }

    void LoadData()
    {
        inventoryDisplay.items = data.items;
        //ids = data.ids;

        foreach (int id in data.ids)
        {
            //inventoryItemDisplayPrefab = data.inventoryItemDisplayPrefab;
            //InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(data.inventoryItemDisplayPrefab);
            //targetTransform = data.targetTransform;
            //display.transform.SetParent(targetTransform, false);
            //display.Prime(inventoryItem);
            ids.Add(id);
            Debug.Log("inventoryItemID = " + id.ToString());
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
}
