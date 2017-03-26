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

    public InventoryDisplay inventoryDisplay;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach(InventoryItem item in items)
            {
                inventoryDisplay.Prime(items);
                gameObject.SetActive(false);
                inventoryDisplay.items.Add(item);
            }

        }
    }
}
