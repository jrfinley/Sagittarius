﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public InventoryDisplay inventory;

    void Awake()
    {
        inventory.Prime(items);
    }

}
