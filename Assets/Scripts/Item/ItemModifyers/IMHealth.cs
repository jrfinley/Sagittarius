using UnityEngine;
using System.Collections;

public class IMHealth : AItemModifyer {
    public IMHealth() {
        Initialize(EItemModifyer.HEALTH,
            new ItemStats(0, 1, 0, 0, 0, 0, 0, 0, 0),
            new string[] { "Sturdy", "Hardy", "Tough" },
            new string[] { "of Sturdyness", "of Swoleness", "of Ripped Abs" }
            );
    }
}
