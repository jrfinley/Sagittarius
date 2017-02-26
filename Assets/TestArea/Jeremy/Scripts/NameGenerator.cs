using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NameGenerator {
    #region Variables
    private Dictionary<EEquipmentType, string> baseName = new Dictionary<EEquipmentType, string>() {
        { EEquipmentType.POTION_OF_HEALING, "Potion of Healing" },
        { EEquipmentType.LOCK_PICK, "Lock Pick" },

        { EEquipmentType.AXE, "Axe" },
        { EEquipmentType.MACE, "Mace" },
        { EEquipmentType.DAGGER, "Dagger" },
        { EEquipmentType.ARMING_SWORD, "Arming Sword" },
        { EEquipmentType.LONG_SWORD, "Long Sword" },
        { EEquipmentType.GREAT_SWORD, "Great Sword" },
        { EEquipmentType.RAPIER, "Rapier" },
        { EEquipmentType.SHORT_BOW, "Short Bow" },
        { EEquipmentType.LONG_BOW, "Long Bow" },
        { EEquipmentType.CROSSBOW, "Crossbow" },

        { EEquipmentType.ARMOR, "Armor" },

        { EEquipmentType.AMULET, "Amulet" },

        { EEquipmentType.TEST_QEUST_ITEM, "Test Quest Item" }
    };
    private string[] nameModifyer = new string[]{
        "Flaming", "Frosty", "Poisonus",
        "Sharp", "Large", "Nimble", "Bloody", "Light"
    };
    private string[] rarityModifyer = new string[3] { "Rare", "Epic", "Legendary" };
    private string name = string.Empty;
    private string space = " ";
    #endregion

    #region Methods
    public string GenerateName(Item item) {
        name = baseName[item.EquipmentType];
        for(int i = 1; i <= (int)item.ItemRarity; i++) { //Adds +1 random name mod for each rarity above common
            AddToStartOfName(nameModifyer[Random.Range(0, nameModifyer.Length)]);
        }
        switch(item.ItemRarity) {
            case EItemRarity.COMMON:
                break;
            case EItemRarity.RARE:
                AddToStartOfName(rarityModifyer[0]);
                break;
            case EItemRarity.EPIC:
                AddToStartOfName(rarityModifyer[1]);
                break;
            case EItemRarity.LEGENDARY:
                AddToStartOfName(rarityModifyer[2]);
                break;
            default:
                Debug.LogError("Invalid case.");
                break;
        }
        return name;
    }
    private void AddToStartOfName(string addition) {
        name = addition + space + name;
    }
    #endregion
}
