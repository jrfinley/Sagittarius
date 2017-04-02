using UnityEngine;
using System.Collections;

public class IMGoldValue : AItemModifyer {
    public IMGoldValue() {
        Initialize(EItemModifyer.GOLD_VALUE,
            new ItemStats(0, 0, 0, 0, 0, 0, 0, 1, 0),
            new string[] { "Gold Plated", "Golden", "Extravagent" },
            new string[] { "of Wealth", "of the Wealthy", "of Gold" }
            );
    }
}
