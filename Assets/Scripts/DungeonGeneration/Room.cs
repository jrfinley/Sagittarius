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

        public List<Transform> AllConnections()
        {
            return northConnections.Concat(southConnections).Concat(eastConnections).Concat(westConnections).ToList();
        }
    }

    [SerializeField] private ConnectionData _connections;
    public ConnectionData Connections { get { return _connections; } }

    [SerializeField] private bool _isNormalRoomSize = false;
    public bool IsNormalRoomSize { get { return _isNormalRoomSize; } }

    [SerializeField] private bool _isQuadRoom = false;
    public bool IsQuadRoom { get { return _isQuadRoom; } }

    public void RemoveConnection(Transform connectionToRemove)
    {
        List<Transform> list = _GetListToRemove(connectionToRemove);
        foreach (Transform connection in list)
        {
            if (connectionToRemove.position == connection.position)
            {
                list.Remove(connectionToRemove);
                break;
            }
        }
    }

    private List<Transform> _GetListToRemove(Transform connectionToRemove)
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
