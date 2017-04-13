using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    //TODO: Replace with excel parser data
    [System.Serializable] public struct Range
    {
        public Range(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
        [SerializeField] public int minimum;
        [SerializeField] public int maximum;
    }
    [SerializeField] Range distanceToFinalRoom = new Range(5, 6);


    private int _seed = 0;
    private string _levelToLoad = "TestDungeon";
    private Validator _validator = new Validator();

    private List<GameObject> _normalRooms = new List<GameObject>();
    private List<GameObject> _uniqueRooms = new List<GameObject>();
    private List<GameObject> _activeRooms = new List<GameObject>();
    private List<Transform> _mainPathConnections = new List<Transform>();

    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap(int seed = 0)
    {
        _seed = seed == 0 ? (int)System.DateTime.Now.Ticks : seed;
        _LoadRooms();
        _GenerateMap();
    }

    private void _GenerateMap()
    {
        Random.seed = _seed;
        _GenerateMainBranch();
    }
    
    private void _GenerateMainBranch()
    {
        GameObject spawnRoom = _GetUniqueRoom("Spawn");
        Room spawnRoomData = spawnRoom.GetComponent<Room>();
        List<Transform> spawnRoomConnections = spawnRoomData.Connections.AllConnections();

        int index = Random.Range(0, spawnRoomConnections.Count);
        Transform connectionToStart = spawnRoomConnections[index];
        Room room = _CreateRoom(connectionToStart);
        int distance = Random.Range(distanceToFinalRoom.minimum, distanceToFinalRoom.maximum);

        for (int i = 0; i < distance; i++)
        {
            index = Random.Range(0, room.Connections.AllConnections().Count());
            List<Transform> roomConnections = room.Connections.AllConnections();
            connectionToStart = roomConnections[index];

            room = _CreateRoom(connectionToStart);
        }
    }

    private GameObject _GetUniqueRoom(string roomName = "", Vector3 position = default(Vector3))
    {
        foreach (GameObject room in _uniqueRooms)
        {
            if (room.name.Contains(roomName))
            {
                GameObject tempRoom = Instantiate(room, position, Quaternion.identity) as GameObject;
                
                if (_validator.CanSpawn(tempRoom.GetComponent<Room>(), tempRoom, _activeRooms))
                {
                    _activeRooms.Add(tempRoom);
                    return tempRoom;
                }
                return null;
            }
        }
        Debug.LogError("Couldn't find a room with name: " + roomName);
        return null;
    }

    private Room _CreateRoom(Transform connection)
    {
        int index = Random.Range(0, _normalRooms.Count);
        GameObject tempRoom = Instantiate(_normalRooms[1], connection.position, Quaternion.identity) as GameObject;
        Room roomData = tempRoom.GetComponent<Room>();

        Vector3 localOffset = connection.position;
        Transform connectionToConnect = null;
        if (roomData.IsNormalRoomSize)
        {
            localOffset += connection.transform.forward * 0.5f;
            connectionToConnect = _GetConnection(_GetTransformDirection(connection), roomData);
        }
        else if (roomData.IsQuadRoom)
        {
            Vector2 transformToSpawn = _GetTransformDirection(connection);
            connectionToConnect = _GetConnection(transformToSpawn, roomData, true);
            localOffset += ((connectionToConnect.position - connection.position) - (connection.forward * 0.5f));
        }

        tempRoom.transform.position = localOffset;
        //TODO: Add logic to try and blend in the room
        if (!_validator.CanSpawn(roomData, tempRoom, _activeRooms))
        {
            Destroy(tempRoom);
        }
        else
        {
            _activeRooms.Add(tempRoom);
            roomData.RemoveConnection(connectionToConnect);
        }
        return roomData;
    }

    private Transform _GetConnection(Vector2 transform, Room room, bool isQuad = false)
    {
        int index = isQuad ? Random.Range(0, 2) : 0;

        if (transform.x > 0)
            return room.Connections.eastConnections[index];
        else if (transform.x < 0)
            return room.Connections.westConnections[index];
        else if (transform.y > 0)
            return room.Connections.northConnections[index];
        else if (transform.y < 0)
            return room.Connections.southConnections[index];

        Debug.LogError("Couldn't find room transfrom from direction: " + transform);
        return null;
    }

    private Vector2 _GetTransformDirection(Transform connection)
    {
        if (connection.position.x > 0)
            return new Vector2(-1, 0);
        else if (connection.position.x < 0)
            return new Vector2(1, 0);
        else if (connection.position.z > 0)
            return new Vector2(0, -1);
        else if (connection.position.z < 0)
            return new Vector2(0, 1);

        Debug.LogError("Couldn't find transform of connection");
        return Vector2.zero;
    }

    private void _LoadRooms()
    {
        _normalRooms = Resources.LoadAll("Dungeons/" + _levelToLoad + "/Rooms", typeof(GameObject)).Cast<GameObject>().ToList();
        _uniqueRooms = Resources.LoadAll("Dungeons/" + _levelToLoad + "/UniqueRooms", typeof(GameObject)).Cast<GameObject>().ToList();
    }
}
