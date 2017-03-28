using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemTypesGenerator {
    private int etConsumable = 0;
    private int etWeapon = 2;
    private int etArmor = 12;
    private int etAmulet = 13;
    private int etQuest = 14;
    private int etEnd = 15;

    private ItemTypes itemTypes;
    private Dictionary<EEquipmentType, ItemTypes> consumables = new Dictionary<EEquipmentType, ItemTypes>() {
        { EEquipmentType.POTION_OF_HEALING,   new ItemTypes(EItemType.CONSUMABLE, EEquipmentType.POTION_OF_HEALING, EItemEquipSlot.NONE, 
                                                    EItemWeightClass.NONE, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON) },
        { EEquipmentType.LOCK_PICK,   new ItemTypes(EItemType.CONSUMABLE, EEquipmentType.LOCK_PICK, EItemEquipSlot.NONE,
                                                    EItemWeightClass.NONE, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON) }
    };
    private Dictionary<EEquipmentType, ItemTypes> weapons = new Dictionary<EEquipmentType, ItemTypes>() {
        { EEquipmentType.AXE,                 new ItemTypes(EItemType.WEAPON, EEquipmentType.AXE, EItemEquipSlot.ONE_HAND, 
                                                    EItemWeightClass.MEDIUM, EWeaponDamageType.SLASHING, EWeaponRange.MEDIUM, EItemRarity.COMMON) },

        { EEquipmentType.MACE,                new ItemTypes(EItemType.WEAPON, EEquipmentType.MACE, EItemEquipSlot.ONE_HAND,
                                                    EItemWeightClass.HEAVY, EWeaponDamageType.BLUNT, EWeaponRange.MEDIUM, EItemRarity.COMMON) },

        { EEquipmentType.DAGGER,              new ItemTypes(EItemType.WEAPON, EEquipmentType.DAGGER, EItemEquipSlot.ONE_HAND,
                                                    EItemWeightClass.VERY_LIGHT, EWeaponDamageType.SLASHING, EWeaponRange.CLOSE, EItemRarity.COMMON) },

        { EEquipmentType.ARMING_SWORD,        new ItemTypes(EItemType.WEAPON, EEquipmentType.ARMING_SWORD, EItemEquipSlot.ONE_HAND,
                                                    EItemWeightClass.MEDIUM, EWeaponDamageType.SLASHING, EWeaponRange.MEDIUM, EItemRarity.COMMON) },

        { EEquipmentType.LONG_SWORD,          new ItemTypes(EItemType.WEAPON, EEquipmentType.LONG_SWORD, EItemEquipSlot.TWO_HAND,
                                                    EItemWeightClass.HEAVY, EWeaponDamageType.SLASHING, EWeaponRange.REACH, EItemRarity.COMMON) },

        { EEquipmentType.GREAT_SWORD,         new ItemTypes(EItemType.WEAPON, EEquipmentType.GREAT_SWORD, EItemEquipSlot.TWO_HAND,
                                                    EItemWeightClass.VERY_HEAVY, EWeaponDamageType.PIERCING, EWeaponRange.LONG_REACH, EItemRarity.COMMON) },

        { EEquipmentType.RAPIER,              new ItemTypes(EItemType.WEAPON, EEquipmentType.RAPIER, EItemEquipSlot.ONE_HAND,
                                                    EItemWeightClass.MEDIUM, EWeaponDamageType.PIERCING, EWeaponRange.REACH, EItemRarity.COMMON) },

        { EEquipmentType.SHORT_BOW,           new ItemTypes(EItemType.WEAPON, EEquipmentType.SHORT_BOW, EItemEquipSlot.TWO_HAND,
                                                    EItemWeightClass.MEDIUM, EWeaponDamageType.PIERCING, EWeaponRange.RANGED, EItemRarity.COMMON) },

        { EEquipmentType.LONG_BOW,            new ItemTypes(EItemType.WEAPON, EEquipmentType.LONG_BOW, EItemEquipSlot.TWO_HAND,
                                                    EItemWeightClass.HEAVY, EWeaponDamageType.PIERCING, EWeaponRange.RANGED, EItemRarity.COMMON) },

        { EEquipmentType.CROSSBOW,            new ItemTypes(EItemType.WEAPON, EEquipmentType.CROSSBOW, EItemEquipSlot.TWO_HAND,
                                                    EItemWeightClass.HEAVY, EWeaponDamageType.PIERCING, EWeaponRange.RANGED, EItemRarity.COMMON) }        
    };
    private Dictionary<EEquipmentType, ItemTypes> armor = new Dictionary<EEquipmentType, ItemTypes>() {
        { EEquipmentType.ARMOR,               new ItemTypes(EItemType.ARMOR, EEquipmentType.ARMOR, EItemEquipSlot.ARMOR,
                                                    EItemWeightClass.HEAVY, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON) }        
    };
    private Dictionary<EEquipmentType, ItemTypes> amulet = new Dictionary<EEquipmentType, ItemTypes>() {
        { EEquipmentType.AMULET,              new ItemTypes(EItemType.AMULET, EEquipmentType.AMULET, EItemEquipSlot.ACCESSORY,
                                                    EItemWeightClass.NONE, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON) }        
    };
    private Dictionary<EEquipmentType, ItemTypes> quests = new Dictionary<EEquipmentType, ItemTypes>() {
        { EEquipmentType.TEST_QEUST_ITEM,     new ItemTypes(EItemType.QUEST, EEquipmentType.TEST_QEUST_ITEM, EItemEquipSlot.NONE,
                                                    EItemWeightClass.NONE, EWeaponDamageType.NONE, EWeaponRange.NONE, EItemRarity.COMMON) }
    };

    public ItemTypes GenerateItemTypes() {
        switch(GenerateRandomItemType()) {
            case EItemType.AMULET:
                GenerateAmulet();
                break;
            case EItemType.ARMOR:
                GenerateArmor();
                break;
            case EItemType.CONSUMABLE:
                GenerateConsumable();
                break;
            case EItemType.WEAPON:
                GenerateWeapon();
                break;
            case EItemType.QUEST:
                itemTypes = quests[EEquipmentType.TEST_QEUST_ITEM];
                break;
        }
        return itemTypes;
    }
    public ItemTypes GenerateItemTypes(EItemType typeToGenerate) {
        switch(typeToGenerate) {
            case EItemType.AMULET:
                GenerateAmulet();
                break;
            case EItemType.ARMOR:
                GenerateArmor();
                break;
            case EItemType.CONSUMABLE:
                GenerateConsumable();
                break;
            case EItemType.WEAPON:
                GenerateWeapon();
                break;
            case EItemType.QUEST:
                itemTypes = quests[EEquipmentType.TEST_QEUST_ITEM];
                break;
        }
        return itemTypes;
    } 
    private EItemType GenerateRandomItemType() {
        return (EItemType)Random.Range(0, 4);
    }
    public EEquipmentType GenereteEquipmentType(EItemType itemType) {
        switch(itemType) {
            case EItemType.CONSUMABLE:
                return (EEquipmentType)Random.Range(etConsumable, etWeapon);
            case EItemType.WEAPON:
                return (EEquipmentType)Random.Range(etWeapon, etArmor);
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
    private void GenerateConsumable() {
        itemTypes = consumables[GenereteEquipmentType(EItemType.CONSUMABLE)];
    }
    private void GenerateWeapon() {
        itemTypes = weapons[GenereteEquipmentType(EItemType.WEAPON)];
    }
    private void GenerateArmor() {
        itemTypes = armor[GenereteEquipmentType(EItemType.ARMOR)];
    }
    private void GenerateAmulet() {
        itemTypes = amulet[GenereteEquipmentType(EItemType.AMULET)];
    }
}
