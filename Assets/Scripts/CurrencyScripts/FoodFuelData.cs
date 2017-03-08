using UnityEngine;
using System.Collections;

public class FoodFuelData : MonoBehaviour
{
    private int fuelAmount;

    private int foodAmount;

    private int currFood;

    private int currFuel;

    private int maxFuel;

    private int maxFood;

    public int Food
    {
        get
        {
           return foodAmount;
        }

        set
        {
            this.currFood = value;
        }
    }

    public int Fuel
    {
        get
        {
            return fuelAmount;
        }

        set
        {
            this.currFuel = value;
        }
    }

    public void GetFoodAmount(int food)
    {
        for(int f = 0; f <= food; f++)
        {
            food += currFood;

            foodAmount /= food;
        }

        currFood = this.foodAmount;
    }

    public void AddFood(int aFood)
    {
        for (int a = 0; a <= aFood; a++)
        {
            foodAmount += Food;

            if (foodAmount <= currFood)
            {
                foodAmount++;

                Debug.Log("Need to Add food");
            }
            else
            {
                maxFood = currFood += foodAmount;
            }
        }

        return;
    }

    public void RemoveFood(int rFood)
    {
        for (int r = 0; r >= rFood; r--)
        {
            foodAmount -= Food;

            if (foodAmount <= currFood)
            {
                Debug.Log("Don't have enough food to remove yet");
            }
            else
            {
                maxFood = currFood -= foodAmount;
            }
        }

        return;
    }

    public void GetFuelAmount(int fuel)
    {
        for (int l = 0; l <= fuel; l++)
        {
            fuel += currFuel;

            fuelAmount /= fuel;
        }

        currFuel = this.fuelAmount;
    }

    public void AddFuel(int Add)
    {
        for(int a = 0; a <= Add; a++)
        {
            fuelAmount += Fuel;

            if(fuelAmount <= currFuel)
            {
                fuelAmount++;

                Debug.Log("Need fuel");
            }
            else
            {
                maxFuel = currFuel += fuelAmount;
            }
        }

        return;
    }

    public void RemoveFuel(int Remove)
    {
        for(int r = 0; r >= Remove; r--)
        {
            fuelAmount -= Fuel;

            if (fuelAmount <= currFuel)
            {
                Debug.Log("Don't have enough fuel to remove yet");
            }
            else
            {
                maxFuel = currFuel -= fuelAmount;
            }
        }

        return;
    }
}