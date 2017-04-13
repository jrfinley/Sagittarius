using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Validator
{
    public bool CanSpawn(Room roomData, GameObject roomToSpawn, List<GameObject> rooms)
    {
        Collider roomCollider = roomToSpawn.GetComponent<Collider>();

        foreach(GameObject room in rooms)
        {
            if (roomCollider.bounds.Intersects(room.GetComponent<Collider>().bounds))
            {
                Debug.Log("Couldn't spawn room at: " + roomToSpawn.transform.position);
                return false;
            }
        }
        return true;
    }
}
