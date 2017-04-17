using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Forge : MonoBehaviour
{
    public Text forgeLevelText;
    public Text forgeExpText;
    public Image forgeLevelBar;
    public int currentForgeExp = 1;
    public int currentForgeLevel = 1;

	void Start ()
    {
        InvokeRepeating("TestForgeExp", 0.1f, 0.5f); //Just for testing. Add 1 exp every half second.
	}

    int i = 1;
    void TestForgeExp()
    {
        i++;
        SetForgeExp(i);
    }

    public void SetForgeExp(int exp)
    {
        currentForgeExp = exp;
        currentForgeLevel = CalculateForgeLevel(currentForgeExp);
        forgeExpText.text = currentForgeExp.ToString() + "/" + CalculateNextForgeLevel(currentForgeLevel).ToString() + "EXP until next forge level";
        forgeLevelText.text = "Forge Level " + currentForgeLevel.ToString();
    }

    int CalculateNextForgeLevel(int level)
    {
        return (level * level + level + 3) * 4;
    }

    int CalculateForgeLevel(int exp)
    {
        return Mathf.RoundToInt(((exp / 4) - currentForgeLevel - 3) / currentForgeLevel);
    }

}
