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
        _SetSeed(seed);
        _LoadRooms();
        _GenerateMap();
    }

    private void _GenerateMap()
    {
        _GenerateMainBranch();
    }
    
    private void _GenerateMainBranch()
    {
        List<Transform> spawnRoomConnections = _CreateSpawnRoomAndGetConnections();
        
        Room room = _CreateRoom(_GetRandomConnection(spawnRoomConnections));
        int dungeonDistance = Random.Range(distanceToFinalRoom.minimum, distanceToFinalRoom.maximum);

        for (int i = 0; i < dungeonDistance; i++)
        {
            room = _CreateRoom(_GetRandomConnection(room.Connections.AllConnections()));
        }
    }

    private List<Transform> _CreateSpawnRoomAndGetConnections()
    {
        GameObject spawnRoom = _GetUniqueRoom("Spawn");
        Room spawnRoomData = spawnRoom.GetComponent<Room>();
        return spawnRoomData.Connections.AllConnections();
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
        GameObject tempRoom = Instantiate(_normalRooms[index], connection.position, Quaternion.identity) as GameObject;
        Room roomData = tempRoom.GetComponent<Room>();

        Transform connectionToConnect = roomData.GetConnectionToConnect(connection);
        tempRoom.transform.position += roomData.GetOffset(connection, connectionToConnect);

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

    private Transform _GetRandomConnection(List<Transform> connections)
    {
        int index = Random.Range(0, connections.Count);
        Transform connectionToStart = connections[index];
        return connectionToStart;
    }

    private void _LoadRooms()
    {
        _normalRooms = Resources.LoadAll("Dungeons/" + _levelToLoad + "/Rooms", typeof(GameObject)).Cast<GameObject>().ToList();
        _uniqueRooms = Resources.LoadAll("Dungeons/" + _levelToLoad + "/UniqueRooms", typeof(GameObject)).Cast<GameObject>().ToList();
    }

    private void _SetSeed(int seed = 0)
    {
        _seed = seed == 0 ? (int)System.DateTime.Now.Ticks : seed;
        Random.seed = _seed;
    }
}
