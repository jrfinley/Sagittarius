using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemReturnManager : MonoBehaviour
{
    private Actor actor;

    public InventoryItemDisplay inventoryItemDisplayPrefab;

    public static Transform targetTransform;

    private InventoryDisplay inventoryDisplay;

    public List<InventoryItem> items = new List<InventoryItem>();

    private List<int> ids = new List<int>();
    private List<EEquipmentType> types = new List<EEquipmentType>();

    void Start ()
    {
        if(Application.loadedLevel == 0)
        {
            //must remove this later, here till fix inventory load bugg
            actor = FindObjectOfType<Actor>();
            targetTransform = FindObjectOfType<InventoryDisplay>().gameObject.transform;
            inventoryDisplay = FindObjectOfType<InventoryDisplay>();
            StartCoroutine(BeginReturningIDS());
        }
        else if(Application.loadedLevel == 1)
        {
            //send info to reforge
        }

        Actor[] actors = FindObjectsOfType<Actor>();
        for(int i = 1; i < actors.Length; i++)
        {
            Destroy(actors[i].gameObject);
        }
       
	}

    IEnumerator BeginReturningIDS()
    {
        yield return new WaitForSeconds(.3f);

        foreach(int id in actor.data.ids)
        {
            ids.Add(id);
        }
        foreach (EEquipmentType equipmentType in actor.data.itemTypes)
        {
            types.Add(equipmentType);
        }

        for(int i = 0; i < ids.Count; i++)
        {
            Item item = ItemGenerator.CreateItem(ids[i], types[i]);
            InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(inventoryItemDisplayPrefab);
            display.transform.SetParent(targetTransform, false);
            Debug.Log("Item " + i + " Name " + item.Name + " id " + item.ID + " level " + item.Level + "stats" + item.Stats);

            display.textName.text = item.Name;
            display.flavorText.text = item.FlavorText;
            display.strength.text = "STR: " + (int)item.Stats.Strength;
            display.dexterity.text = "Dex: " + (int)item.Stats.Dexterity;
            display.intellect.text = "Int: " + (int)item.Stats.Intelect;
            display.gold.text = "Gold: " + (int)item.Stats.GoldValue;
            display.scrap.text = "Scrap: " + (int)item.Stats.ScrapValue;
            display.health.text = "Health " + (int)item.Stats.Health;
            display.sprite.sprite = item.GetSprite();
        }
    }
}
