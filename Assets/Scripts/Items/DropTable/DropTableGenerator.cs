using UnityEngine;
using System.Collections.Generic;
using JsonJunk;

public static class DropTableGenerator {
    #region Variables
    private static string rootJsonPaths = "JsonFiles/Items/DropTables/";
    private static Dictionary<EDungeon, string> jsonPaths = new Dictionary<EDungeon, string>() {
        { EDungeon.TUTORIAL, "Tutorial" }
    };
    #endregion

    public static DropTable GenerateDropTable(EDungeon dungeon) {
        DropTableRow[] rows = JsonUtility.FromJson<DropTableRowWrapper>(Resources.Load<TextAsset>(GetJsonPath(dungeon)).text).DroptableRow;
        Dictionary<EMonsterType, DropTableElement[]> dropTable = new Dictionary<EMonsterType, DropTableElement[]>();
        bool conatinsAnyRow = rows[0].EMonsterType == "ANY";

        if(conatinsAnyRow) {
            if(!ContainsEqualLengthRows(rows[0], 0, dungeon)) 
                return null;
            DropTableElement[] anyRowValue = new DropTableElement[rows[0].DropWeight.Length]; 
            //fill out anyRowValue with values from first row
            for(int i = 0; i < anyRowValue.Length; i++) {
                anyRowValue[i] = new DropTableElement((EEquipmentType)System.Enum.Parse(typeof(EEquipmentType), rows[0].EEquipmentType[i]), rows[0].DropWeight[i]);
            }
            //fill out the drop table
            for(int i = 1; i < rows.Length; i++) {
                if(!ContainsEqualLengthRows(rows[i], i, dungeon))
                    return null;

                int length = rows[i].DropWeight.Length + anyRowValue.Length;
                DropTableElement[] elements = new DropTableElement[length];
                float[] weights = new float[length];
                EEquipmentType[] items = new EEquipmentType[length];
                int index = 0;
                float totalWeights = 0;

                for(int j = 0; j < rows[i].DropWeight.Length; j++) {
                    weights[index] = rows[i].DropWeight[j];
                    items[index] = (EEquipmentType)System.Enum.Parse(typeof(EEquipmentType), rows[i].EEquipmentType[j]);
                    totalWeights += weights[index]; //adding weights to get average later
                    index++;
                }
                for(int j = 0; j < anyRowValue.Length; j++) {
                    weights[index] = anyRowValue[j].dropChance;
                    items[index] = anyRowValue[j].item;
                    totalWeights += weights[index]; //adding weights to get average later
                    index++;
                }
                //in the case where wights or items contains duplicate elements, it will still work properly, it will just use more memory
                for(int j = 0; j < length; j++) {
                    elements[j] = new DropTableElement(items[j], weights[j] / totalWeights);
                }
                dropTable.Add((EMonsterType)System.Enum.Parse(typeof(EMonsterType), rows[i].EMonsterType), elements);
            }
            return new DropTable(dropTable);
        }
        //fill out the drop table
        for(int i = 1; i < rows.Length; i++) {
            if(!ContainsEqualLengthRows(rows[i], i, dungeon))
                return null;
            int length = rows[i].DropWeight.Length;
            DropTableElement[] elements = new DropTableElement[length];
            float[] weights = new float[length];
            EEquipmentType[] items = new EEquipmentType[length];
            float totalWeights = 0;

            for(int j = 0; j < rows[i].DropWeight.Length; j++) {
                weights[j] = rows[i].DropWeight[j];
                items[j] = (EEquipmentType)System.Enum.Parse(typeof(EEquipmentType), rows[i].EEquipmentType[j]);
                totalWeights += weights[j]; //adding weights to get average later
            }
            //need second loop because of total weights
            for(int j = 0; j < length; j++) {
                elements[j] = new DropTableElement(items[j], weights[j] / totalWeights);
            }
            dropTable.Add((EMonsterType)System.Enum.Parse(typeof(EMonsterType), rows[i].EMonsterType), elements);
        }
        return new DropTable(dropTable);
    }

    private static string GetJsonPath(EDungeon dungeon) {
        return rootJsonPaths + jsonPaths[dungeon];
    }
    private static bool ContainsEqualLengthRows(DropTableRow row, int index, EDungeon dungeon) {
        if(row.EEquipmentType.Length == row.DropWeight.Length)
            return true;
        Debug.LogError("Row (" + index + ") of the dropTable for " + dungeon + " does not contain equal EEquipmentType values and DropWeight values. (" + row.EEquipmentType.Length + "," + row.DropWeight.Length + ")");
        return false;
    }
}
