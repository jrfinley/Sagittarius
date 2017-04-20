using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIStatistic : MonoBehaviour
{
    public Text currentLevelText;
    public Text XPText;
    public Image XPBar;

    public void SetLevelText(int currentLevel, int maxLevel)
    {
        if (maxLevel < 1)
            maxLevel = 1;
        currentLevelText.text = currentLevel.ToString() + "/" + maxLevel.ToString();
    }

    public void SetXPText(int currentXP, int maxXP)
    {
        if (maxXP < 1)
            maxXP = 1;
        XPText.text = "XP: " + currentXP.ToString() + "/" + maxXP.ToString();
        XPBar.fillAmount = (float)maxXP / (float)currentXP;
    }

}
