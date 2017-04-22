using UnityEngine;
using System.Collections;

public class CurrencyManager : MonoBehaviour{
    #region Variables
    private Currency gold;
    private Currency scrap;
    private Currency food;
    #endregion

    #region Properties
    public Currency Gold {
        get { return gold; }
        set { gold = value; }
    }
    public Currency Scrap {
        get { return scrap; }
        set { scrap = value; }
    }
    public Currency Food {
        get { return food; }
        set { food = value; }
    }
    #endregion

    #region Constuctors
    public CurrencyManager() {
        InitializeCurrencies();
    }
    public CurrencyManager(float goldStartValue = 0, float scrapStartValue = 0, float foodStartValue = 0) {
        InitializeCurrencies();
        SetCurrencyStartingValues(goldStartValue, scrapStartValue, foodStartValue);
    }
    #endregion

    #region Methods
    private void InitializeCurrencies() {
        InitializeGold();
        InitializeScrap();
        InitializeFood();
    }
    private void InitializeGold() {
        gold = new Currency(ECurrencyType.GOLD, "Gold");
    }
    private void InitializeScrap() {
        scrap = new Currency(ECurrencyType.SCRAP, "Scrap");
    }
    private void InitializeFood() {
        food = new Currency(ECurrencyType.FOOD, "Food");
    }

    public void SetCurrencyStartingValues(float goldStartValue = 0, float scrapStartValue = 0, float foodStartValue = 0) {
        Scrap.Value = scrapStartValue;
        Gold.Value = goldStartValue;
        Food.Value = foodStartValue;
    }
    #endregion
}