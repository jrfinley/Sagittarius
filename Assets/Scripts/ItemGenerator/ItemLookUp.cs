using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ItemGeneratorHelpers {
    public class ItemLookUp {
        #region Variables
        #region ItemLookUp
        private Dictionary<EEquipmentType, Item> itemLookUpTable = new Dictionary<EEquipmentType, Item>() {
        { EEquipmentType.POTION_OF_HEALING, new Item(
                "Potion of Healing", "Tastes like cereal with a hint of not dying a horible death", "Potion_of_Healing",
                new ItemStats(0, 5, 0, 0, 0, 0, 0, 1, 2, 2),
                new ItemTypes(EItemType.CONSUMABLE, EEquipmentType.POTION_OF_HEALING, EItemEquipSlot.NONE, EItemWeightClass.NONE, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON)
            ) },
        { EEquipmentType.LOCK_PICK, new Item(
                "Lock Pick", "A key to opportunity, and someone's wallet", "Lock_Pick",
                new ItemStats(0, 0, 0, 0, 0, 5, 0, 1, 2, 2),
                new ItemTypes(EItemType.CONSUMABLE, EEquipmentType.LOCK_PICK, EItemEquipSlot.NONE, EItemWeightClass.NONE, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON)
            ) },
        { EEquipmentType.AXE, new Item(
                "Axe", "Chop your foes asunder", "Axe",
                new ItemStats(2, 0, 4, 2, 0, 1, 2, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.AXE, EItemEquipSlot.ONE_HAND, EItemWeightClass.MEDIUM, EWeaponDamageType.SLASHING, EWeaponRange.MEDIUM, EItemRarity.COMMON)
            ) },
        { EEquipmentType.MACE, new Item(
                "Mace", "Big stick with pointy bits, perfect against armor", "Mace",
                new ItemStats(3, 0, 3, 3, 0, 0, 3, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.MACE, EItemEquipSlot.ONE_HAND, EItemWeightClass.HEAVY, EWeaponDamageType.BLUNT, EWeaponRange.MEDIUM, EItemRarity.COMMON)
            ) },
        { EEquipmentType.DAGGER, new Item(
                "Dagger", "A small nimble blade with many uses", "Axe",
                new ItemStats(1, 0, 2, 1, 0, 5, 1, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.DAGGER, EItemEquipSlot.ONE_HAND, EItemWeightClass.VERY_LIGHT, EWeaponDamageType.SLASHING, EWeaponRange.CLOSE, EItemRarity.COMMON)
            ) },
        { EEquipmentType.ARMING_SWORD, new Item(
                "Arming Sword", "Your standard slashing sword", "Arming_Sword",
                new ItemStats(3, 0, 4, 3, 0, 1, 3, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.ARMING_SWORD, EItemEquipSlot.ONE_HAND, EItemWeightClass.MEDIUM, EWeaponDamageType.SLASHING, EWeaponRange.MEDIUM, EItemRarity.COMMON)
            ) },
        { EEquipmentType.LONG_SWORD, new Item(
                "Long Sword", "A two handed blade with some reach", "Long_Sword",
                new ItemStats(4, 0, 6, 4, 0, 0, 4, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.LONG_SWORD, EItemEquipSlot.TWO_HAND, EItemWeightClass.HEAVY, EWeaponDamageType.SLASHING, EWeaponRange.REACH, EItemRarity.COMMON)
            ) },
        { EEquipmentType.GREAT_SWORD, new Item(
                "Great Sword", "A two handed blade that is comicly big", "Great_Sword",
                new ItemStats(6, 0, 7, 6, 0, 0, 5, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.GREAT_SWORD, EItemEquipSlot.TWO_HAND, EItemWeightClass.VERY_HEAVY, EWeaponDamageType.SLASHING, EWeaponRange.LONG_REACH, EItemRarity.COMMON)
            ) },
        { EEquipmentType.RAPIER, new Item(
                "Rapier", "Suprisingly heavy, yet it's faster and fancy", "Rapier",
                new ItemStats(3, 0, 4, 2, 0, 2, 3, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.RAPIER, EItemEquipSlot.ONE_HAND, EItemWeightClass.MEDIUM, EWeaponDamageType.PIERCING, EWeaponRange.REACH, EItemRarity.COMMON)
            ) },
        { EEquipmentType.SHORT_BOW, new Item(
                "Short Bow", "A standard bow. Keep your distance", "Short_Bow",
                new ItemStats(2, 0, 3, 2, 0, 4, 2, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.SHORT_BOW, EItemEquipSlot.TWO_HAND, EItemWeightClass.MEDIUM, EWeaponDamageType.PIERCING, EWeaponRange.RANGED, EItemRarity.COMMON)
            ) },
        { EEquipmentType.LONG_BOW, new Item(
                "Long Bow", "A larger bow meant to hit enemies far away, rather than acros the room", "Long_Bow",
                new ItemStats(3, 0, 4, 3, 0, 1, 3, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.LONG_BOW, EItemEquipSlot.TWO_HAND, EItemWeightClass.HEAVY, EWeaponDamageType.PIERCING, EWeaponRange.RANGED, EItemRarity.COMMON)
            ) },
        { EEquipmentType.CROSSBOW, new Item(
                "Crossbow", "Lots of power but needs time to reload", "Crossbow",
                new ItemStats(3, 0, 5, 5, 0, 0, 3, 10, 5, 5),
                new ItemTypes(EItemType.WEAPON, EEquipmentType.CROSSBOW, EItemEquipSlot.TWO_HAND, EItemWeightClass.HEAVY, EWeaponDamageType.PIERCING, EWeaponRange.RANGED, EItemRarity.COMMON)
            ) },
        { EEquipmentType.ARMOR, new Item(
                "Armor", "Protect thyne knees", "Armor",
                new ItemStats(3, 5, 0, 0, 0, 0, 3, 10, 5, 5),
                new ItemTypes(EItemType.ARMOR, EEquipmentType.ARMOR, EItemEquipSlot.ARMOR, EItemWeightClass.HEAVY, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON)
            ) },
        { EEquipmentType.AMULET, new Item(
                "Amulet", "Feels magical", "Amulet",
                new ItemStats(1, 1, 0, 0, 3, 0, 1, 10, 5, 5),
                new ItemTypes(EItemType.AMULET, EEquipmentType.AMULET, EItemEquipSlot.ACCESSORY, EItemWeightClass.NONE, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON)
            ) },
        { EEquipmentType.TEST_QEUST_ITEM, new Item(
                "Test Quest Item", "I suppose this is important since I can't drop it", "Test_Quest_Item",
                new ItemStats(0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                new ItemTypes(EItemType.QUEST, EEquipmentType.TEST_QEUST_ITEM, EItemEquipSlot.NONE, EItemWeightClass.NONE, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON)
            ) }
    };
        #endregion
        #endregion

        #region Properties
        public Dictionary<EEquipmentType, Item> ItemLookUpTable {
            get { return itemLookUpTable; }
        }
        #endregion
    }
}
