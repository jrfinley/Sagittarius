using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Old_GoldData : MonoBehaviour
{
    // Gold Variables
    private Text goldText;

    public int maxGold = 50000;

    private int currentGold = 0;

    // Item Variables
    private Text itemScrapText;

    public int maxItemScrap = 100000;

   // private int currentItemScrap;

    void Start()
    {
       // currentItemScrap = 0;

        goldText = GetComponent<Text>();
    }

    public long getGold()
    {
        return currentGold;
    }

    public void addCoins(int toAdd)
    {
        currentGold += toAdd;

        if(currentGold >= maxGold)
        {
            UpdateGoldToCarry();
        }
    }

    private void GetGoldData()
    {
        currentGold -= maxGold;

        // connect to Inventory Manager
       // GameObject.Find("nameofobject").GetComponent<Inventory>();
    }

    private void UpdateGoldToCarry()
    {
        goldText.text = currentGold.ToString();
    }

    public void removeCoins(int toRemove)
    {
        currentGold -= toRemove;

        if(currentGold <= 0)
        {
            currentGold = 0;

            UpdateGoldToCarry();
        }
    }

    private void TransferToScrap()
    {
        currentGold -= maxGold;

        // find item to transfer to scrap
        /*
        if(GameObject.Find("nameOfObject").GetComponent<ItemGenerator>())
        {
            // do something with gold and scrap
        }
        */
    }

    public void addScrap()
    {
        
    }

    private void restoreToItemCollection()
    {

    }
}