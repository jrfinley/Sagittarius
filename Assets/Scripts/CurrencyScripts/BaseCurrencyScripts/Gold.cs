using UnityEngine;
using System.Collections;

public class Gold : BaseCurrency
{
    protected int goldAmount;

    protected string gold;

    void Start()
    {
        goldAmount = currencyAmount;
    }
}
