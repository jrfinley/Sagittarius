using UnityEngine;
using System.Collections;

/*
This classes sole purpose is entirely for just dragging the
in scene cude into the health potion prefab to allow item pickup
super basic
*/
public class AutoAddITems : MonoBehaviour
{
    public Inventory inventory;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            inventory.AddItem(other.GetComponent<Item>());
        }
    }
}
