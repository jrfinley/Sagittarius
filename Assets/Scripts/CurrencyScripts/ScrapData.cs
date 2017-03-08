using UnityEngine;
using System.Collections;

public class ScrapData : MonoBehaviour
{
    [SerializeField]
    private GoldData goldData;

    private int duplicate = 2;

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

    public void AddToScrap(int aTS)
    {
       for(int i = 0; i < aTS; i++)
        {
            if(canScrap == true)
            {
                scrapping += goldAmount;

                goldAmount -= myGold;
            }
            else
            {
                canScrap = false;
            }
        }

        return;
    }

    public void RemoveFromScrap(int rFS)
    {
        for (int i = 0; i > rFS; i--)
        {
            if (canScrap == false)
            {
                scrapping -= goldAmount;

                goldAmount = myGold;
            }
            else
            {
                canScrap = true;
            }
        }

        return;
    }

    public void DestroyIfScrapped(GameObject toDestroy)
    {
        if(toDestroy != null && canScrap == false)
        {
            canScrap = true;

            Destroy(toDestroy);
        }
        else
        {
            scrapping -= duplicate;
        }
    }
}