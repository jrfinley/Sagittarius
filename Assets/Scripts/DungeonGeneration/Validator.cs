using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Validator
{
    public class RoomValidator
    {
        public static bool RoomInPath(Vector3 pointToCheck)
        {
            if (Physics.CheckSphere(pointToCheck, 3f))
            {
                Collider[] colliders = Physics.OverlapSphere(pointToCheck, 3f);
                foreach (Collider collider in colliders)
                {
                    if (collider.gameObject.name.Contains("Room"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class NodeValidator
    {
        public static bool NodePlaceable(float posX, float posY)
        {
            if (posX % 1 != 0)
                if (posY % 1 == 0)
                    return false;
            if (posY % 1 != 0)
                if (posX % 1 == 0)
                    return false;

            return true;
        }
    }
}
