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
            //prevent it from going backwards immediatly
            if (directionToCheck * -1 == directions[directions.Count - 1])
            {
                //Debug.Log("False: Went Backwards");
                return false;
            }

            //prevent it from making U turns
            if (directions.Count > 2 && directionToCheck * -1 == directions[directions.Count - 2])
            {
                //Debug.Log("False: U-Turn");
                return false;
            }

            return true;
        }

        private Vector3 _InverseVector(Vector3 vector)
        {
            return vector * -1;
        }
    }

    public class RoomValidator
    { 
        public bool CanSpawn(Room roomData, GameObject roomToSpawn, List<GameObject> rooms)
        {
            Collider roomCollider = roomToSpawn.GetComponent<Collider>();

            foreach (GameObject room in rooms)
            {
                if (roomCollider.bounds.Intersects(room.GetComponent<Collider>().bounds))
                {
                    Debug.Log("Couldn't spawn room at: " + roomToSpawn.transform.position);
                    return false;
                }
            }
            return true;
        }

        public bool IsConnectionValid(Transform[] previousConnections, Transform connectionToUse)
        {
            for (int i = 0; i < 3; i++)
            {
                if (previousConnections[i] == null)
                    return true;
            }

            Vector2 firstDirection = _GetDirection(previousConnections[2], previousConnections[1]);
            Vector2 secondDirection = _GetDirection(previousConnections[1], previousConnections[0]);
            Vector2 wantedDirection = _GetDirection(previousConnections[0], connectionToUse);

            if (secondDirection.x == -1 && wantedDirection.x == 1 || secondDirection.x == 1 && wantedDirection.x == -1)
                return false;
            if (secondDirection.y == -1 && wantedDirection.y == 1 || secondDirection.y == 1 && wantedDirection.y == -1)
                return false;

            if (firstDirection.y != 0)
            {
                if (secondDirection.x != 0)
                {
                    if (wantedDirection.y != 0)
                        return false;
                }
            }
            else if (firstDirection.x != 0)
            {
                if (secondDirection.y != 0)
                {
                    if (wantedDirection.x != 0)
                        return false;
                }
            }

            return true;
        }


        private Vector2 _GetDirection(Transform previousConnection, Transform newConnection)
        {
            if (newConnection.position.x - previousConnection.position.x > 0)
                return new Vector2(1, 0);
            else if (newConnection.position.x - previousConnection.position.x < 0)
                return new Vector2(-1, 0);
            else if (newConnection.position.z - previousConnection.position.z > 0)
                return new Vector2(0, 1);
            else if (newConnection.position.z - previousConnection.position.z < 0)
                return new Vector2(0, -1);

            return Vector2.zero;
        }
    }
}
