using UnityEngine;
using System.Collections;

public class ScrapData : MonoBehaviour
{
    [SerializeField]
    private GoldData goldData;

    private int duplicate;

    private bool canScrap = false;

    private int scrapping;

    private int myGold;

    private int goldAmount;

    public int Scrap
    {
        get
        {
            return duplicate;
        }

        set
        {
            this.scrapping = value;
        }
    }

    public void AddToScrap(int duplicate)
    {
        if (duplicate >= goldData.Currency)
        {
            duplicate.CompareTo(2);

            goldData.SumGold(myGold);

            myGold -= goldAmount;
        }
    }

    public void DestroyIfScrapped(GameObject toDestroy)
    {
        if(toDestroy != null && canScrap)
        {
            canScrap = true;

            Destroy(toDestroy);
        }

        else
        {
            scrapping += goldData.Currency;
        }
    }


}