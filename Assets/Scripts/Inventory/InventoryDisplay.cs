using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryDisplay : MonoBehaviour
{
    public Transform targetTransform;
    public InventoryItemDisplay itemDisplayPrefab;

    public PlayerParty playerParty;

    public List<InventoryItem> items = new List<InventoryItem>();

    private float carryCap;
    private float carryTrack = 0;

    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();
        carryCap = playerParty.maxEquipmentLoad;
    }

public void Prime(List<InventoryItem> items)
    {
        foreach(InventoryItem item in items)
        {
            if(carryTrack < carryCap)
            {
                InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(itemDisplayPrefab);
                display.transform.SetParent(targetTransform, false);
                display.Prime(item);
                carryTrack += Random.Range(5, 15);
                Debug.Log("equipLoad at: " + carryTrack);
            }
            
        }
    }
}
