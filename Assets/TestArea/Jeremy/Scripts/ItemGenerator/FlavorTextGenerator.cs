using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlavorTextGenerator {
    private Dictionary<EEquipmentType, string> flavorText = new Dictionary<EEquipmentType, string>() {
        { EEquipmentType.POTION_OF_HEALING, "Tastes like cereal with a hint of not dying a horible death." },
        { EEquipmentType.LOCK_PICK, "A key to opportunity, and someone's wallet." },

        { EEquipmentType.AXE, "Chop your foes asunder." },
        { EEquipmentType.MACE, "Big stick with pointy bits. Perfect agaisnt armor." },
        { EEquipmentType.DAGGER, "A small nimble blade with many uses." },
        { EEquipmentType.ARMING_SWORD, "Your standard slashing sword." },
        { EEquipmentType.LONG_SWORD, "A two handed blade with some reach." },
        { EEquipmentType.GREAT_SWORD, "A two handed blade that is comicly long." },
        { EEquipmentType.RAPIER, "Suprisingly heavy yet faster and more fancy." },
        { EEquipmentType.SHORT_BOW, "A standard bow. Keep your distance." },
        { EEquipmentType.LONG_BOW, "A larger bow meant to hit enemies far away, rather than acros the room." },
        { EEquipmentType.CROSSBOW, "Lots of power but needs time to reload." },

        { EEquipmentType.ARMOR, "Protect your knees." },

        { EEquipmentType.AMULET, "Feels magical." },

        { EEquipmentType.TEST_QEUST_ITEM, "I suppose this is important since I can't drop it." }
    };
    public string GenerateFlavor(EEquipmentType equipmentType) {
        return flavorText[equipmentType];
    }
}
