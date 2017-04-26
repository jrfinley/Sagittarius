using UnityEngine;
using System.Collections;

public class ItemTypes {
    #region Varaibles
    private EItemType itemType = EItemType.AMULET;
    private EEquipmentType equipmentType = EEquipmentType.AMULET;
    private EItemEquipSlot equipSlot = EItemEquipSlot.NONE;
    private EItemWeightClass weightClass = EItemWeightClass.NONE;
    private EWeaponDamageType damageType = EWeaponDamageType.NONE;
    private EWeaponRange weaponRange = EWeaponRange.NONE;
    private EItemRarity itemRarity = EItemRarity.COMMON;
    private EItemModifyer prefixItemModifyer = EItemModifyer.NONE;
    private EItemModifyer suffixItemModifyer = EItemModifyer.NONE;
    #endregion

    #region Properties
    public EItemType ItemType {
        get {
            return itemType;
        }
        set {
            itemType = value;
        }
    }
    public EEquipmentType EquipmentType {
        get {
            return equipmentType;
        }
        set {
            equipmentType = value;
        }
    }
    public EItemEquipSlot EquipSlot {
        get {
            return equipSlot;
        }
        set {
            equipSlot = value;
        }
    }
    public EItemWeightClass WeightClass {
        get {
            return weightClass;
        }
        set {
            weightClass = value;
        }
    }
    public EWeaponDamageType DamageType {
        get {
            return damageType;
        }
        set {
            damageType = value;
        }
    }
    public EWeaponRange WeaponRange {
        get {
            return weaponRange;
        }
        set {
            weaponRange = value;
        }
    }
    public EItemRarity ItemRarity {
        get {
            return itemRarity;
        }
        set {
            itemRarity = value;
        }
    }
    public EItemModifyer PrefixItemModifyer {
        get {
            return prefixItemModifyer;
        }
        set {
            prefixItemModifyer = value;
        }
    }
    public EItemModifyer SuffixItemModifyer {
        get {
            return suffixItemModifyer;
        }
        set {
            suffixItemModifyer = value;
        }
    }
    #endregion

    #region Contructors
    public ItemTypes() { }
    public ItemTypes(EItemType itemType, EEquipmentType equipmentType, EItemEquipSlot equipSlot, EItemWeightClass weightClass,
            EWeaponDamageType damageType, EWeaponRange weaponRange, EItemRarity itemRarity) {
        this.itemType = itemType;
        this.equipmentType = equipmentType;
        this.equipSlot = equipSlot;
        this.weightClass = weightClass;
        this.damageType = damageType;
        this.weaponRange = weaponRange;
        this.itemRarity = itemRarity;
    }
    public ItemTypes(ItemTypes itemTypes) {
        this.itemType = itemTypes.ItemType;
        this.equipmentType = itemTypes.EquipmentType;
        this.equipSlot = itemTypes.EquipSlot;
        this.weightClass = itemTypes.WeightClass;
        this.damageType = itemTypes.DamageType;
        this.weaponRange = itemTypes.WeaponRange;
        this.itemRarity = itemTypes.ItemRarity;
    }
    #endregion
}
