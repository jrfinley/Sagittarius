using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ItemGeneratorHelpers {
    public class ItemStatsCalculator {

        public ItemStats CalculateItemStats(ItemStats baseStats, EItemRarity itemRarity, int itemLevel) {
            baseStats.AddToAll((float)itemRarity * 2f);
            baseStats.MultiplyByAll(Mathf.Sqrt(itemLevel + 1) + 1);
            return new ItemStats(baseStats);
        }
    }
}
