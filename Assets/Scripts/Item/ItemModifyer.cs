﻿using UnityEngine;
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

    public string GetPrefix(out int i) {
        int r = Random.Range(0, prefixes.Count);
        i = r;
        return prefixes[r];
    }
    public string GetSuffix(out int i) {
        int r = Random.Range(0, suffixes.Count);
        i = r;
        return suffixes[r];
    }
    public string GetPrefix(int i) {
        return prefixes[i];
    }
    public string GetSuffix(int i) {
        return suffixes[i];
    }
}
