using UnityEngine;
using System.Collections;

public class IMEquipLoad : AItemModifyer {
    public IMEquipLoad() {
        Initialize(EItemModifyer.EQUIP_LOAD,
            new ItemStats(0, 0, 0, 0, -1, 0, 0, 0, 0),
            new string[] { "Light", "Hole Filled" },
            new string[] { "of Low Equip Weight" }
            );
    }
}
