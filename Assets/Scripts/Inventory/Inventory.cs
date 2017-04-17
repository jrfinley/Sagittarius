using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public InventoryDisplay inventory;
    public Text carryWeightText;

    void Awake()
    {
        inventory.Prime(items);
    }

    public void SetCarryWeight(int maxWeight, int currentWeight)
    {
        carryWeightText.text = currentWeight.ToString() + "/" + maxWeight.ToString() + "Lbs.";
    }

}
