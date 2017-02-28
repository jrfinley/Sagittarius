using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldData : MonoBehaviour
{
    private int gold;

    private int g;

    private int currentGold = 0;

    private int saveGold;

    private long maxGold = 10000000;

    private int cost;

    [SerializeField]
    private Text costText;

    [SerializeField]
    private Text goldText;

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
        currentGold = 0;

        gold = g;

        costText.text = cost + "$"; 
    }

    public void Purchase(GameObject obj)
    {
        if(gold >= 0 && gold >= cost)
        {
            gold -= cost;
        }
    }

    public IEnumerator SaveGold() 
    {
        while(true)
        {
            yield return new WaitForSeconds(saveGold);

            // save the gold somewhere.
        }
    }

    public void GetGold(int goldAmount)
    {
        if (currentGold < goldAmount)
        {
            currentGold = goldAmount / 100;

            Debug.Log("You now have this much gold");
        }
    }

    public void AddGold(int amountToAdd)
    {
        amountToAdd = 100;

        currentGold += amountToAdd;

        Debug.Log("You now have added this much gold to your Inventory");
    }

    public void RemoveGold(int amount)
    {
        amount = 100;

        if (currentGold - amount >= 0)
        {
            currentGold -= amount;

            // remove amount of gold from currentGold

            Debug.Log("You have now removed this amount of gold from your Inventory");
        }
    }

    public void SumGold(int myGold)
    {
        myGold = 10000;

        g = myGold *= currentGold / 100;

        myGold = gold - currentGold; 
    }

    public static bool Quitting = false;

    void OnDestroy()
    {
        Quitting = true;
    }
}