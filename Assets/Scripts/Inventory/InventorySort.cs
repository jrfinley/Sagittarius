//Sorts inventory items from a multitude of options
//Aidan Lawrence
using UnityEngine;
using System.Collections;

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
    Inventory inventory;
    
    void Start()
    {
        inventory = GetComponent<Inventory>();
        foreach (SortButton sb in sortButtons)
            sb.ResetSortDirection();
        ToggleSortMode("NAME"); //Sort by name to start.
    }

    public void UpdateSortedInventory()
    {
        switch(sort)
        {
            case Sort.NAME_HIGH:
                inventory.items.Sort((x, y) => x.GetItem.Name.CompareTo(y.GetItem.Name));
                break;
            case Sort.NAME_LOW:
                inventory.items.Sort((x, y) => y.GetItem.Name.CompareTo(x.GetItem.Name));
                break;
            case Sort.STR_HIGH:
                inventory.items.Sort((x, y) => x.GetItem.ItemStats.Strength.CompareTo(y.GetItem.ItemStats.Strength));
                break;
            case Sort.STR_LOW:
                inventory.items.Sort((x, y) => y.GetItem.ItemStats.Strength.CompareTo(x.GetItem.ItemStats.Strength));
                break;
            case Sort.DEX_HIGH:
                inventory.items.Sort((x, y) => x.GetItem.ItemStats.Dexterity.CompareTo(y.GetItem.ItemStats.Dexterity));
                break;
            case Sort.DEX_LOW:
                inventory.items.Sort((x, y) => y.GetItem.ItemStats.Dexterity.CompareTo(x.GetItem.ItemStats.Dexterity));
                break;
            case Sort.INT_HIGH:
                inventory.items.Sort((x, y) => x.GetItem.ItemStats.Intelect.CompareTo(y.GetItem.ItemStats.Intelect));
                break;
            case Sort.INT_LOW:
                inventory.items.Sort((x, y) => y.GetItem.ItemStats.Intelect.CompareTo(x.GetItem.ItemStats.Intelect));
                break;
            case Sort.VALUE_HIGH:
                inventory.items.Sort((x, y) => x.GetItem.ItemStats.GoldValue.CompareTo(y.GetItem.ItemStats.GoldValue));
                break;
            case Sort.VALUE_LOW:
                inventory.items.Sort((x, y) => y.GetItem.ItemStats.GoldValue.CompareTo(x.GetItem.ItemStats.GoldValue));
                break;
        }
        inventory.UpdateInventory(inventory.items);
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
