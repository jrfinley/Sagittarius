using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AItemModifyer {
    private EItemModifyer modifyer;
    private ItemStats statModifyer;
    private List<string> prefixes = new List<string>();
    private List<string> suffixes = new List<string>();

    public AItemModifyer() { }

    public string GetPrefix() {
        return prefixes[Random.Range(0, prefixes.Count)];
    }
    public string GetSuffix() {
        return suffixes[Random.Range(0, suffixes.Count)];
    }
    protected void Initialize(EItemModifyer modifyer, ItemStats statModifyer, string[] prefixes, string[] suffixes) {
        this.modifyer = modifyer;
        this.statModifyer = new ItemStats(statModifyer);
        this.prefixes.Capacity = prefixes.Length;
        this.suffixes.Capacity = suffixes.Length;
        foreach(string str in prefixes) {
            this.prefixes.Add(str);
        }
        foreach(string str in suffixes) {
            this.suffixes.Add(str);
        }
    }
}
