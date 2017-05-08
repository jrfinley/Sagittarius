using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ItemGeneratorHelpers{
    public class IconPathLookUp {
        private string itemPathRoot = "ItemIcons/";
        private string amuletPath = "Amulets/";
        private string armorPath = "Armor/";
        private string consumablesPath = "Consumables/";
        private string weaponsPath = "Weapons/";
        private string questPath = "Quest/";
        private string defaultIcon = "Default_Icon";

        public string GetPathName(EItemType itemType) {
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
}
