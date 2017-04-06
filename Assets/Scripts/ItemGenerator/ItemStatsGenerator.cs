using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemStatsGenerator {
    private ItemStats itemStats = new ItemStats();
    private Dictionary<EEquipmentType, ItemStats> itemStatSheet = new Dictionary<EEquipmentType, ItemStats>() {
        { EEquipmentType.POTION_OF_HEALING, new ItemStats(0, 5, 0, 0, 0, 0, 0, 1, 2, 2) },
        { EEquipmentType.LOCK_PICK,         new ItemStats(0, 0, 0, 0, 0, 5, 0, 1, 2, 2) },

        { EEquipmentType.AXE,               new ItemStats(2, 0, 4, 2, 0, 1, 2, 10, 5, 5) },
        { EEquipmentType.MACE,              new ItemStats(3, 0, 3, 3, 0, 0, 3, 10, 5, 5) },
        { EEquipmentType.DAGGER,            new ItemStats(1, 0, 2, 1, 0, 5, 1, 10, 5, 5) },
        { EEquipmentType.ARMING_SWORD,      new ItemStats(3, 0, 4, 3, 0, 1, 3, 10, 5, 5) },
        { EEquipmentType.LONG_SWORD,        new ItemStats(4, 0, 6, 4, 0, 0, 4, 10, 5, 5) },
        { EEquipmentType.GREAT_SWORD,       new ItemStats(6, 0, 7, 6, 0, 0, 5, 10, 5, 5) },
        { EEquipmentType.RAPIER,            new ItemStats(3, 0, 4, 2, 0, 2, 3, 10, 5, 5) },
        { EEquipmentType.SHORT_BOW,         new ItemStats(2, 0, 3, 2, 0, 4, 2, 10, 5, 5) },
        { EEquipmentType.LONG_BOW,          new ItemStats(3, 0, 4, 3, 0, 1, 3, 10, 5, 5) },
        { EEquipmentType.CROSSBOW,          new ItemStats(3, 0, 5, 5, 0, 0, 3, 10, 5, 5) },

        { EEquipmentType.ARMOR,             new ItemStats(3, 5, 0, 0, 0, 0, 3, 10, 5, 5) },

        { EEquipmentType.AMULET,            new ItemStats(1, 1, 0, 0, 3, 0, 1, 10, 5, 5) },

        { EEquipmentType.TEST_QEUST_ITEM,   new ItemStats(0, 0, 0, 0, 0, 0, 0, 0, 0, 0) }
    };
    public ItemStats GenerateItemStats(EEquipmentType equipmentType, EItemRarity itemRarity, int itemLevel) {
        itemStats = itemStatSheet[equipmentType];
        itemStats.AddToAll((float)itemRarity * 2f);
        itemStats.MultiplyByAll(Mathf.Sqrt(itemLevel + 1) + 1);
        itemStats.MultiplyByAll(Random.Range(.95f, 1.2f));
        return itemStats;
    }
}
