using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gold : BaseCurrency
{
    protected int goldAmount = 0;

    public Text goldText;

    void Start()
    {
        goldText = GetComponent<Text>();

        goldAmount = 0;

        goldAmount = currencyAmount;
    }

    protected void AddGold(int gold)
    {
        gold = 10;

        if(gold < currencyAmount)
        {
            gold += currencyAmount;

            goldText.text = gold.ToString(); 
        }
    }

    protected void RemoveGold(int gold)
    {
        gold = 10;

        if(gold > currencyAmount)
        {
            gold -= goldAmount;

            goldText.text = currencyAmount.ToString();
        }
    }

    public void GetGold()
    {
        if(goldAmount <= 1)
        {
            goldAmount += currencyAmount;

            goldText.text = "Gold:" + totalCurrency.ToString();
        }
        else if (goldAmount >= 100)
        {
            goldAmount += currencyAmount;

            currencyAmount += totalCurrency;

            goldText.text =  totalCurrency.ToString();
        }
    }

    new void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Add(goldAmount);

            GetGold();

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