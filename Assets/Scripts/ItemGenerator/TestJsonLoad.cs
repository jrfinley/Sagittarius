using UnityEngine;
using System.Collections;

public class TestJsonLoad : MonoBehaviour {
    [System.Serializable]
    public class JsonWrapper {
        [System.Serializable]
        public class ItemSpredsheetRow {
            public string EEquipmentType;
            public string ItemName;
            public string FlavorText;
            public string IconPath;
            public string EItemType;
            public string EItemEquipSlot;
            public string EItemWeightClass;
            public string EWeaponDamageType;
            public string EWeaponRange;
            public int Weight;
            public int Health;
            public int Attack;
            public int Strength;
            public int Intelect;
            public int Dexterity;
            public int EquipLoad;
            public int Durability;
            public int GoldValue;
            public int ScrapValue;
        }
        public ItemSpredsheetRow[] ItemSpreadsheetRow;
    }

    private TextAsset file;
    public JsonWrapper rows;

    private void Start() {
        TextAsset file = Resources.Load<TextAsset>("JsonFiles/Items/ItemSpreadsheet");
        Debug.Log(file.text);
        rows = JsonUtility.FromJson<JsonWrapper>(file.text);
    }
}
