using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Validator
{
    public class RoomValidator
    {
        public static bool CanSpawn(Vector3 position, out GameObject hitObject)
        {
            RaycastHit hit;
            if (Physics.Raycast(position + Vector3.up, Vector3.down, out hit, 1.5f))
            {
                hitObject = hit.collider.gameObject;
                return false;
            }
            hitObject = null;
            return true;
        }

        public static bool EnoughConnections(Room room)
        {
            if (room.Connections.openConnections.Count > 0)
                return true;
            return false;
        }
    }

    public class NodeValidator
    {
        public static bool CanSpawnHere(List<Vector3> takenPositions, Vector3 position, float tolerance)
        {
            if (position.x % 2 != 0 && position.z % 2 == 0 || position.x % 2 == 0 && position.z % 2 != 0)
                return false;

            foreach (Vector3 takenPosition in takenPositions)
            {
                if (Vector3.Distance(takenPosition, position) < tolerance)
                    return false;
            }

            return true;
        }
    }
}
