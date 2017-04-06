using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemStatsCalculator {
    private ItemStats itemStats = new ItemStats();

    public ItemStats CalculateItemStats(ItemStats baseStats, EItemRarity itemRarity, int itemLevel) {
        itemStats.AddToAll((float)itemRarity * 2f);
        itemStats.MultiplyByAll(Mathf.Sqrt(itemLevel + 1) + 1);
        itemStats.MultiplyByAll(Random.Range(.95f, 1.2f));
        return new ItemStats(itemStats);
    }
}
