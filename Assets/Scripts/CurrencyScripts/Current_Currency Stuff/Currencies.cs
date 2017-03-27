using UnityEngine;
using UnityEngine.UI;

public class Currencies : MonoBehaviour
{
    CurrencyType currencyType = CurrencyType.Gold;

    public Text goldText;

    public Text scrapText;

    public Text foodText;

    public CurrencyManager currencyManager;

    public enum CurrencyType
    {
        Gold,
        Scrap,
        Food
    }

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
        add.goldAmount += add.currencyManager.maxCurrency;

        add.scrapAmount += add.currencyManager.maxCurrency;

        add.foodAmount += add.currencyManager.maxCurrency;
    }

    public static void RemoveCurrency(CurrencyManager remove)
    {
        remove.goldAmount -= remove.currencyManager.maxCurrency;

        remove.scrapAmount -= remove.currencyManager.maxCurrency;

        remove.foodAmount -= remove.currencyManager.maxCurrency;
    }

    public static void GetCurrencyType(Currencies getCurrency)
    {
        if(getCurrency.currencyType == CurrencyType.Gold)
        {
            getCurrency.currencyType += getCurrency.currencyManager.goldAmount;
        }

        if (getCurrency.currencyType == CurrencyType.Scrap)
        {
            getCurrency.currencyType += getCurrency.currencyManager.scrapAmount;
        }

        if (getCurrency.currencyType == CurrencyType.Food)
        {
            getCurrency.currencyType += getCurrency.currencyManager.foodAmount;
        }
    }
}