using UnityEngine;
using System.Collections;

namespace ItemGeneratorHelpers {
    public class PredefinedItem {
        #region Variables
        private int level = 0;
        private int seed = 0;
        private EEquipmentType equipmentType;
        private EItemRarity rarity = EItemRarity.COMMON;
        private EItemModifyer prefixModifyer = EItemModifyer.NONE;
        private EItemModifyer suffixModifyer = EItemModifyer.NONE;
        private int prefixIndex = 0;
        private int suffixIndex = 0;
        private ItemStats stats;
        private bool overrideBaseStats = false; //if true, use this.stats rather than normal equipment stats
        #endregion

        #region Properties
        public int Level { get { return level; } }
        public int Seed { get { return seed; } }
        public EItemRarity Rarity { get { return rarity; } }
        public EEquipmentType EquipmentType { get { return equipmentType; } }
        public EItemModifyer PrefixModifyer { get { return prefixModifyer; } }
        public EItemModifyer SuffixModifyer { get { return suffixModifyer; } }
        public int PrefixIndex { get { return prefixIndex; } }
        public int SuffixIndex { get { return suffixIndex; } }
        public ItemStats Stats { get { return stats; } }
        public bool OverrideBaseStats { get { return overrideBaseStats; } }
        #endregion

        #region Constructors
        public PredefinedItem(int level, int seed, EEquipmentType equipmentType, EItemRarity rarity) {
            this.level = level;
            this.seed = seed;
            this.equipmentType = equipmentType;
            this.rarity = rarity;

            overrideBaseStats = false;
        }
        public PredefinedItem(int level, int seed, EEquipmentType equipmentType, EItemRarity rarity, EItemModifyer prefixModifyer, EItemModifyer suffixModifyer, int prefixIndex, int suffixIndex) {
            this.level = level;
            this.seed = seed;
            this.equipmentType = equipmentType;
            this.rarity = rarity;

            this.prefixModifyer = prefixModifyer;
            this.suffixModifyer = suffixModifyer;
            this.prefixIndex = prefixIndex;
            this.suffixIndex = suffixIndex;

            overrideBaseStats = false;
        }
        public PredefinedItem(int level, int seed, EEquipmentType equipmentType, EItemRarity rarity, ItemStats stats) {
            this.level = level;
            this.seed = seed;
            this.equipmentType = equipmentType;
            this.rarity = rarity;

            this.stats = stats;

            overrideBaseStats = true;
        }
        public PredefinedItem(int level, int seed, EEquipmentType equipmentType, EItemRarity rarity, EItemModifyer prefixModifyer, EItemModifyer suffixModifyer, int prefixIndex, int suffixIndex, ItemStats stats) {
            this.level = level;
            this.seed = seed;
            this.equipmentType = equipmentType;
            this.rarity = rarity;

            this.prefixModifyer = prefixModifyer;
            this.suffixModifyer = suffixModifyer;
            this.prefixIndex = prefixIndex;
            this.suffixIndex = suffixIndex;

            this.stats = stats;

            overrideBaseStats = true;
        }
        #endregion
    }
}

