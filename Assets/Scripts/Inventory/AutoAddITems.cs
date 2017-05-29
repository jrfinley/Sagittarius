using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
This classes sole purpose is entirely for just dragging the
in scene cude into the health potion prefab to allow item pickup
super basic
*/
public class AutoAddITems : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    private InventoryDisplay inventoryDisplay;


    void Start()
    {
        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
        //inventoryDisplay = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>().inventoryDisplay;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach(InventoryItem item in items)
            {
                gameObject.SetActive(false);
                inventoryDisplay.Prime(items);
                inventoryDisplay.items.Add(item);
                //actor.StoreData();
            }

        }
    }
}
