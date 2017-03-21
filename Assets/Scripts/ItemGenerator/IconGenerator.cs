using UnityEngine;
using System.Collections;

public class IconGenerator {
    private string itemPathRoot = "ItemIcons/";
    public string GenerateIcon(EEquipmentType equipmentType) {
        return (itemPathRoot + "Default_Icon");
    }
}
