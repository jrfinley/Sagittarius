using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Currencies : MonoBehaviour
{
    CurrencyType currencyType = CurrencyType.Gold;

    public Text goldText;

    public Text scrapText;

    public Text foodText;

    public CurrencyManager currencyManager;

    public enum CurrencyType
    {
        Gold = 0,
        Scrap = 1,
        Food = 2
    }

    private CurrencyManager cM = new CurrencyManager(40, 35, 25, 100000);

    void Start()
    {
        currencyType = CurrencyType.Gold;

        currencyManager.goldAmount = 40;

        currencyManager.scrapAmount = 35;

        currencyManager.foodAmount = 25;

        currencyManager.maxCurrency = 100000;

        goldText = goldText.GetComponent<Text>();

        scrapText = scrapText.GetComponent<Text>();

        foodText = foodText.GetComponent<Text>();

        currencyManager = GetComponent<CurrencyManager>();
    }

    public static void AddCurrency(CurrencyManager add)
    {
        
    }

    public static void RemoveCurrency(CurrencyManager remove)
    {

    }

    public static void GetCurrencyType(Currencies getCurrency)
    {

    }
}