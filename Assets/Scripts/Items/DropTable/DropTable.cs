using UnityEngine;
using System.Collections.Generic;

public class DropTable {
    //a drop table is the droptable for each monster's drop values
    private Dictionary<EMonsterType, DropTableElement[]> dropTable;
    private EEquipmentType defaultItem = EEquipmentType.AMULET; //for debugging

    public DropTable(Dictionary<EMonsterType, DropTableElement[]> dropTable) {

    }

    public EEquipmentType GetItemDrop(EMonsterType monster) {
        if(!IsIncluded(monster))
            return defaultItem;

        float dropValue = Random.value;
        int dropIndex = 0;
        int dteLength = dropTable[monster].Length;

        for(; dropIndex < dteLength; dropIndex++) {
            //DropTableElement.dropChance is a value from 0-1, calculated from dropweight when it was created
            //when dropValue is <= 0, then it is within that items drop chance range
            //this is basically creating ranges for each of the dropChances withough having them as actual ranges, which would take 2 values (min, max)
            dropValue -= dropTable[monster][dropIndex].dropChance;
            if(dropValue <= 0)
                break;
        }

        return dropTable[monster][dropIndex].item;
    }

    private bool IsIncluded(EMonsterType monster) {
        if(dropTable.ContainsKey(monster))
            return true;
        Debug.LogError("Monster (" + monster + ") is not included in the DropTable!");
        return false;
    }
}
