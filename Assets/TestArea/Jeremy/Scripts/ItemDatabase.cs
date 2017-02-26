using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoSingleton<ItemDatabase> {
    #region Variables
    //the idea is that this is a list of refrences to existing items
    private Dictionary<int, Item> listOfAllItems = new Dictionary<int, Item>();
    #endregion

    #region Parameters
    public Dictionary<int, Item> ListOfAllItems {
        get {
            return listOfAllItems;
        }
    }
    #endregion

    #region Methods
    public void RemoveItem(int id) {
        if(ContainsID(id)) {
            listOfAllItems.Remove(id);
        } 
        else
            Debug.Log("Item with ID " + id + " does not exits in dictionary.");
    }
    public void RemoveItem(Item item) {
        if(ContainsID(item.ID)) {
            listOfAllItems.Remove(item.ID);
        } 
        else
            Debug.Log("Item with ID " + item.ID + " does not exits in dictionary.");
    }
    public void AddItem(Item item) {
        if(ContainsID(item.ID))
            Debug.LogError("Item with ID " + item.ID + " already exits in dictionary.");
        else {
            listOfAllItems.Add(item.ID, item);
        }
    }
    public bool ContainsID(int id) { 
        return listOfAllItems.ContainsKey(id);
    }
    #endregion
}
