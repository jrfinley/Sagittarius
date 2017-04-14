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

    public List<PathNode> GeneratePath(Vector3 startingPoint, Vector3 startingConnection, int lengthOfPath, Vector3 endingPoint = default(Vector3), Vector3 endingDirection = default(Vector3))
    {
        Vector3 directionToGo = startingConnection * 2f + startingPoint;
        PathNode newNode = _GetPathNode(directionToGo, startingConnection);
        PathNode previousNode = newNode;
        _currentPath.Add(newNode);
        _oldDirections.Add(startingConnection);
        for (int i = 0; i < lengthOfPath - 1; i++)
        {
            if (previousNode == null)
                break;

            Vector3 connectionPoint = _GetNewDirection(previousNode.roomToSpawn);
            directionToGo = previousNode.position + connectionPoint * 2f;
            newNode.exitConnection = connectionPoint;
            newNode = _GetPathNode(directionToGo, connectionPoint);

            _currentPath.Add(newNode);
            previousNode = newNode;
        }
        return _currentPath;
    }

    private Vector3 _GetNewDirection(Room oldRoom)
    {
        List<Transform> connections = oldRoom.Connections.AllConnections();
        int index = Random.Range(0, connections.Count);
        Vector3 direction = connections[index].position;

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

    private PathNode _GetPathNode(Vector3 position, Vector3 enterPosition)
    {
        PathNode currentNode = new PathNode();
        currentNode.position = position;

        if (PathValidator.RoomInPath(position))
        {
            //TODO: try and merge rooms
            Debug.Log("Room on my path: " + position);
            return null;
        }
        else
        {
            _SpawnPathNodeTempObject(position);
            _SetPathRoom(currentNode, enterPosition);
            return currentNode;
        }
    }

    private void _SpawnPathNodeTempObject(Vector3 position)
    {
        GameObject tempObject = new GameObject("pathNode");
        tempObject.transform.position = position;
        tempObject.AddComponent<SphereCollider>().radius = 0.5f;
        tempObjects.Add(tempObject);
    }

    private void _SetPathRoom(PathNode pathNode, Vector3 enterPosition)
    {
        pathNode.roomToSpawn = _generator.GetRandomRoom(out pathNode.indexOfRoom).GetComponent<Room>();
        pathNode.enterConnection = enterPosition * -1;
    }
}
