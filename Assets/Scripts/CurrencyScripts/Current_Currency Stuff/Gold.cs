using UnityEngine;
using System.Collections;

public class Gold : BaseCurrency
{
    protected int goldAmount;

    void Start()
    {
        goldAmount = 100;

        goldAmount += currencyAmount;
    }

    protected void AddGold(int gold)
    {
        if(gold < currencyAmount)
        {
            gold += goldAmount;
        }
    }

    protected void RemoveGold(int gold)
    {
        if(gold > currencyAmount)
        {
            gold -= goldAmount;
        }
    }

    new void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Add(goldAmount);

            goldAmount += totalCurrency;

            Debug.Log(gameObject.name + "Add" + goldAmount);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Remove(goldAmount);

            goldAmount -= totalCurrency;

            Debug.Log(gameObject.name + "Remove" + goldAmount);
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