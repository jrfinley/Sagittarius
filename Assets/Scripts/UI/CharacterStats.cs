using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CharacterStats : MonoBehaviour
{
    public UIStatistic[] characterStats; //HP, DEX, STR, INT

	// Use this for initialization
	void Start ()
    {
        ResetAllStats();
	}
	
    public void DrawCharacterStatistics(BaseCharacter character)
    {
        characterStats[0].SetLevelText(character.Health, character.MaxHealth);
        characterStats[1].SetLevelText(character.Dexterity, character.Dexterity);
        characterStats[2].SetLevelText(character.Strength, character.Strength);
        characterStats[3].SetLevelText(character.Intelect, character.Intelect);
    }

    void ResetAllStats()
    {
        foreach(UIStatistic s in characterStats)
        {
            s.SetLevelText(1, 1);
            s.SetXPText(0, 100);
        }
    }
}
