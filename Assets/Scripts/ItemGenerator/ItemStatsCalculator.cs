using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ItemGeneratorHelpers {
    public class ItemStatsCalculator {

        public ItemStats CalculateItemStats(ItemStats baseStats, EItemRarity itemRarity, int itemLevel, int itemSeed) {
            Random.seed = itemSeed;

            baseStats.AddToAll((float)itemRarity * 2f);
            baseStats.MultiplyByAll(Mathf.Sqrt(itemLevel + 1) + Random.Range(.8f, 1.2f));

            Random.seed = (int)System.DateTime.Now.Ticks;
            return new ItemStats(baseStats);
        }
    }
}
