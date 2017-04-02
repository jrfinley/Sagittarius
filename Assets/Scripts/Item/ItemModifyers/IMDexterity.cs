using UnityEngine;
using System.Collections;

public class IMDexterity : AItemModifyer {
    public IMDexterity() {
        Initialize(EItemModifyer.DEXTERITY,
            new ItemStats(0, 0, 0, 0, 1, 0, 0, 0, 0),
            new string[] { "Nimble", "Hardy", "Dexterous" },
            new string[] { "of Dexterity", "of Dodging", "of Nimbleness" }
            );
    }
}
