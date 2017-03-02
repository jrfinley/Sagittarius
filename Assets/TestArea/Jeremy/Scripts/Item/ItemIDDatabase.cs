using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemIDDatabase : MonoSingleton<ItemIDDatabase> {
    #region Variables
    [SerializeField]
    private List<int> id = new List<int>();
    #endregion

    #region Parameters
    public List<int> ID {
        get {
            return id;
        }
    }
    #endregion

    #region Methods
    public void RemoveID(int id) {
        if(ContainsID(id)) {
            this.id.Remove(id);
        } 
        else
            Debug.Log("Item with ID " + id + " does not exits in list.");
    }
    public void RemoveID(Item item) {
        if(ContainsID(item.ID)) {
            id.Remove(item.ID);
        } 
        else
            Debug.Log("Item with ID " + item.ID + " does not exits in list.");
    }
    public void AddID(int id) {
        if(ContainsID(id))
            Debug.LogError("Item with ID " + id + " already exits in list.");
        else {
            this.id.Add(id);
        }
    }
    public void AddID(Item item) {
        if(ContainsID(item.ID))
            Debug.LogError("Item with ID " + item.ID + " already exits in list.");
        else {
            id.Add(item.ID);
        }
    }
    public bool ContainsID(int id) { 
        return this.id.Contains(id);
    }
    #endregion
}
