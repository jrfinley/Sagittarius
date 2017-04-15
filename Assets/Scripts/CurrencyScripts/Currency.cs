using UnityEngine;
using System.Collections;

public class Currency{
    #region Variables
    private ECurrencyType type;
    private string name;
    private float value;
    private float max;
    #endregion

    #region Properties
    public ECurrencyType Type {
        get { return type; }
        private set { type = value; }
    }
    public string Name {
        get { return name; }
        private set { name = value; }
    }
    public float Value {
        get { return value; }
        set {
            if((this.value + value) < 0)
                this.value = 0;
            else if((this.value + value) > max)
                this.value = max;
            else
                this.value = value;
        }
    }
    public float FloorValue {
        get { return Mathf.Floor(value); }
    }
    public int FloorIntValue {
        get { return Mathf.FloorToInt(value); }
    }
    public float Max {
        get { return max; }
        private set { max = value; }
    }
    #endregion

    #region Constructors
    public Currency(ECurrencyType type, string name, float value = 0, float max = float.MaxValue) {
        this.type = type;
        this.name = name;
        this.value = value;
        this.max = max;
    }
    #endregion
}
