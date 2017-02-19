using UnityEngine;
using System.Collections;

public enum ItemType { CONSUMABLE, EQUIPABLE, CASTABLE };

/*
super basic item class, its set up to allow me to test my 
inventory system functionality as well as debugging
while jeremy creates the perma item class
*/
public class Item_Temp : MonoBehaviour
{
    public ItemType type;

    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;

    public int maxSize;

    public void UseItem()
    {
        switch (type)
        {
            case ItemType.CONSUMABLE:
                Debug.Log("I Just used a consumable");
                break;
            case ItemType.EQUIPABLE:
                Debug.Log("I just used a consumable");
                break;
            case ItemType.CASTABLE:
                Debug.Log("I just used an ability");
                break;
        }
    }
}
