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
}