using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CurrencyManager : Currencies
{
    private static CurrencyManager currencyInstance = null;

    private Currencies cS;

    public static GameObject[] currencyObj;

    public int goldAmount;

    public int scrapAmount;

    public int foodAmount;

    private int amount;

    public int maxCurrency = 100000;

    void Awake()
    {
        if (maxCurrency >= 100000)
        {
            maxCurrency = this.amount;
        }

        currencyObj = FindObjectsOfType<GameObject>();

        goldText.text += goldAmount.ToString();

        scrapText.text += scrapAmount.ToString();

        foodText.text += foodAmount.ToString();
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

    private static CurrencyManager CurrencyObjects
    {
       
    }
}