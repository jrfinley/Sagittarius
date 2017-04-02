using UnityEngine;
using System.Collections;

public class IMStrength : AItemModifyer {
    public IMStrength() {
        Initialize(EItemModifyer.STRENGTH,
            new ItemStats(0, 0, 1, 0, 0, 0, 0, 0, 0),
            new string[] { "Strong", "Swole", "Bulky" },
            new string[] { "of Swoleness", "of Power", "of Ripped Abs" }
            );
    }
}
