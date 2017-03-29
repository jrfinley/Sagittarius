using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class NewCurrencyManager
{
    private static double maxCurrency = 100000;

    public static int AddCurrency(int gold, int scrap, int food)
    {
        return gold + scrap + food;
    }

    public static int RemoveCurrency(int gold, int scrap, int food)
    {
        return gold - scrap - food;
    }
}