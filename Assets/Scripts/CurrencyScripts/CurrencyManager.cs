using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CurrencyManager : MonoBehaviour
{
	public int gold = 100;

	public int scrap = 100; 

	public int food = 100;
	
	public int currencyBalance = 99999;

    public Text goldText;

    public Text scrapText;

    public Text foodText;

    private CurrencyType currencyType = CurrencyType.Gold;

    public enum CurrencyType 
    {
        Gold,
        Scrap,
        Food
    }

    void Start()
	{
        goldText = GetComponent<Text>();

        scrapText = GetComponent<Text>();

        foodText = GetComponent<Text>();

        currencyType = CurrencyType.Gold;
        
		currencyBalance = 99999;
		
		gold = currencyBalance;
		
		scrap = currencyBalance;
		
		food = currencyBalance;
	}
	
	public void GetCurrency()
	{
		if(currencyType == CurrencyType.Gold)
		{
            // Add(gold);

            goldText.text = currencyBalance.ToString();

            gold = this.currencyBalance;
		}
        else
        {
           // Remove(gold);
        }
		
		if(currencyType == CurrencyType.Scrap)
		{
            // Add(scrap);

            scrapText.text = currencyBalance.ToString();

            scrap = this.currencyBalance;
		}
        else
        {
          //  Remove(scrap);
        }
		
		if(currencyType == CurrencyType.Food)
		{
            // Add(food);

            foodText.text = currencyBalance.ToString();

            food = this.currencyBalance;
		}
        else
        {
           // Remove(food);
        }
	}

    public void AddCurrency(int add)
    {
        if(currencyType == CurrencyType.Gold)
        {
            goldText.text += gold;

            add = this.gold /= currencyBalance;
        }

        if (currencyType == CurrencyType.Scrap)
        {
            scrapText.text += scrap;

            add = this.scrap /= currencyBalance;
        }

        if (currencyType == CurrencyType.Food)
        {
            goldText.text += food;

            add = this.food /= currencyBalance;
        }
    }

    public void RemoveCurrency(int remove)
    {
        if (currencyType == CurrencyType.Gold)
        {
            remove -= currencyBalance;

            goldText.text = remove.ToString();

            remove = this.gold / currencyBalance;
        }

        if (currencyType == CurrencyType.Scrap)
        {
            remove -= currencyBalance;

            scrapText.text = remove.ToString();

            remove = this.scrap / currencyBalance;
        }

        if (currencyType == CurrencyType.Food)
        {
            remove -= currencyBalance;

            foodText.text = remove.ToString();

            remove = this.food / currencyBalance;
        }
    }
	
    /*
	public void Add(int amount)
	{
	    amount = 10;
		
		gold = (int) 100;
		
		scrap = (int) 100;
		
		food = (int) 100;
		
		for(int i = 0; i <= amount; i++)
		{
			if(i >= gold)
			{
				if(currencyType == CurrencyType.Gold && gold >= amount)
		
				amount += currencyBalance;
			}
		
			else
			{
		    	if(gold <= amount)
				{
					return;
				}
			
			}
			
			if(i >= scrap)
			{
				if(currencyType == CurrencyType.Scrap && scrap >= amount)
		
				amount += currencyBalance;
			}
		
			else
			{
		    	if(scrap <= amount)
				{
                    return;
				}
			
			}
			
			if(i >= food)
			{
				if(currencyType == CurrencyType.Food && food >= amount)
		
				amount += currencyBalance;
			}
		
			else
			{
		    	if(food <= amount)
				{
					return;
				}
			
			}
		}
	}
	
	public void Remove(int amount)
	{
		amount = 100;

        gold = (int)100;

        scrap = (int)100;

        food = (int)100;

        for (int i = 0; i >= amount; i--)
		{
			if(i <= gold)
			{
				if(currencyType == CurrencyType.Gold && gold <= amount)
		
				amount -= currencyBalance;
			}
		
			else
			{
				if(amount <= 0)
				{
					return;
				}
			}
			
			if(i <= scrap)
			{
				if(currencyType == CurrencyType.Scrap && scrap <= amount)
		
				amount -= currencyBalance;
			}
		
			else
			{
				if(amount <= 0)
				{
					return;
				}
			}
			
			if(i <= food)
			{
				if(currencyType == CurrencyType.Food && food <= amount)
		
				amount -= currencyBalance;
			}
		
			else
			{
				if(amount <= 0)
				{
					return;
				}
			}
		}
	}
    */
}