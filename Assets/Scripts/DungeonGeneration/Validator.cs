using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Validator
{
    public class RoomValidator
    {
        
    }

    public class NodeValidator
    {
        public static bool CanSpawnHere(List<Vector3> takenPositions, Vector3 position, int tolerance)
        {
            foreach (Vector3 takenPosition in takenPositions)
            {
                if (Vector3.Distance(takenPosition, position) < tolerance)
                    return false;
            }
            return true;
        }
    }
}
