using UnityEngine;
using System.Collections;

public class BaseCurrency : MonoBehaviour
{
    protected int currencyAmount;

    protected int totalMaxCurrency = 100000;

    protected void BeginningCurrency()
    {
        currencyAmount = 0;
    }

    protected void Add(int addCurrency)
    {
        currencyAmount += addCurrency;
    }

    protected void Remove(int removeCurrency)
    {
        if(currencyAmount - removeCurrency < 0)
        {
            currencyAmount = 0;
        }
        else
        {
            currencyAmount -= removeCurrency;
        }
    }
}