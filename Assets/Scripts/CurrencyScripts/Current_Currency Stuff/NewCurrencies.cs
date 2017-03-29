using UnityEngine;
using System.Collections;

public class NewCurrencies : MonoBehaviour
{
    int gold = 100;

    int scrap = 75;

    int food = 25;

    void Start()
    {
        GenericCurrencyClass<int> currencyClass = new GenericCurrencyClass<int>();

        int g = NewCurrencyManager.AddCurrency(gold, scrap, food);

        int s = NewCurrencyManager.AddCurrency(gold, scrap, food);

        int f = NewCurrencyManager.AddCurrency(gold, scrap, food);
    }

    void IfCurrencyRemoved()
    {
        int g = NewCurrencyManager.RemoveCurrency(gold, scrap, food);

        int s = NewCurrencyManager.RemoveCurrency(gold, scrap, food);

        int f = NewCurrencyManager.RemoveCurrency(gold, scrap, food);
    }
}