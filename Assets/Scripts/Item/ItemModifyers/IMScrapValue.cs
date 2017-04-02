using UnityEngine;
using System.Collections;

public class IMScrapValue : AItemModifyer {
    public IMScrapValue() {
        Initialize(EItemModifyer.SCRAP_VALUE,
            new ItemStats(0, 0, 0, 0, 0, 0, 0, 0, 1),
            new string[] { "sCrappy", "Junky", "Junkyark" },
            new string[] { "of Junk", "of Metal Scraps" }
            );
    }
}
