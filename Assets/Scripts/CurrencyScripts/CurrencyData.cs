using UnityEngine;
using System.Collections;

public class CurrencyData : MonoBehaviour
{
    private int amount;

    public int goldAmount;

    public int scrapAmount;

    public int fuelAmount;

    public int foodAmount;

    public int Currency
    {
        get
        {
            return amount;
        }

        set
        {
            goldAmount = value;

            scrapAmount = value;

            fuelAmount = value;

            foodAmount = value;
        }
    }

    public void AddGold(int gold)
    {
        gold = this.amount;
    }

    public void RemoveGold(int removeGold)
    {
        removeGold = this.amount;
    }

    public void AddScrap(int scrap)
    {
        scrap = this.amount;
    }

    public void RemoveScrap(int removeScrap)
    {
        removeScrap = this.amount;
    }

    public void AddFuel(int fuel)
    {
        fuel = this.amount;
    }

    public void RemoveFuel(int removeFuel)
    {
        removeFuel = this.amount;
    }

    public void AddFood(int food)
    {
        food = this.amount;
    }

    public void RemoveFood(int removeFood)
    {
        removeFood = this.amount;
    }
}