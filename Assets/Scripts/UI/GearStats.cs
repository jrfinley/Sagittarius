using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GearStats : MonoBehaviour
{
    public Text[] statTexts; //0 - DEX, 1 - STR, 2 - INT, 3 - DEF
    
    public void SetGearBonusStats(BaseCharacter character)
    {
        statTexts[0].text = character.Dexterity.ToString();
        statTexts[1].text = character.Strength.ToString();
        statTexts[2].text = character.Intelect.ToString();
        //statTexts[3].text = character.Defense.ToString();
    }

}
