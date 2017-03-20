using UnityEngine;
using System.Collections;

public class Scrap : BaseCurrency
{
    protected int scrapAmount;

    void Start()
    {
        currencyAmount = 75;

        scrapAmount += currencyAmount;
    }

    protected void AddScrap(int scrap)
    {
        if(scrap < currencyAmount)
        {
            scrap += scrapAmount;
        }
    }

    protected void RemoveScrap(int scrap)
    {
        if(scrap > currencyAmount)
        {
            scrap -= scrapAmount;
        }
    }
}