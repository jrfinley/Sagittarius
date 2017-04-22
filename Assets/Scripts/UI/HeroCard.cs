using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroCard : MonoBehaviour
{
    public Sprite icon;
    public Image iconImage;
    public Image healthBar;

    void Start()
    {
        iconImage.sprite = icon;
    }

    public void SetHealthBar(int currentHP, int maxHP)
    {
        if (maxHP < 1)
            maxHP = 1;
        healthBar.fillAmount = (float)currentHP / (float)maxHP;
    }

}
