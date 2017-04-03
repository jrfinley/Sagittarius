using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemModifyer {
    private ItemStats statModifyer;
    private List<string> prefixes = new List<string>();
    private List<string> suffixes = new List<string>();
    
    public ItemStats StatModifyer {
        get { return statModifyer; }
        private set { statModifyer = value; }
    }

    public ItemModifyer() { }
    public ItemModifyer(ItemStats statModifyer, string[] prefixes, string[] suffixes) {
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

    public string GetPrefix() {
        return prefixes[Random.Range(0, prefixes.Count)];
    }
    public string GetSuffix() {
        return suffixes[Random.Range(0, suffixes.Count)];
    }
}
