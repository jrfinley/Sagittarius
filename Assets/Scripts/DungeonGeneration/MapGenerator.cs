using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class MapGenerator : MonoBehaviour
{
    private int _seed = 0;
    private string _levelToLoad = "TestDungeon";

    private PathGenerator _pathGenerator = null;

    private List<GameObject> _normalRooms = new List<GameObject>();
    private List<GameObject> _uniqueRooms = new List<GameObject>();

    private Dictionary<GameObject, List<Transform>> _connectionRoomDict = new Dictionary<GameObject, List<Transform>>();

    private List<PathNode> _pathLine = new List<PathNode>();
    private List<List<PathNode>> _allPaths = new List<List<PathNode>>();

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
        GameObject finalRoom = _GetUniqueRoom("Final");
        Room finalRoomData = finalRoom.GetComponent<Room>();

        _GenerateMainBranch(finalRoom, finalRoomData);

        _GenerateBranches();
        _GenerateRooms(finalRoom, finalRoomData);
    }

    private void _GenerateMainBranch(GameObject finalRoom, Room finalRoomData)
    {
        GameObject spawnRoom = _GetUniqueRoom("Spawn");
        Room spawnRoomData = spawnRoom.GetComponent<Room>();
        List<Transform> spawnRoomConnections = spawnRoomData.Connections.AllConnections();
        List<Transform> finalRoomConnections = finalRoomData.Connections.AllConnections();

        Transform startingConnection = _GetRandomConnection(spawnRoomConnections);
        Transform finalConnection = _GetRandomConnection(finalRoomConnections);
        spawnRoomData.JoinConnection(startingConnection.position);

        _pathLine = _pathGenerator.GeneratePath(spawnRoom.transform.position, startingConnection.position, 15, finalConnection.position, finalRoom);
        _allPaths.Add(_pathLine);

        spawnRoomConnections = spawnRoomData.Connections.AllConnections();
        _connectionRoomDict.Add(spawnRoom, spawnRoomConnections);
    }

    private void _GenerateRooms(GameObject forcedRoomObject = null, Room forcedRoom = null)
    {
        foreach (List<PathNode> nodeList in _allPaths)
        {
            foreach (PathNode node in nodeList)
            {
                //GameObject temp = Instantiate(_normalRooms[node.indexOfRoom], node.position, Quaternion.identity) as GameObject;
                if (node.uniqueRoom == null)
                {
                    GameObject temp = Instantiate(_normalRooms[1], node.position, Quaternion.identity) as GameObject;
                    Room tempRoom = temp.GetComponent<Room>();

                    _UpdateConnections(tempRoom, node);

                    tempRoom.Connections.AllConnections().ForEach(connection => tempRoom.BlockConnection(connection));
                }
                else
                {
                    forcedRoomObject.transform.position = node.position;
                    forcedRoom.JoinConnection(node.enterConnection * -1);
                }
            }
        }
        foreach (GameObject tempObject in _pathGenerator.tempObjects)
        {
            Destroy(tempObject);
        }
    }

    private void _GenerateBranches()
    {
        foreach (KeyValuePair<GameObject, List<Transform>> entry in _connectionRoomDict)
        {
            GameObject startingRoom = entry.Key;
            List<Transform> connectionList = entry.Value;
            foreach (Transform connection in connectionList)
            {
                _pathLine = _pathGenerator.GeneratePath(startingRoom.transform.position, connection.position, 15);
            }
        }
    }

    private void _UpdateConnections(Room tempRoom, PathNode node)
    {
        tempRoom.JoinConnection(node.enterConnection);
        tempRoom.JoinConnection(node.exitConnection);
        node.branchConnections.ForEach(connection => tempRoom.BranchConnection(connection));
    }

    private GameObject _GetUniqueRoom(string roomName = "", Vector3 position = default(Vector3))
    {
        foreach (GameObject room in _uniqueRooms)
        {
            if (room.name.Contains(roomName))
            {
                GameObject tempRoom = Instantiate(room, position, Quaternion.identity) as GameObject;
                return tempRoom;
            }
        }
        Debug.LogError("Couldn't find a room with name: " + roomName);
        return null;
    }

    private Transform _GetRandomConnection(List<Transform> connections)
    {
        int index = Random.Range(0, connections.Count);
        Transform connection = connections[index];
        return connection;
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
        //Debug.Log("Dungeon seed: " + _seed);
    }

    public GameObject GetRandomRoom(out int index)
    {
        index = Random.Range(0, _normalRooms.Count);
        return _normalRooms[1];
    }
}
