using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EPredefinedItem {
    TEST_QUEST_NO_MODS,
    TEST_QUEST_MODS,
    TEST_QUEST_BASE_NO_MODS,
    TEST_QUEST_BASE_MODS
}; //if this is still here, that means i forgot to move this. Roast me @jeremy

namespace ItemGeneratorHelpers {
    public class PredefinedItems {
        private Dictionary<EPredefinedItem, PredefinedItem> predefinedItems = new Dictionary<EPredefinedItem, PredefinedItem>() {
            { EPredefinedItem.TEST_QUEST_NO_MODS, new PredefinedItem(1, 1234, EEquipmentType.TEST_QEUST_ITEM, EItemRarity.LEGENDARY) },
            { EPredefinedItem.TEST_QUEST_MODS, new PredefinedItem(1, 1234, EEquipmentType.TEST_QEUST_ITEM, EItemRarity.LEGENDARY, 
                    EItemModifyer.STRENGTH, EItemModifyer.STRENGTH, 1, 3) },
            { EPredefinedItem.TEST_QUEST_BASE_NO_MODS, new PredefinedItem(1, 1234, EEquipmentType.TEST_QEUST_ITEM, EItemRarity.LEGENDARY, 
                    new ItemStats(1, 1, 1, 1, 1, 1, 1, 1, 1, 1)) },
            { EPredefinedItem.TEST_QUEST_BASE_MODS, new PredefinedItem(1, 1234, EEquipmentType.TEST_QEUST_ITEM, EItemRarity.LEGENDARY, 
                    EItemModifyer.STRENGTH, EItemModifyer.STRENGTH, 1, 3, new ItemStats(1, 1, 1, 1, 1, 1, 1, 1, 1, 1)) }
        };

        public Dictionary<EPredefinedItem, PredefinedItem> PredefinedItem {
            get { return predefinedItems; }
        }
    }
}