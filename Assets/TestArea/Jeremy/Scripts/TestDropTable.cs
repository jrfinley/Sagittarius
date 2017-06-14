using UnityEngine;

public class TestDropTable : MonoBehaviour {
    private void Start() {
        DropTable dt;
        EEquipmentType et;
        dt = DropTableGenerator.GenerateDropTable(EDungeon.TUTORIAL);
        et = dt.GetItemDrop(EMonsterType.E_TEMP_ONE);
        Debug.Log(et);
        et = dt.GetItemDrop(EMonsterType.E_TEMP_TWO);
        Debug.Log(et);
        et = dt.GetItemDrop(EMonsterType.E_TEMP_THREE);
        Debug.Log(et);
        et = dt.GetItemDrop(EMonsterType.E_TEMP_BOSS);
        Debug.Log(et);
    }
}
