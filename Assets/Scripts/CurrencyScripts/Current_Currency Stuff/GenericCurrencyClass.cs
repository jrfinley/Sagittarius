using UnityEngine;
using System.Collections;

public class GenericCurrencyClass <T>
{
    T currencyType;

    public void GetCurrencyType(T getCurrencyType)
    {
        currencyType = getCurrencyType;
    }
}