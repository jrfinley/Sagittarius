using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Validator
{
    public class PathValidator
    {
        public static bool RoomInPath(Vector3 pointToCheck)
        {
            if (Physics.CheckSphere(pointToCheck, 0.1f))
                return true;

            return false;
        }

        public static bool ValidDirection(List<Vector3> directions, Vector3 directionToCheck)
        {
            directionToCheck *= -1;

            //prevent it from going backwards immediatly
            if (directionToCheck == directions[directions.Count - 1])
            {
                //Debug.Log("False: Went Backwards");
                return false;
            }

            //prevent it from making U turns
            if (directions.Count > 2 && directionToCheck == directions[directions.Count - 2])
            {
                //Debug.Log("False: U-Turn");
                return false;
            }

            return true;
        }
    }

    public class RoomValidator
    { 
        
    }
}
