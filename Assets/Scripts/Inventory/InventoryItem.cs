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
    public EEquipmentType itemType;

    public string id;
    public int health;

    public BaseCharacter equippedBy = null;

    public Item item;

    void Start()
    {
        if(tag == "Item")
        {
            item = ItemGenerator.GenerateRandomItem();

            displayName = item.Name;
            desc = item.FlavorText;
            strength = (int)item.Stats.Strength;
            intellect = (int)item.Stats.Intelect;
            dexterity = (int)item.Stats.Dexterity;
            gold = (int)item.Stats.GoldValue;
            scrap = (int)item.Stats.ScrapValue;
            itemType = item.Types.EquipmentType;
            health = (int)item.Stats.Health;

            id = item.ID;
        }
        else if(tag == "TutorialItem")
        {
            Debug.Log("Is predefined item");
        }
    }
}
