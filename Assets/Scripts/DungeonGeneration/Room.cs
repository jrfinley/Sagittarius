using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Room : MonoBehaviour
{
    [System.Serializable]
    public struct ConnectionData
    {
        public List<Transform> northConnections;
        public List<Transform> southConnections;
        public List<Transform> eastConnections;
        public List<Transform> westConnections;

        public List<Transform> closedConnections;

        public List<Transform> AllConnections()
        {
            return northConnections.Concat(southConnections).Concat(eastConnections).Concat(westConnections).ToList();
        }
    }

    [SerializeField] protected ConnectionData _connections;
    public ConnectionData Connections { get { return _connections; } }

    public void RemoveConnection(Transform connectionToRemove)
    {
        List<Transform> list = _GetListToRemove(connectionToRemove);
        list.Remove(connectionToRemove);
    }

    public void JoinConnection(Vector3 connectionToClose)
    {
        foreach (Transform connection in _connections.AllConnections())
        {
            if (connection.localPosition == connectionToClose)
            {
                _connections.closedConnections.Add(connection);
                connection.GetComponent<ConnectionGizmos>().color = Color.green;
                RemoveConnection(connection);
                break;
            }
        }
    }

    public void BlockConnection(Transform connectionToBlock)
    {
        foreach (Transform connection in _connections.AllConnections())
        {
            if (connection == connectionToBlock)
            {
                _connections.closedConnections.Add(connection);
                connection.GetComponent<ConnectionGizmos>().color = Color.red;
                RemoveConnection(connection);
                break;
            }
        }
    }

    public virtual Vector3 GetOffset(Transform connection, Transform connectionToConnect)
    {
        return connection.position - connectionToConnect.position;
    }

    public Transform GetConnectionToConnect(Transform connectionToConnectTo)
    {
        Vector2 transform = _GetTransformDirection(connectionToConnectTo);

        if (transform.x > 0)
            return _connections.eastConnections[Random.Range(0, _connections.eastConnections.Count())];
        else if (transform.x < 0)
            return _connections.westConnections[Random.Range(0, _connections.westConnections.Count())];
        else if (transform.y > 0)
            return _connections.northConnections[Random.Range(0, _connections.northConnections.Count())];
        else if (transform.y < 0)
            return _connections.southConnections[Random.Range(0, _connections.southConnections.Count())];

        Debug.LogError("Couldn't find room transfrom from direction: " + transform);
        return null;
    }

    protected virtual Vector2 _GetTransformDirection(Transform connectionToConnectTo)
    {
        if (connectionToConnectTo.localPosition.x > 0.25)
            return new Vector2(-1, 0);
        else if (connectionToConnectTo.localPosition.x < -0.25)
            return new Vector2(1, 0);
        else if (connectionToConnectTo.localPosition.z > 0.25)
            return new Vector2(0, -1);
        else if (connectionToConnectTo.localPosition.z < -0.25)
            return new Vector2(0, 1);

        Debug.LogError("Couldn't find transform of connection");
        return Vector2.zero;
    }

    protected virtual List<Transform> _GetListToRemove(Transform connectionToRemove)
    {
        if (connectionToRemove.localPosition.x > 0)
            return _connections.eastConnections;
        else if (connectionToRemove.localPosition.x < 0)
            return _connections.westConnections;
        else if (connectionToRemove.localPosition.z > 0)
            return _connections.northConnections;
        else if (connectionToRemove.localPosition.z < 0)
            return _connections.southConnections;

        Debug.Log("Couldn't find connection direction to remove");
        return null;
    }
}
