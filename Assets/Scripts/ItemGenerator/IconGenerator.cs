using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IconGenerator {
    private string itemPathRoot = "ItemIcons/";
    private string amuletPath = "Amulets/";
    private string armorPath = "Armor/";
    private string consumablesPath = "Consumables/";
    private string weaponsPath = "Weapons/";
    private string questPath = "Qeust/";
    private string defaultIcon = "Default_Icon";

    private string name = string.Empty;

    private Dictionary<EEquipmentType, string> iconChart = new Dictionary<EEquipmentType, string>() {
        { EEquipmentType.POTION_OF_HEALING, "Potion_of_Healing" },
        { EEquipmentType.LOCK_PICK,         "Lock_Pick" },

        { EEquipmentType.AXE,               "Axe" },
        { EEquipmentType.MACE,              "Mace" },
        { EEquipmentType.DAGGER,            "Dagger" },
        { EEquipmentType.ARMING_SWORD,      "Arming_Sword" },
        { EEquipmentType.LONG_SWORD,        "Long_Sword" },
        { EEquipmentType.GREAT_SWORD,       "Great_Sword" },
        { EEquipmentType.RAPIER,            "Rapier" },
        { EEquipmentType.SHORT_BOW,         "Short_Bow" },
        { EEquipmentType.LONG_BOW,          "Long_Bow" },
        { EEquipmentType.CROSSBOW,          "Crossbow" },

        { EEquipmentType.ARMOR,             "Armor" },

        { EEquipmentType.AMULET,            "Amulet" },

        { EEquipmentType.TEST_QEUST_ITEM,   "Test_Quest_Item" }
    };

    public string GenerateIcon(EEquipmentType equipmentType, EItemType itemType) {
        try {
            name = GetPathName(itemType) + iconChart[equipmentType];
        }
        catch {
            name = itemPathRoot + defaultIcon;
        }
        return name;
    }
    private string GetPathName(EItemType itemType)
    {
        switch(itemType) {
            case EItemType.AMULET:
                return itemPathRoot + amuletPath;
            case EItemType.ARMOR:
                return itemPathRoot + armorPath;
            case EItemType.CONSUMABLE:
                return itemPathRoot + consumablesPath;
            case EItemType.QUEST:
                return itemPathRoot + questPath;
            case EItemType.WEAPON:
                return itemPathRoot + weaponsPath;
            default:
                Debug.LogError("Invalid item type");
                return itemPathRoot + defaultIcon;
        }
    }
}
