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

    private ConnectionData _connections;
    public ConnectionData Connections { get { return _connections; } }

    public Room parentRoom;
    public Vector3 position;
    public bool quadRoom;

    public void Start()
    {
        _connections = new ConnectionData();
        _connections.allConnections = connectionContainer.GetComponentsInChildren<Transform>().ToList();
        _connections.unusedConnections = new List<Transform>();

        foreach (Transform connection in _connections.allConnections)
            _connections.unusedConnections.Add(connection);
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
        //_connections.connections.Remove(connectionToJoin);
        //_connections.openConnections.Remove(connectionToJoin);
        //_connections.joinedConnections.Add(connectionToJoin);
    }

    public void Connect(Room otherRoom)
    {
        Transform connectionToConnect = _GetClosestTransform(otherRoom);
        _JoinConnection(connectionToConnect);
        connectionToConnect.gameObject.GetComponent<ConnectionGizmos>().color = Color.green;
    }

    private Transform _GetClosestTransform(Room otherRoom)
    {
        //float closest = 100f;
        //float dist;
        //Transform closestTransform = null;
        //foreach (Transform connection in _connections.connections)
        //{
        //    dist = Vector3.Distance(connection.position, otherRoom.position);
        //    if (dist < closest)
        //    {
        //        closestTransform = connection;
        //        closest = dist;
        //    }
        //}
        //return closestTransform;
        return null;
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

    private Vector3 _GetDirection(Vector3 direction)
    {
        Vector3 dir = Vector3.zero;

        if (direction.x > 0)
            dir.x += 0.25f;
        else if (direction.x < 0)
            dir.x -= 0.25f;
        if (direction.z > 0)
            dir.z += 0.25f;
        else if (direction.z < 0)
            dir.z -= 0.25f;

        return dir;
    }
}
