using UnityEngine;
using System.Collections;

public class InventoryItem : MonoBehaviour
{
    public string displayName;

    [Multiline]
    public string desc;

    public Sprite sprite;

    public int strength;
    public int intellect;
    public int dexterity;
    public int gold;
    public int scrap;

    public int id;

    private Item item;

    void Start()
    {
        item = ItemGenerator.GenerateItem();

        displayName = item.Name;
        desc = item.FlavorText;
        strength = (int)item.ItemStats.Strength;
        intellect = (int)item.ItemStats.Intelect;
        dexterity = (int)item.ItemStats.Dexterity;
        gold = (int)item.ItemStats.GoldValue;
        scrap = (int)item.ItemStats.ScrapValue;

        id = item.ID;
    }
}
