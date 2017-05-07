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

    bool isEquiped = false;


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
        strength.text = "STR:  " + item.strength.ToString();
        dexterity.text = "DEX:  " + item.dexterity.ToString();
        intellect.text = "INT:  " + item.intellect.ToString();
        gold.text = "value:  " + item.gold.ToString();
        scrap.text = "scrap:  " + item.scrap.ToString();
        health.text = "Health: " + item.health.ToString();
    }

    public void SelectItem()
    {
        UIManager ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        if(ui != null)
        {
            Item _item = item.item;
            if (_item.Types.ItemType == EItemType.AMULET || _item.Types.ItemType == EItemType.ARMOR || _item.Types.ItemType == EItemType.WEAPON)
                ui.AddRemoveEquippedItem(_item, ChangeEquipStatus); 
        }
    }

    public void ChangeEquipStatus() //WIP
    {
        Image background = GetComponent<Image>();
        isEquiped = !isEquiped;
    }

}
