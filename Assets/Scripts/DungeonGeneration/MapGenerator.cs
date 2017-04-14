using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

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
    //private Validator _validator = new Validator();

    private List<GameObject> _normalRooms = new List<GameObject>();
    private List<GameObject> _uniqueRooms = new List<GameObject>();
    private List<GameObject> _activeRooms = new List<GameObject>();
    private List<Transform> _openConnections = new List<Transform>();

    private List<PathNode> _pathLine = new List<PathNode>();
    private List<List<PathNode>> _allPaths = new List<List<PathNode>>();

    private Transform[] _previousConnections = new Transform[3];

    private PathGenerator _pathGenerator = null;

    void Start()
    {
        _pathGenerator = new PathGenerator(this);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        GenerateMap();
        sw.Stop();
        Debug.Log("Dungeon Generated in: " + sw.ElapsedMilliseconds + "ms");
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
        GameObject spawnRoom = _GetUniqueRoom("Spawn");
        Room spawnRoomData = spawnRoom.GetComponent<Room>();
        List<Transform> spawnRoomConnections = spawnRoomData.Connections.AllConnections();

        _AddToOpenConnections(spawnRoomConnections);
        Transform startingConnection = _GetRandomConnection(spawnRoomConnections);
        spawnRoomData.JoinConnection(startingConnection.position);

        _pathLine = _pathGenerator.GeneratePath(spawnRoom.transform.position, startingConnection.position, 15);
        _allPaths.Add(_pathLine);
        
        foreach (List<PathNode> nodeList in _allPaths)
        {
            foreach (PathNode node in nodeList)
            {
                //GameObject temp = Instantiate(_normalRooms[node.indexOfRoom], node.position, Quaternion.identity) as GameObject;
                GameObject temp = Instantiate(_normalRooms[1], node.position, Quaternion.identity) as GameObject;
                Room tempRoom = temp.GetComponent<Room>();
                tempRoom.JoinConnection(node.enterConnection);
                tempRoom.JoinConnection(node.exitConnection);
                tempRoom.Connections.AllConnections().ForEach(connection => tempRoom.BlockConnection(connection));
            }
        }
        
        foreach(GameObject tempObject in _pathGenerator.tempObjects)
        {
            Destroy(tempObject);
        }

        //Room room = _CreateRoom(_GetRandomConnection(spawnRoomConnections));
        int dungeonDistance = Random.Range(distanceToFinalRoom.minimum, distanceToFinalRoom.maximum);

        for (int i = 0; i < dungeonDistance; i++)
        {
            //if (room == null)
            //    break;

            //room = _CreateRoom(_GetRandomConnection(room.Connections.AllConnections()));
        }
    }

    private GameObject _GetUniqueRoom(string roomName = "", Vector3 position = default(Vector3))
    {
        foreach (GameObject room in _uniqueRooms)
        {
            if (room.name.Contains(roomName))
            {
                GameObject tempRoom = Instantiate(room, position, Quaternion.identity) as GameObject;

                //if (_validator.CanSpawn(tempRoom.GetComponent<Room>(), tempRoom, _activeRooms))
                //{
                //    _activeRooms.Add(tempRoom);
                //    return tempRoom;
                //}
                _activeRooms.Add(tempRoom);
                return tempRoom;
            }
        }
        Debug.LogError("Couldn't find a room with name: " + roomName);
        return null;
    }

    private Room _CreateRoom(Transform parentConnection)
    {
        int index = Random.Range(0, _normalRooms.Count);
        GameObject tempRoom = Instantiate(_normalRooms[1], parentConnection.position, Quaternion.identity) as GameObject;
        Room roomData = tempRoom.GetComponent<Room>();

        Transform connectionToConnect = roomData.GetConnectionToConnect(parentConnection);
        tempRoom.transform.position += roomData.GetOffset(parentConnection, connectionToConnect);

        //TODO: Add logic to try and blend in the room
        //if (!_Validate(roomData, tempRoom, parentConnection, connectionToConnect, out tempRoom))
        //    return null;

        foreach (Transform connection in roomData.Connections.AllConnections())
        {
            Ray ray = new Ray(connection.position, connection.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 0.2f))
            {
                //Debug.Log("i hit a room! " + hit.collider.gameObject.name);
            }
        }
            
        _activeRooms.Add(tempRoom);
        roomData.RemoveConnection(connectionToConnect);
        _RemoveFromOpenConnections(parentConnection);

        return roomData;
    }

    //private bool _Validate(Room roomData, GameObject tempRoom, Transform parentConnection, Transform connectionToConnect, out GameObject room)
    //{
    //    for (int i = 0; i < _normalRooms.Count(); i++)
    //    {
    //        if (!_validator.CanSpawn(roomData, tempRoom, _activeRooms))
    //        {
    //            Destroy(tempRoom);
    //            tempRoom = Instantiate(_normalRooms[i], parentConnection.position, Quaternion.identity) as GameObject;
    //            roomData = tempRoom.GetComponent<Room>();

    //            tempRoom.transform.position += roomData.GetOffset(parentConnection, connectionToConnect);
    //        }
    //        else
    //        {
    //            room = tempRoom;
    //            return true;
    //        }
    //    }
    //    room = null;
    //    return false;
    //}

    private Transform _GetRandomConnection(List<Transform> connections)
    {
        int index = Random.Range(0, connections.Count);
        Transform connection = connections[index];

        //if (_validator.IsConnectionValid(_previousConnections, connection))
        //{
        //    _AddPreviousConnection(connection);
        //    return connection;
        //}
        //else
        //{
        //    for (int i = 0; i < connections.Count; i++)
        //    {
        //        connection = connections[i];
        //        if (_validator.IsConnectionValid(_previousConnections, connection))
        //        {
        //            _AddPreviousConnection(connection);
        //            return connection;
        //        }
        //    }
        //}
        return connection;
        Debug.Log("No good connection");
        return null;
    }

    private void _AddPreviousConnection(Transform connection)
    {
        _previousConnections[2] = _previousConnections[1];
        _previousConnections[1] = _previousConnections[0];
        _previousConnections[0] = connection;
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

    private void _AddToOpenConnections(List<Transform> connectionList)
    {
        connectionList.ForEach(x => _openConnections.Add(x));
    }

    private void _RemoveFromOpenConnections(Transform connectionToRemove)
    {
        connectionToRemove.GetComponent<ConnectionGizmos>().draw = false;
        _openConnections.Remove(connectionToRemove);
    }

    public GameObject GetRandomRoom(out int index)
    {
        index = Random.Range(0, _normalRooms.Count);
        return _normalRooms[1];
    }

    private Vector3 _Inverse(Vector3 originalVector)
    {
        return originalVector * -1f;
    }
}
