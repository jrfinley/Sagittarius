using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform connectionContainer;
    public struct ConnectionData
    {
        public List<Transform> allConnections;
        public List<Transform> blockedConnections;
        public List<Transform> joinedConnections;
        public List<Transform> unusedConnections;
    }
    public Room roomToFind;
    private ConnectionData _connections;
    public ConnectionData Connections { get { return _connections; } }

    private Dictionary<normalRoomConnections, Transform> _directionToTransform = new Dictionary<normalRoomConnections, Transform>();
    public enum normalRoomConnections { North, South, East, West }
    public enum quadRoomConnections { WNorth, ENorth, WSouth, ESouth, NWest, SWest, NEast, SEast }

    public Room parentRoom;
    public Vector3 position;
    public bool quadRoom;

    //TODO: change this to constructor and remove testing code
    void Start()
    {
        _connections = new ConnectionData();
        _connections.allConnections = connectionContainer.GetComponentsInChildren<Transform>().ToList();
        _connections.allConnections.RemoveAt(0);
        _connections.unusedConnections = new List<Transform>();
        _connections.joinedConnections = new List<Transform>();
        _connections.blockedConnections = new List<Transform>();

        if (_connections.allConnections != null)
        {
            foreach (Transform connection in _connections.allConnections)
                _connections.unusedConnections.Add(connection);

            foreach (Transform connection in _connections.allConnections)
                _directionToTransform.Add(_GetConnectionOrientation(connection.localPosition), connection);
        }

        BlockConnection(normalRoomConnections.North);

        if (roomToFind != null)
        {
            Connect(roomToFind);
        }
    }

    public Transform GetRandomUnusedConnection()
    {
        if (_connections.unusedConnections.Count == 0)
        {
            Debug.LogError("Connection count is 0!");
            return null;
        }
        return Connections.unusedConnections[Random.Range(0, _connections.unusedConnections.Count)];
    }

    public bool Connect(Room otherRoom)
    {
        Transform connectionToConnect = _GetClosestTransform(otherRoom);

        if (_connections.blockedConnections.Contains(connectionToConnect))
        {
            Debug.Log("Connection is blocked, cannot connect rooms");
            return false;
        }

        _JoinConnection(connectionToConnect);
        connectionToConnect.gameObject.GetComponent<ConnectionGizmos>().color = Color.green;
        return true;
    }

    public void BlockConnection(normalRoomConnections direction)
    {
        Transform connection = _directionToTransform[direction];
        _connections.unusedConnections.Remove(connection);
        _connections.blockedConnections.Add(connection);
        connection.gameObject.GetComponent<ConnectionGizmos>().color = Color.red;
    }

    private void _JoinConnection(Transform connectionToJoin)
    {
        _connections.unusedConnections.Remove(connectionToJoin);
        _connections.joinedConnections.Add(connectionToJoin);
    }

    private Transform _GetClosestTransform(Room otherRoom)
    {
        normalRoomConnections direction = _GetDirectionToRoom(otherRoom);
        return _directionToTransform[direction];
    }

    private normalRoomConnections _GetDirectionToRoom(Room otherRoom)
    {
        Vector3 direction = -1 * (otherRoom.transform.position - this.transform.position);
        return _GetConnectionOrientation(direction);
    }

    private normalRoomConnections _GetConnectionOrientation(Vector3 direction)
    {
        //north - up and right
        //south - down and left
        //east - down and right
        //west - up and left
        //inverted north/south to compensate for Quad rotations

        if (direction.x > 0 && direction.z > 0)
            return normalRoomConnections.South;
        else if (direction.x < 0 && direction.z < 0)
            return normalRoomConnections.North;
        else if (direction.x < 0 && direction.z > 0)
            return normalRoomConnections.East;
        else if (direction.x > 0 && direction.z < 0)
            return normalRoomConnections.West;

        Debug.LogError("Couldn't find the connection direction, defaulting to North");
        return normalRoomConnections.North;
    }

    public void BecomeMonsterRoom()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void BecomeTreasureRoom()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    public void BecomeStatCheck()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
    }
}
