using UnityEngine;
using JsonJunk;
using System.Data;
using System.Collections.Generic;

public static class FormulaManager {
    #region Variables
    private static Dictionary<EFormula, string> rawFormulas;
    private static string formulaJsonPath = "JsonFiles/Formulas";
    #endregion

    #region Properties
    public static Dictionary<EFormula, string> RawFormulas {
        get { return rawFormulas; }
    }
    #endregion

    #region Constructors
    static FormulaManager() {
        //initialize
        rawFormulas = new Dictionary<EFormula, string>();
        //load rawFormulas
        FormulasRow[] rows = JsonUtility.FromJson<FormulasRowWrapper>(Resources.Load<TextAsset>(formulaJsonPath).text).FormulasRow;
        foreach(FormulasRow row in rows) {
            rawFormulas.Add((EFormula)System.Enum.Parse(typeof(EFormula), row.EFormula), row.Formula);
        }
    }
    #endregion

    #region Methods
    public static double Evaluate(string expression) {
        DataTable table = new DataTable();
        table.Columns.Add("expression", typeof(string), expression);
        DataRow row = table.NewRow();
        table.Rows.Add(row);
        return double.Parse((string)row["expression"]);
    }
    public static ItemStats CalculateItemStats(ItemStats baseStats, EItemRarity rarity, int itemLevel, int seed) {
        ItemStats outputStats = new ItemStats(baseStats);
        string formula = rawFormulas[EFormula.ITEM_STATS];
        string keyBASE = "BASE";
        string keyRARITY = "RARITY";
        string keyITMLVL = "ITMLVL";
        string keyFRAND = "FRAND";

        //replace the constants
        formula = formula.Replace(keyRARITY, ((int)rarity).ToString());
        formula = formula.Replace(keyITMLVL, itemLevel.ToString());

        Random.seed = seed;
        //Debug.Log(formula.Replace(keyBASE, baseStats.Attack.ToString()).Replace(keyFRAND, Random.value.ToString()));
        //Debug.Log(Evaluate("2 + 2").ToString());
        outputStats.Attack = (float)Evaluate(formula.Replace(keyBASE, baseStats.Attack.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.Dexterity = (float)Evaluate(formula.Replace(keyBASE, baseStats.Dexterity.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.Durability = (float)Evaluate(formula.Replace(keyBASE, baseStats.Durability.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.EquipLoad = (float)Evaluate(formula.Replace(keyBASE, baseStats.EquipLoad.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.GoldValue = (float)Evaluate(formula.Replace(keyBASE, baseStats.GoldValue.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.Health = (float)Evaluate(formula.Replace(keyBASE, baseStats.Health.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.Intelect = (float)Evaluate(formula.Replace(keyBASE, baseStats.Intelect.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.ScrapValue = (float)Evaluate(formula.Replace(keyBASE, baseStats.ScrapValue.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.Strength = (float)Evaluate(formula.Replace(keyBASE, baseStats.Strength.ToString()).Replace(keyFRAND, Random.value.ToString()));
        outputStats.Weight = (float)Evaluate(formula.Replace(keyBASE, baseStats.Weight.ToString()).Replace(keyFRAND, Random.value.ToString()));

        Random.seed = (int)System.DateTime.Now.Ticks;

        return outputStats;
    }
    #endregion
}
