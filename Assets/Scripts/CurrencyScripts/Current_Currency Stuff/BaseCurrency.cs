using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseCurrency : MonoBehaviour
{
    protected int currencyAmount = 100;

    protected int totalCurrency = 100000;

    protected float refundAmount;

    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Added this currency" + ":" + currencyAmount);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Removed this currency"  + ":" + currencyAmount);

            refundAmount -= currencyAmount;
        }
    }

    protected void Add(int addCurrency)
    {
        currencyAmount += addCurrency;
    }

    protected void Remove(int removeCurrency)
    {
        if(currencyAmount - removeCurrency < 0)
        {
            Debug.Log("Not enough currency to discard or no currency availible");
        }
        else
        {
            removeCurrency -= totalCurrency;
        }
    }
}