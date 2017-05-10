using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ItemGeneratorHelpers {
    public class ItemTypeGenerator {

        private int etConsumable = 0;
        private int etHeld = 2;
        private int etArmor = 13;
        private int etAmulet = 15;
        private int etQuest = 16;
        private int etEnd = 17;

        public EItemType GenerateRandomItemType() {
            return (EItemType)Random.Range(0, 4);
        }
        public EEquipmentType GenereteRandomEquipmentType(EItemType itemType) {
            switch(itemType) {
                case EItemType.CONSUMABLE:
                    return (EEquipmentType)Random.Range(etConsumable, etHeld);
                case EItemType.HELD:
                    return (EEquipmentType)Random.Range(etHeld, etArmor);
                case EItemType.ARMOR:
                    return (EEquipmentType)Random.Range(etArmor, etAmulet);
                case EItemType.AMULET:
                    return (EEquipmentType)Random.Range(etAmulet, etQuest);
                case EItemType.QUEST:
                    return (EEquipmentType)Random.Range(etQuest, etEnd);
                default:
                    Debug.LogError("Invalid case.");
                    return EEquipmentType.AMULET;
            }
        }
    }
}

