using UnityEngine;
using System.Collections;

public class BaseCurrency : MonoBehaviour
{
    protected int currencyAmount = 100;

    protected float add = 10;

    protected float remove = 10;

    protected int maxCurrency = 100000;
    public void AddCurrency()
    {
        add += currencyAmount;
    }

    public void RemoveCurrency()
    {
        remove -= currencyAmount;
    }

    public void LoadCurrency()
    {

    }

    public void SaveCurrency()
    {

    }
}
