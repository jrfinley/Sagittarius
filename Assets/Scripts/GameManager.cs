using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton<GameManager> {
    private CurrencyManager currencyManager;

    public CurrencyManager CurrencyManager {
        get { return currencyManager; }
        set { currencyManager = value; }
    }
}
