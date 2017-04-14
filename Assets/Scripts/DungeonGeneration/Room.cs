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
