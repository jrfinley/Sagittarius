using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryDisplay : MonoBehaviour
{
    public Transform targetTransform;
    public InventoryItemDisplay itemDisplayPrefab;

    public List<InventoryItem> items = new List<InventoryItem>();

    public void Prime(List<InventoryItem> items)
    {
        foreach(InventoryItem item in items)
        {
            InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(itemDisplayPrefab);
            display.transform.SetParent(targetTransform, false);
            display.Prime(item);
        }
    }
}
