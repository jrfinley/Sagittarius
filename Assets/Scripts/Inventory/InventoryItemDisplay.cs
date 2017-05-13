using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{
    public Text textName;
    public Image sprite;

    public InventoryItem item;

    public Text flavorText;

    public Text strength;
    public Text intellect;
    public Text dexterity;
    public Text gold;
    public Text scrap;
    public Text health;


    void Awake()
    {
        if (item != null) Prime(item);
    }

    public void Prime(InventoryItem item)
    {
        this.item = item;

        if (textName != null)
            textName.text = item.displayName;
        if (sprite != null)
            sprite.sprite = item.sprite;
        flavorText.text = item.desc;
        strength.text = "STR:  " + item.strength;
        dexterity.text = "DEX:  " + item.dexterity;
        intellect.text = "INT:  " + item.intellect;
        gold.text = "value:  " + item.gold;
        scrap.text = "scrap:  " + item.scrap;
        health.text = "Health: " + item.health;
    }
}
