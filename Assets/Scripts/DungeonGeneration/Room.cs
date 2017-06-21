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
    private enum normalRoomConnections { North, South, East, West }

    public Room parentRoom;
    public Vector3 position;
    public bool quadRoom;

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

    private void _RemoveConnection(Transform connectionToRemove)
    {
        //_connections.connections.Remove(connectionToRemove);
    }

    private void _OpenConnection(Transform connectionToOpen)
    {
        //_connections.connections.Remove(connectionToOpen);
        //_connections.openConnections.Add(connectionToOpen);
    }

    private void _JoinConnection(Transform connectionToJoin)
    {
        _connections.unusedConnections.Remove(connectionToJoin);
        _connections.joinedConnections.Add(connectionToJoin);

        //Debug.Log("Added joined connection: " + connectionToJoin.transform.localPosition);
    }

    public void Connect(Room otherRoom)
    {
        Transform connectionToConnect = _GetClosestTransform(otherRoom);
        _JoinConnection(connectionToConnect);
        connectionToConnect.gameObject.GetComponent<ConnectionGizmos>().color = Color.green;
    }

    private Transform _GetClosestTransform(Room otherRoom)
    {
        normalRoomConnections direction = _GetDirectionToRoom(otherRoom);
        //Debug.Log("Closest Transform is: " + direction);
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

    //private Vector3 _GetDirection(Room otherRoom)
    //{
    //    Vector3 secondRoom = otherRoom.gameObject.transform.position;
    //    Vector3 direction = secondRoom - this.transform.position;

    //    if (direction.x > 0 && direction.z > 0)
    //        return new Vector3(1, 0, 1);
    //    else if (direction.x < 0 && direction.z < 0)
    //        return new Vector3(-1, 0, -1);
    //    else if (direction.x < 0 && direction.z > 0)
    //        return new Vector3(-1, 0, 1);
    //    else if (direction.x > 0 && direction.z < 0)
    //        return new Vector3(1, 0, -1);

    //    Debug.Log("Couldn't get direction, returning Vector3.zero");
    //    return Vector3.zero;
    //}

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
