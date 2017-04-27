using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemStatsCalculator {

    public ItemStats CalculateItemStats(ItemStats baseStats, EItemRarity itemRarity, int itemLevel) {
        baseStats.AddToAll((float)itemRarity * 2f);
        baseStats.MultiplyByAll(Mathf.Sqrt(itemLevel + 1) + 1);
        baseStats.MultiplyByAll(Random.Range(.95f, 1.2f));
        return new ItemStats(baseStats);
    }
}
