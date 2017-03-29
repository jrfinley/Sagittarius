using UnityEngine;
using System.Collections;

public class Scrap : BaseCurrency
{
    protected int scrapAmount;

    private string scrap;

    void Start()
    {
        scrapAmount = currencyAmount;
    }
}
