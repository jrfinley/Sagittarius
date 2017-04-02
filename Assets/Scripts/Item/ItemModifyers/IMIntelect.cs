using UnityEngine;
using System.Collections;

public class IMIntelect : AItemModifyer {
    public IMIntelect() {
        Initialize(EItemModifyer.INTELECT,
            new ItemStats(0, 0, 0, 1, 0, 0, 0, 0, 0),
            new string[] { "Witty", "Educated" },
            new string[] { "That Is Smarter Than You", "of Intelect", "of Information" }
            );
    }
}
