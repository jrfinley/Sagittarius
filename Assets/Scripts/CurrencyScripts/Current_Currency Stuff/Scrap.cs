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

    new void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Add(scrapAmount);

            scrapAmount += totalCurrency;

            Debug.Log(gameObject.name + "Add" + scrapAmount);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Remove(scrapAmount);

            scrapAmount -= totalCurrency;

            Debug.Log(gameObject.name + "Remove" + scrapAmount);
        }
        else
        {
            if (scrapAmount < totalCurrency)
            {
                Debug.Log(gameObject.name.ToString() + "Cannot remove any currency yet");
            }
        }
    }
}