using UnityEngine;
using System.Collections;

public class Currency : MonoBehaviour
{
    private static Currency instance;

    private static int currencyBalance = 99999;

    private int currencies;

    private static Currency currencyInstance
    {
        get
        {
            if(currencyInstance == null)
            {
                if(GameObject.Find("CurrencyPanel"))
                {
                    GameObject gObj = GameObject.Find("CurrencyPanel");

                    if(gObj.GetComponent<Currency>())
                    {
                        instance = gObj.GetComponent<Currency>();
                    }
                    else
                    {
                        instance = gObj.AddComponent<Currency>();
                    }
                }
                else
                {
                    GameObject gObj = new GameObject();

                    gObj.name = "CurrencyPanel";

                    instance = gObj.AddComponent<Currency>();
                }
            }

            return instance;
        }

        set
        {
            instance = value;
        }
    }

    void Start()
    {
        float gold;

        float scrap;

        float food;

        int g;

        int s;

        int f;

        if(currencyBalance != 0)
        {
            gold = currencyBalance;

            g = (int) gold;

            scrap = currencyBalance;

            s = (int) scrap;

            food = currencyBalance;

            f = (int) food;
        }
        else
        {
            g = 0;

            s = 0;

            f = 0;
        }

        Debug.Log("Here is how much currency i have" + g + "Gold" + s + "Scrap" + f + "Food");

        gameObject.name = "Currency";

        instance = this;

        AddCurrency(99999);
    }

    public static bool hasEnough(int amount)
    {
        if(instance.currencies - amount >= 0)
        {
            instance.currencies -= amount;

            return true;
        }
        else
        {
            return false;
        }
    }

    public static int GetCurrency(int currency)
    {
        return instance.currencies;
    }

    public static int AddCurrency(int amount)
    {
       instance.currencies += amount;

        return amount;
    }

    public static int RemoveCurrency(int amount)
    {
        instance.currencies -= amount;

        return amount;
    }
}