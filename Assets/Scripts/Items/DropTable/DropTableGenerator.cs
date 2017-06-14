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
        //I heard you liked comments... 
        //... the punch line is the amount of time I spent just commenting this
        //note most of the time when I say "value" in this, I am reffering to a float from 0-1 (inclusive)
        //load from JSON
        DropTableRow[] rows = JsonUtility.FromJson<DropTableRowWrapper>(Resources.Load<TextAsset>(GetJsonPath(dungeon)).text).DroptableRow;
        Dictionary<EMonsterType, DropTableElement[]> dropTable = new Dictionary<EMonsterType, DropTableElement[]>();
        //This bool is used for the special ANY row, this must be in the first row or non existant
        bool conatinsAnyRow = rows[0].EMonsterType == "ANY";

        //If the special case of ANY is used, ANY is in row[0]
        if(conatinsAnyRow) {
            //Check to see if both the enums and values contain equal values before continuing
            if(!ContainsEqualLengthRows(rows[0], 0, dungeon)) 
                return null;
            DropTableElement[] elementsANY = new DropTableElement[rows[0].DropWeight.Length];
            //fill out elementsANY with values from first row
            for(int i = 0; i < elementsANY.Length; i++) {
                elementsANY[i] = new DropTableElement((EEquipmentType)System.Enum.Parse(typeof(EEquipmentType), rows[0].EEquipmentType[i]), rows[0].DropWeight[i]);
            }
            //fill out the drop table
            for(int i = 1; i < rows.Length; i++) /* i is representing each monster */ {
                //Check to see if both the enums and values contain equal values before continuing
                if(!ContainsEqualLengthRows(rows[i], i, dungeon))
                    return null;

                int length = rows[i].DropWeight.Length + elementsANY.Length; //lenght is the number of elements for ANY and the i monster
                DropTableElement[] elements = new DropTableElement[length]; 
                float[] weights = new float[length]; //this is needed for adding arrays
                EEquipmentType[] items = new EEquipmentType[length]; //this is needed for adding arrays
                int index = 0; //index is the index for elements, which has the length of the elements for ANY and the i monster
                float totalWeights = 0; //used for averaging to turn weights into values

                //copy the weights and enums for the i monster into the repective arrays
                for(int j = 0; j < rows[i].DropWeight.Length; j++) {
                    weights[index] = rows[i].DropWeight[j]; //copy over the weights
                    items[index] = (EEquipmentType)System.Enum.Parse(typeof(EEquipmentType), rows[i].EEquipmentType[j]); //parse and copy EEuipmentType
                    totalWeights += weights[index]; //adding weights to get average later
                    index++; //iterate the index for weights and items
                }
                //copy the weights and enums for ANY into the repective arrays
                for(int j = 0; j < elementsANY.Length; j++) {
                    weights[index] = elementsANY[j].dropChance; //copy over the weights from ANY
                    items[index] = elementsANY[j].item; //copy over the enums from ANY
                    totalWeights += weights[index]; //adding weights to get average later
                    index++; //iterate the index for weights and items
                }
                //in the case where wights or items contains duplicate elements, it will still work properly, it will just use more memory
                for(int j = 0; j < length; j++) {
                    elements[j] = new DropTableElement(items[j], weights[j] / totalWeights); //iput the enums and the % the weight is in the total average
                }
                dropTable.Add((EMonsterType)System.Enum.Parse(typeof(EMonsterType), rows[i].EMonsterType), elements); //then add the elements to the dictionary with the corresponding monster
            }
            return new DropTable(dropTable);
        }
        //Else do normal operations
        //fill out the drop table
        for(int i = 1; i < rows.Length; i++) /* i is representing each monster */ {
            //Check to see if both the enums and values contain equal values before continuing
            if(!ContainsEqualLengthRows(rows[i], i, dungeon))
                return null;
            int length = rows[i].DropWeight.Length; //the length of the array of values for a monster
            DropTableElement[] elements = new DropTableElement[length]; //each element is a value enum pair for a item drop for one monster
            float[] weights = new float[length]; //values for one monster
            EEquipmentType[] items = new EEquipmentType[length]; //enums for one monster
            float totalWeights = 0; //used for averaging to turn weights into values

            for(int j = 0; j < rows[i].DropWeight.Length; j++) {
                totalWeights += weights[j]; //adding weights to get average later, there is a formula to progressively calc the average but we would still need to change the old average retroactively
            }
            //need second loop because of total weights
            for(int j = 0; j < length; j++) {
                elements[j] = new DropTableElement(
                                    (EEquipmentType)System.Enum.Parse(typeof(EEquipmentType), rows[i].EEquipmentType[j]), //parse the string for EEquipmentType
                                    rows[i].DropWeight[j] / totalWeights //find what % the weight is in the total average to get a value
                                );
            }
            dropTable.Add((EMonsterType)System.Enum.Parse(typeof(EMonsterType), rows[i].EMonsterType), elements); //then add the elements to the dictionary with the corresponding monster
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
