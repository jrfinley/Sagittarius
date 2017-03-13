using UnityEngine;
using System.Collections;

public class Gold : BaseCurrency
{
    new void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Add();

            currencyAmount += totalCurrency;

            Debug.Log(gameObject.name + "Add" + addCurrency);
        }
        else
        {
            currencyAmount += totalCurrency;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Remove();

            currencyAmount -= totalCurrency;

            Debug.Log(gameObject.name + "Remove" + removeCurrency);
        }
        else
        {
            if(currencyAmount < totalCurrency)
            {
                Debug.Log(gameObject.name.ToString() + "Cannot remove any currency yet");
            }
        }
    }
}