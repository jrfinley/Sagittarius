using UnityEngine;
using System.Collections;

public class BaseCurrency : MonoBehaviour
{
    protected int currencyAmount = 100;

    protected int addCurrency = 10;

    protected int removeCurrency = 1;

    protected int totalCurrency = 100000;

    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameObject.SendMessage("Add");

            Debug.Log("Added this currency" + addCurrency + ":" + currencyAmount);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.SendMessage("Remove");

            Debug.Log("Removed this currency" + removeCurrency + ":" + currencyAmount);
        }
    }

    protected void Add()
    {
        currencyAmount += addCurrency;
    }

    protected void Remove()
    {
        if(currencyAmount - removeCurrency < 0)
        {
            Debug.Log("Not enough currency to discard or no currency availible");
        }
        else
        {
            currencyAmount -= removeCurrency;
        }
    }
}