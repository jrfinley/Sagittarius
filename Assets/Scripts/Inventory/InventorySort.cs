//Sorts inventory items from a multitude of options
//Aidan Lawrence
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Sort
{
    NAME_HIGH,
    NAME_LOW,
    STR_HIGH,
    STR_LOW,
    DEX_HIGH,
    DEX_LOW,
    INT_HIGH,
    INT_LOW,
    VALUE_HIGH,
    VALUE_LOW
}

[RequireComponent(typeof(Inventory))]
public class InventorySort : MonoBehaviour
{
    public Sort sort = Sort.NAME_LOW;
    public SortButton[] sortButtons;
    public InventoryDisplay inventory;
    
    void Start()
    {
        foreach (SortButton sb in sortButtons)
            sb.ResetSortDirection();
        ToggleSortMode("NAME"); //Sort by name to start.
    }
                                                          
    public void UpdateSortedInventory() //Sorting functions have been commented out temporarily due to item script refactoring.
    {
        List<InventoryItem> items = inventory.items;
        switch (sort)
        {
            case Sort.NAME_HIGH:
                inventory.items.Sort((x, y) => x.displayName.CompareTo(y.displayName));
                break;
            case Sort.NAME_LOW:
                inventory.items.Sort((x, y) => y.displayName.CompareTo(x.displayName));
                break;
            case Sort.STR_HIGH:
                inventory.items.Sort((x, y) => x.strength.CompareTo(y.strength));
                break;
            case Sort.STR_LOW:
                inventory.items.Sort((x, y) => y.strength.CompareTo(x.strength));
                break;
            case Sort.DEX_HIGH:
                inventory.items.Sort((x, y) => x.dexterity.CompareTo(y.dexterity));
                break;
            case Sort.DEX_LOW:
                inventory.items.Sort((x, y) => y.dexterity.CompareTo(x.dexterity));
                break;
            case Sort.INT_HIGH:
                inventory.items.Sort((x, y) => x.intellect.CompareTo(y.intellect));
                break;
            case Sort.INT_LOW:
                inventory.items.Sort((x, y) => y.intellect.CompareTo(x.intellect));
                break;
            case Sort.VALUE_HIGH:
                inventory.items.Sort((x, y) => x.gold.CompareTo(y.gold));
                break;
            case Sort.VALUE_LOW:
                inventory.items.Sort((x, y) => y.gold.CompareTo(x.gold));
                break;
        }
        inventory.Prime(items);
    }

    public void ToggleSortMode(string sortName) 
    {
        foreach (SortButton sb in sortButtons)
            sb.ResetSortDirection();
        switch(sortName) //Toggle tree for multiple elements.
        {
            case "NAME":
                sort = sort == Sort.NAME_HIGH ? Sort.NAME_LOW : Sort.NAME_HIGH;
                sortButtons[0].ChangeSortDirection(sort == Sort.NAME_HIGH ? true : false);
                break;
            case "STR":
                sort = sort == Sort.STR_HIGH ? Sort.STR_LOW : Sort.STR_HIGH;
                sortButtons[1].ChangeSortDirection(sort == Sort.STR_HIGH ? true : false);
                break;
            case "DEX":
                sort = sort == Sort.DEX_HIGH ? Sort.DEX_LOW : Sort.DEX_HIGH;
                sortButtons[2].ChangeSortDirection(sort == Sort.DEX_HIGH ? true : false);
                break;
            case "INT":
                sort = sort == Sort.INT_HIGH ? Sort.INT_LOW : Sort.INT_HIGH;
                sortButtons[3].ChangeSortDirection(sort == Sort.INT_HIGH ? true : false);
                break;
            case "VALUE":
                sort = sort == Sort.VALUE_HIGH ? Sort.VALUE_LOW : Sort.VALUE_HIGH;
                sortButtons[4].ChangeSortDirection(sort == Sort.VALUE_HIGH ? true : false);
                break;
            default:
                Debug.LogError("Can not sort parameter: " + sortName);
                break;
        }
        UpdateSortedInventory(); 
    }
}
