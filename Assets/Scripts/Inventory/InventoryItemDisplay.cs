﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryItemDisplay : MonoBehaviour
{
    public Text textName;
    public Image sprite;
    Image background;

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
        background = GetComponent<Image>();
        if (item != null)
        {
            Prime(item);
        }
    }

    public void Prime(InventoryItem item)
    {
        this.item = item;

        if (textName != null)
            textName.text = item.displayName;
        if (sprite != null)
            sprite.sprite = item.sprite;
        if (item.equippedBy != null)
            background.color = Color.gray;
        flavorText.text = item.desc;
        strength.text = "STR:  " + item.strength;
        dexterity.text = "DEX:  " + item.dexterity;
        intellect.text = "INT:  " + item.intellect;
        gold.text = "value:  " + item.gold;
        scrap.text = "scrap:  " + item.scrap;
        health.text = "Health: " + item.health;
    }

    public void SelectItem()
    {
        UIManager ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        if(ui != null)
        {
            Item _item = item.item;
            if (_item.Types.ItemType == EItemType.ACCESSORY || _item.Types.ItemType == EItemType.ARMOR)
                ui.AddRemoveEquippedItem(_item, this); 
        }
    }

    public void Equip(BaseCharacter equippingCharacter)
    {
        item.equippedBy = equippingCharacter;
        background.color = Color.gray;
    }
    
    public void Remove()
    {
        item.equippedBy = null;
        background.color = new Color32(255, 255, 255, 100);
    }

}
