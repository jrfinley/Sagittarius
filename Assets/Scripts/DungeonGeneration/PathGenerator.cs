using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Validator;

public class PathGenerator
{
    private MapGenerator _generator = null;

    public List<GameObject> tempObjects = new List<GameObject>();
    private List<PathNode> _currentPath = new List<PathNode>();
    private List<Vector3> _oldDirections = new List<Vector3>();

    public PathGenerator(MapGenerator mapGenerator)
    {
        _generator = mapGenerator;
    }

    public List<PathNode> GeneratePath(Vector3 startingPoint, Vector3 startingDirection, int lengthOfPath, Vector3 endingDirection = default(Vector3), GameObject endingRoom = null)
    {
        PathNode newNode = _SetupNode(startingPoint, startingDirection);
        PathNode previousNode = newNode;
        _oldDirections.Add(startingDirection);

        bool hasFinalDestination = endingDirection != Vector3.zero ? true : false;
        int loopAmount = hasFinalDestination ? lengthOfPath - 1 : lengthOfPath - 2;

        PathNode finalNode = _GeneratePath(loopAmount, previousNode, newNode);
        
        if (hasFinalDestination)
        {
            Vector3 newStartingDirection = endingDirection * -1f;
            finalNode.exitConnection = newStartingDirection;

            if (PathValidator.ValidDirection(_oldDirections, newStartingDirection))
            {
                newNode = _SetupNode(finalNode.position, newStartingDirection);
            }
            else
            {
                newNode = _ForcePathForUniqueSpawn(finalNode, endingDirection);
            }

            newNode.enterConnection = finalNode.exitConnection;
            newNode.uniqueRoom = endingRoom;
        }

        return _currentPath;
    }

    private PathNode _ForcePathForUniqueSpawn(PathNode previousNode, Vector3 endingDirection)
    {
        Vector3 oldDirection = previousNode.enterConnection * -1;
        previousNode.exitConnection = endingDirection;

        List<Transform> connectionList = previousNode.roomToSpawn.Connections.AllConnections();
        Vector3 forcedDirection = Vector3.zero;

        foreach(Transform connection in connectionList)
        {
            if (connection.position != previousNode.enterConnection && connection.position != previousNode.exitConnection)
            {
                if (previousNode.position.x < Mathf.Abs(previousNode.position.z))
                {
                    if (previousNode.position.x < 0 && PathValidator.ValidDirection(_oldDirections, Vector3.left))
                        forcedDirection = Vector3.left;
                    else
                        forcedDirection = Vector3.right;
                }
            }
        }
        PathNode node = _SetupNode(previousNode.position, endingDirection);
        node.exitConnection = forcedDirection / 2;
        PathNode newNode = _SetupNode(node.position, forcedDirection / 2);
        newNode.exitConnection = forcedDirection / 2;
        PathNode secondNode = _SetupNode(newNode.position, forcedDirection / 2);
        secondNode.exitConnection = endingDirection * -1;
        PathNode finalNode = _SetupNode(secondNode.position, endingDirection * -1);
        return finalNode;
    }

    private PathNode _GeneratePath(int loopAmount, PathNode previousNode, PathNode newNode)
    {
        for (int i = 0; i < loopAmount; i++)
        {
            if (previousNode == null)
                break;

            Vector3 newStartingDirection = newStartingDirection = _GetNewStartingDirection(previousNode.roomToSpawn);
            newNode.exitConnection = newStartingDirection;
            newNode = _SetupNode(newNode.position, newStartingDirection);

            if (newNode == null)
                break;

            previousNode = newNode;
        }
        return newNode;
    }

    private PathNode _SetupNode(Vector3 startingPoint, Vector3 startingDirection)
    {
        Vector3 positionToSpawn = startingDirection * 2f + startingPoint;
        PathNode newNode = _GetPathNode(positionToSpawn, startingDirection);

        if (newNode == null)
            return null;

        _currentPath.Add(newNode);
        return newNode;
    }

    private Vector3 _GetNewStartingDirection(Room oldRoom, Vector3 forcedDirection = default(Vector3))
    {
        List<Transform> connections = oldRoom.Connections.AllConnections();
        Vector3 direction = Vector3.zero;

        if (forcedDirection == Vector3.zero)
        {
            int index = Random.Range(0, connections.Count);
            direction = connections[index].position;
        }
        else
        {
            direction = forcedDirection;
        }

        if (PathValidator.ValidDirection(_oldDirections, direction))
        {
            _oldDirections.Add(direction);
        }
        else
        {
            for (int i = 0; i < connections.Count; i++)
            {
                direction = connections[i].position;
                if (PathValidator.ValidDirection(_oldDirections, direction))
                {
                    _oldDirections.Add(direction);
                    break;
                }
            }
        }
        return direction;
    }

    private PathNode _GetPathNode(Vector3 position, Vector3 enterDirection)
    {
        PathNode currentNode = new PathNode();
        currentNode.position = position;
        GameObject pathNodeInWay = null;
        if (PathValidator.RoomInPath(position, out pathNodeInWay))
        {
            //TODO: try and merge rooms
            _MergeBranch(position, enterDirection);
            Debug.Log("Room on my path: " + position + " " + pathNodeInWay.name);
            return null;
        }
        else
        {
            _SpawnPathNodeTempObject(currentNode.position, currentNode);
            _SetPathRoom(currentNode, enterDirection);
            return currentNode;
        }
    }

    private void _MergeBranch(Vector3 position, Vector3 directionOfMerge)
    {
        foreach (PathNode currentNode in _currentPath)
        {
            if (position == currentNode.position)
            {
                currentNode.mergedConnections.Add(directionOfMerge * -1);
            }
        }
    }

    private void _SpawnPathNodeTempObject(Vector3 position, PathNode currentNode)
    {
        GameObject tempObject = new GameObject("pathNode");
        tempObject.transform.position = position;
        tempObject.AddComponent<SphereCollider>().radius = 0.5f;
        tempObjects.Add(tempObject);
    }

    private void _SetPathRoom(PathNode pathNode, Vector3 enterDirection)
    {
        pathNode.roomToSpawn = _generator.GetRandomRoom(out pathNode.indexOfRoom).GetComponent<Room>();
        pathNode.enterConnection = enterDirection * -1;
    }
}
