using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Validator;
using Debug = UnityEngine.Debug;

public class MapGenerator : MonoBehaviour
{
    private int width = 10;
    private int height = 10;
    private float spawnThreshold = 2.5f;

    private int _seed = 0;
    public int Seed { get { return _seed; } }

    private string _levelToLoad = "TestDungeon";

    private List<GameObject> _normalRooms = new List<GameObject>();
    private List<GameObject> _uniqueRooms = new List<GameObject>();
    private List<Room> _unqueRoomsInDungeon = new List<Room>();
    private List<Room> _roomsInDungeon = new List<Room>();
    private List<Vector3> _uniquePositions = new List<Vector3>();

    Grid _grid;

    private GameObject _dungeonContainer = null;

    void Start()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        //-270179143
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
        _dungeonContainer = new GameObject();
        _dungeonContainer.name = "DungeonContainer";

        Room startRoom;
        Room finalRoom;

        _InjectUniqueRooms(out startRoom, out finalRoom);
        _SetUpGrid();

        _GeneratePath(startRoom, finalRoom);
        _ConnectUniqueRooms();
    }

    private void _ConnectUniqueRooms()
    {
        foreach (Room uniqueRoom in _unqueRoomsInDungeon)
        {
            _GeneratePath(_GetRandomRoom(), uniqueRoom);
        }
    }

    private Room _GetRandomRoom()
    {
        int index = 0;
        do
        {
            index = Random.Range(0, _roomsInDungeon.Count);
        } while (!RoomValidator.EnoughConnections(_roomsInDungeon[index]));

        return _roomsInDungeon[index];
    }

    private void _GeneratePath(Room startRoom, Room finalRoom)
    {
        Room secondStart;
        Room secondFinal;
        Vector3 startPosition = _GetConnectionNeighbour(startRoom, out secondStart);
        Vector3 finalPosition = _GetConnectionNeighbour(finalRoom, out secondFinal);

        _uniquePositions.Add(startPosition);
        _uniquePositions.Add(finalPosition);

        List<Node> _path = _grid.GetPath(startPosition, finalPosition, startRoom.transform.position, finalRoom.transform.position);

        _CreateRooms(_path, secondStart, secondFinal);
    }

    private Vector3 _GetConnectionNeighbour(Room room, out Room secondRoom)
    {
        Transform connection = room.GetRandomOpenConnection();

        if (connection == null)
        {
            Debug.LogError("Error, no connection available from: " + room.gameObject.name);
        }

        Vector3 position = room.transform.position + connection.forward;
        position = new Vector3(Mathf.RoundToInt(position.x), 0f, Mathf.RoundToInt(position.z));

        secondRoom = _ForceNeighbour(position, connection.localPosition, room);

        return position;
    }

    private Room _ForceNeighbour(Vector3 position, Vector3 connectionPosition, Room parent)
    {
        GameObject roomObject = Instantiate(_normalRooms[1], position, Quaternion.Euler(90f, 0f, 0f)) as GameObject;
        Room roomData = roomObject.GetComponent<Room>();
        roomData.position = position;
        roomData.parentRoom = parent;
        roomObject.transform.parent = _dungeonContainer.transform;
        _roomsInDungeon.Add(roomData);

        _ConnectRooms(roomData);

        return roomData;
    }

    private void _ConnectRooms(Room room)
    {
        Room parent = room.parentRoom;
        room.Connect(parent);
        parent.Connect(room);
    }

    private void _CreateRooms(List<Node> path, Room parentRoom, Room finalRoom)
    {
        Room previousRoom = parentRoom;
        GameObject hitObject = null;
        if (path != null)
        {
            for (int i = 0; i < path.Count; i++)
            {
                if (!RoomValidator.CanSpawn(path[i].worldPosition, out hitObject))
                {
                    if (hitObject.GetComponent<Room>() != null)
                    {
                        _MergeRooms(hitObject, previousRoom);
                    }
                    continue;
                }

                GameObject room = Instantiate(_normalRooms[1], path[i].worldPosition, Quaternion.Euler(90f, 0f, 0f)) as GameObject;
                Room roomData = room.GetComponent<Room>();
                roomData.position = path[i].worldPosition;
                roomData.parentRoom = previousRoom;
                room.transform.parent = _dungeonContainer.transform;

                _roomsInDungeon.Add(roomData);

                _ConnectRooms(roomData);

                previousRoom = roomData;
            }
        }
        else
        {
            Debug.LogError("Path is NULL");
        }
        path.Clear();
    }

    private void _MergeRooms(GameObject placedRoom, Room previousRoom)
    {
        Room hitRoom = placedRoom.GetComponent<Room>();
        hitRoom.parentRoom = previousRoom;

        hitRoom.Connect(previousRoom);
        previousRoom.Connect(hitRoom);
    }

    private void _SetUpGrid()
    {
        _grid = new Grid(width, height, 1f);
    }

    private void _InjectUniqueRooms(out Room startRoom, out Room finalRoom)
    {
        startRoom = _SpawnUnique(new Vector3(width / 2f, 0f, height / 2f), "Spawn");
        finalRoom = _SpawnUnique(_GetRandomRoomPosition(), "Final");

        while (_uniqueRooms.Count > 0)
        {
            _unqueRoomsInDungeon.Add(_SpawnUnique(_GetRandomRoomPosition()));
        }
    }

    private Room _SpawnUnique(Vector3 position, string name = "")
    {
        GameObject room = _InstantiateUniqueRoom(name);
        room.transform.position = position;

        Room roomData = room.GetComponent<Room>();
        if (roomData.quadRoom)
            room.transform.position += _GetQuadOffset();
        roomData.position = position;

        _uniquePositions.Add(room.transform.position);
        return roomData;
    }

    private GameObject _InstantiateUniqueRoom(string name = "")
    {
        GameObject tempRoom = null;
        foreach (GameObject room in _uniqueRooms)
        {
            if (room.gameObject.name.Contains(name))
            {
                tempRoom = Instantiate(room);
                tempRoom.transform.parent = _dungeonContainer.transform;
                _uniqueRooms.Remove(room);
                break;
            }
        }
        return tempRoom;
    }

    private Vector3 _GetQuadOffset()
    {
        float x = 0.5f;
        float y = 0.5f;

        if (Random.value > 0.5f)
            x *= -1;
        if (Random.value > 0.5f)
            y *= -1;

        Vector3 offset = new Vector3(x, 0f, y);
        return offset;
    }

    private Vector3 _GetRandomRoomPosition()
    {
        int x = (int)width / 2;
        int y = (int)height / 2;
        Vector3 position = Vector3.zero;

        do
        {
            x = Random.Range(2, width - 2);
            y = Random.Range(2, height - 2);
            position = new Vector3(x, 0f, y);
        }
        while (!NodeValidator.CanSpawnHere(_uniquePositions, position, spawnThreshold));

        return position;
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
        Debug.Log("Dungeon seed: " + _seed);
    }
}
