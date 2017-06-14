using UnityEngine;
using System.Collections.Generic;

public class DropTable {
    #region Variables
    //a drop table is the droptable for each monster's drop values
    private Dictionary<EMonsterType, DropTableElement[]> dropTable;
    private EEquipmentType defaultItem = EEquipmentType.AMULET; //for debugging
    #endregion

    #region Constructors
    public DropTable(Dictionary<EMonsterType, DropTableElement[]> dropTable) {
        this.dropTable = new Dictionary<EMonsterType, DropTableElement[]>(dropTable);
    }
    #endregion

    #region Methods
    public EEquipmentType GetItemDrop(EMonsterType monster) {
        if(!IsIncluded(monster))
            return defaultItem;

        float dropValue = Random.value;
        int dtLength = dropTable[monster].Length; //chached for faster use

        for(int i = 0; i < dtLength; i++) {
            //DropTableElement.dropChance is a value from 0-1, calculated from dropweight when it was created
            //when dropValue is <= 0, then it is within that items drop chance range
            //this is basically creating ranges for each of the dropChances withough having them as actual ranges, which would take 2 values (min, max)
            dropValue -= dropTable[monster][i].dropChance;
            if(dropValue <= 0) {
                return dropTable[monster][i].item;
            }
        }
        Debug.LogError("Drop Table is incorrectly calculated! Final Value is: " + dropValue);
        return defaultItem;
    }

    private bool IsIncluded(EMonsterType monster) {
        if(dropTable.ContainsKey(monster))
            return true;
        Debug.LogError("Monster (" + monster + ") is not included in the DropTable!");
        return false;
    }
    #endregion
}
