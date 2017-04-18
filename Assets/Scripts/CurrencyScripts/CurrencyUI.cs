using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrencyUI : MonoBehaviour
{
    public Text goldText, scrapText, foodText;
    private CurrencyManager currencyManager;


    void Start ()
    {

        StartCoroutine(UpdateUI());
    }
	
    IEnumerator UpdateUI()
    {
        yield return new WaitForSeconds(.3f);
        currencyManager = FindObjectOfType<CurrencyManager>();
        goldText.text = currencyManager.Gold.Value.ToString();
        scrapText.text = currencyManager.Scrap.Value.ToString();
        foodText.text = currencyManager.Food.Value.ToString();
    }
}
