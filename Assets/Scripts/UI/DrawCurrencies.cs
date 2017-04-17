using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrawCurrencies : MonoBehaviour
{
    public Text[] currencyTexts; //0-Gold, 1-Food, 2-Scrap


    public void SetCurrencyGold(int value)
    {
        currencyTexts[0].text = value.ToString();
    }

    public void SetCurrencyFood(int value)
    {
        currencyTexts[1].text = value.ToString();
    }

    public void SetCurrencyScrap(int value)
    {
        currencyTexts[2].text = value.ToString();
    }
}
