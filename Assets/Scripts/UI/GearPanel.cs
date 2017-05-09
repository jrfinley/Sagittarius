using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GearPanel : MonoBehaviour
{
    public UIManager ui;
    public Sprite[] defaultIcons; //0 - HEAD, 1 - AMULET, 2 - ARMOR, 3 - LEFT HAND, 4 - RIGHT HAND
    public Image[] iconImages;    //0 - HEAD, 1 - AMULET, 2 - ARMOR, 3 - LEFT HAND, 4 - RIGHT HAND
    public Color32 emptyColor = new Color32(255, 255, 255, 119);

    public void UpdateGear()
    {
        BaseCharacter selectedHero = ui.GetSelectedCharacter();
        if(selectedHero != null)
        {
            iconImages[1].sprite = (selectedHero.amulet == null) ? defaultIcons[1] : selectedHero.amulet.GetSprite();
            iconImages[2].sprite = (selectedHero.armor == null) ? defaultIcons[2] : selectedHero.armor.GetSprite();
            iconImages[3].sprite = (selectedHero.leftHand == null) ? defaultIcons[3] : selectedHero.leftHand.GetSprite();
        }
    }

}
