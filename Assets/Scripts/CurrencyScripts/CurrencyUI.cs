using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrencyUI : MonoBehaviour
{
    public Text goldText, scrapText, foodText;
    private CurrencyManager currencyManager;


    void Start ()
    {
        UpdateUI();
    }
	
    IEnumerator UpdateUI()
    {
        yield return new WaitForSeconds(1f);
        currencyManager = FindObjectOfType<CurrencyManager>();
        goldText.text = currencyManager.Gold.Value.ToString();
        scrapText.text = currencyManager.Scrap.Value.ToString();
        foodText.text = currencyManager.Food.Value.ToString();
    }
}
