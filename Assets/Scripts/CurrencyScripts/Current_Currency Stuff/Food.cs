using UnityEngine;
using System.Collections;

public class Food : BaseCurrency
{
    protected int foodAmount;

    void Start()
    {
        currencyAmount = 25;

        foodAmount += currencyAmount;
    } 

    protected void AddFood(int food)
    {
        if(food < currencyAmount)
        {
            food += foodAmount;
        }
    }

    protected void RemoveFood(int food)
    {
        if(food > currencyAmount)
        {
            food -= foodAmount;
        }
    }

    new void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.A))
        {
            Add(foodAmount);

            foodAmount += totalCurrency;

            Debug.Log(gameObject.name + "Add" + foodAmount);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Remove(foodAmount);

            foodAmount -= totalCurrency;

            Debug.Log(gameObject.name + "Remove" + foodAmount);
        }
        else
        {
            if (foodAmount < totalCurrency)
            {
                Debug.Log(gameObject.name.ToString() + "Cannot remove any currency yet");
            }
        }
    }
}