using UnityEngine;

public class GameManager : MonoSingleton<GameManager> {
    private CurrencyManager currencyManager;
    private DropTable dungeonDropTable;

    public CurrencyManager CurrencyManager {
        get { return currencyManager; }
        set { currencyManager = value; }
    }
    public DropTable DungeonDropTable {
        get { return dungeonDropTable; }
    }

    public void LoadDungeonDropTable(EDungeon dungeon) {
        DropTableGenerator.GenerateDropTable(dungeon);
    }
}
