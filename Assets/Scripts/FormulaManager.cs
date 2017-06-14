using UnityEngine;
using System.Data;
using System.Collections.Generic;

public static class FormulaManager {
    public enum EFormula {
        ITEM_STATS
    };

    #region Variables
    private static Dictionary<EFormula, string> rawFormulas;
    private static DataTable data;
    #endregion

    #region Properties
    public static Dictionary<EFormula, string> RawFormulas {
        get { return rawFormulas; }
    }
    #endregion

    #region Constructors
    static FormulaManager() {
        //load rawFormulas
        data = new DataTable();
    }
    #endregion

    #region Methods
    public static ItemStats CalculateItemStats(ItemStats inputStats) {
        ItemStats outputStats = new ItemStats();
        return outputStats;
    }
    #endregion
}
