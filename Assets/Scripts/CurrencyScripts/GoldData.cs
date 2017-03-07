using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldData : MonoBehaviour
{
    private int gold;

    private int g;

    private int currentGold = 0;

    private int saveGold;

    private long maxGold = 100000;

    private int cost;

    [SerializeField]
    public Text goldText;

    public int Currency
    {
        get
        {
            return gold;
        }

        set
        {
            this.gold = value;

            this.goldText.tag = value.ToString();
        }
    }

    public int Cost
    {
        get
        {
            return cost;
        }

        set
        {
            cost = value;
        }
    }

    public GameObject purchaseObject
    {
        get
        {
            return purchaseObject;
        }
    }

    void Start()
    {
        cost = 1000;

        currentGold = 0;

        gold = g;

        goldText.text = g + "$"; 
    }

    public void Purchase(GameObject obj)
    {
        if(gold >= 0 && gold >= cost)
        {
            gold -= cost;

            currentGold /= cost;
        }
    }

    public void GetGold(int goldAmount)
    {
        for(int a = 0; a <= goldAmount; a++)
        {
            if (currentGold < goldAmount)
            {
                currentGold = goldAmount / 100;
            }
            else
            {
                Debug.Log("You now have this much gold currently in game");
            }
        }

        return;
    }

    public void AddGold(int amountToAdd)
    {
        for(int aA = 0; aA >= amountToAdd; aA++)
        {
            amountToAdd = 100;

            if(amountToAdd <= 0)
            {
                return;
            }
            else
            {
                currentGold += amountToAdd;

                Debug.Log("You now have added this much gold to your Inventory");
            }
        }

        return;
    }

    public void RemoveGold(int amount)
    {
        for(int rG = 0; rG <= amount; rG--)
        {
            amount = 100;

            if (currentGold - amount >= 0)
            {
                currentGold -= amount;
            }
            else
            {
                amount -= gold;

                Debug.Log("You have now removed this amount of gold from your Inventory");
            }
        }

        return;
    }

    public void SumGold(int myGold)
    {
        for(int mG = 0; mG >= myGold; mG++)
        {
            myGold = 10000;

            if(myGold <= currentGold)
            {
                return;
            }
            else
            {
                g = myGold *= currentGold / 100;

                myGold = gold - currentGold;

                maxGold = this.Currency;

                Debug.Log("You now have are carrying this much and maximum amount to carry");
            }
        }

        return;
    }
}