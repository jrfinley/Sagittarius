using UnityEngine;
using System.Collections;
using System;

public class CurrencyManager : MonoBehaviour
{
	public int gold = 100;

	public int scrap = 100; 

	public int food = 100;
	
	public int currencyBalance = 99999;

    private CurrencyType currencyType = CurrencyType.Gold;

    public enum CurrencyType 
    {
        Gold,
        Scrap,
        Food
    }

    void Start()
	{
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
			Add(gold);

            gold = this.currencyBalance;
		}
        else
        {
            Remove(gold);
        }
		
		if(currencyType == CurrencyType.Scrap)
		{
			Add(scrap);

            scrap = this.currencyBalance;
		}
        else
        {
            Remove(scrap);
        }
		
		if(currencyType == CurrencyType.Food)
		{
			Add(food);

            food = this.currencyBalance;
		}
        else
        {
            Remove(food);
        }
	}
	
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
}