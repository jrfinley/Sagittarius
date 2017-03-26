using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurrencyManager : Currencies
{
    private static CurrencyManager currencyInstance = null;

    private static Dictionary<Currencies, string> currencies = new Dictionary<Currencies, string>();

    private Currencies cS;

    public int goldAmount;

    public int scrapAmount;

    public int foodAmount;

    private int amount;

    public int maxCurrency = 100000;

    public CurrencyManager (int g, int s, int f, int mC)
    {
        this.goldAmount = g;

        this.scrapAmount = s;

        this.foodAmount = f;

        this.maxCurrency = mC; 
    }

    void Awake()
    {
        Currencies currencies = FindObjectOfType<Currencies>();

        if (maxCurrency >= 100000)
        {
            maxCurrency = this.amount;
        }

        goldText.text += goldAmount.ToString("40");

        scrapText.text += scrapAmount.ToString("35");

        foodText.text += foodAmount.ToString("25");
    }

    private static CurrencyManager CurrencyInstance
    {
        get
        {
            if (currencyInstance == null)
            {
                currencyInstance = FindObjectOfType(typeof(CurrencyManager)) as CurrencyManager;
            }

            if (currencyInstance == null)
            {
                GameObject cM = new GameObject("CurrencyManager");

                currencyInstance = cM.AddComponent(typeof(CurrencyManager)) as CurrencyManager;
            }

            return currencyInstance;
        }
    }

    struct CurrencyStruct
    {
        private int currencyAmount;

        private int Currency
        {
            get
            {
                return currencyAmount;
            }

            set
            {
                if (value < 100)
                {
                    currencyAmount = value;
                }
            }
        }
    }

    public void SumCurrencies(int currencies)
    {
        currencies += maxCurrency;
    }

    private static void PickUp()
    {

    }
}