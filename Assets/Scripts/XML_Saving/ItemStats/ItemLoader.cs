using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemLoader : MonoBehaviour
{
    public const string path = "items";

    public InventoryItem inventoryItemAccessor;

    public List<InventoryItem> _items = new List<InventoryItem>();

    public InventoryItemDisplay itemPrefab;
    public Transform spawnPointItem;

    public InventoryDisplay inventoryDisplay;



    void Start ()
    {
        inventoryItemAccessor = FindObjectOfType<InventoryItem>();

        ItemContainer ic = ItemContainer.Load(path);

        Debug.Log("Got to path load");

        foreach (_Item_ item in ic.items)
        {
            Debug.Log("Got to first foreach");

            for (int i = 0; i < item._currentItemCount; i++)
            {
                Debug.Log("is counting for loop:" + i);

                foreach (InventoryItem _item in inventoryDisplay.items)
                {
                    InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(itemPrefab);
                    display.transform.SetParent(spawnPointItem, false);
                    display.Prime(_item);
                    item._name = inventoryItemAccessor.name;
                    item._desc = inventoryItemAccessor.desc;
                    item._strength = inventoryItemAccessor.strength;
                    item._intellect = inventoryItemAccessor.intellect;
                    item._dexterity = inventoryItemAccessor.dexterity;
                    item._goldValue = inventoryItemAccessor.gold;
                    item._scrapValue = inventoryItemAccessor.scrap;
                    item._id = inventoryItemAccessor.id;
                    Debug.Log("bottom of second foreach loop:");

                }

            }
        }
    }
	
	void Update ()
    {
        TestLoad();
    }

    void TestLoad()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ItemContainer ic = ItemContainer.Load(path);
            Debug.Log("Got to path load");

            foreach (_Item_ item in ic.items)
            {
                Debug.Log("Got to first foreach");

                for (int i = 0; i < item._currentItemCount; i++)
                {
                    Debug.Log("is counting for loop:" + i);

                    foreach (InventoryItem _item in inventoryDisplay.items)
                    {
                        InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(itemPrefab);
                        display.transform.SetParent(spawnPointItem, false);
                        display.Prime(_item);
                        item._name = inventoryItemAccessor.name;
                        item._desc = inventoryItemAccessor.desc;
                        item._strength = inventoryItemAccessor.strength;
                        item._intellect = inventoryItemAccessor.intellect;
                        item._dexterity = inventoryItemAccessor.dexterity;
                        item._goldValue = inventoryItemAccessor.gold;
                        item._scrapValue = inventoryItemAccessor.scrap;
                        item._id = inventoryItemAccessor.id;
                        Debug.Log("bottom of second foreach loop:");

                    }

                }                                      
            }
        }
    }
}
