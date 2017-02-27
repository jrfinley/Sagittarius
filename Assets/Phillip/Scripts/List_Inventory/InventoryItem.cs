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


}
