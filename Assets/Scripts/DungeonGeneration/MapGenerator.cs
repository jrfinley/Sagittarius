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
    private int minXDistance = 3;
    private int minYDistance = 3;

    private int _seed = 0;
    public int Seed { get { return _seed; } }

    private string _levelToLoad = "TestDungeon";

    private List<GameObject> _normalRooms = new List<GameObject>();
    private List<GameObject> _uniqueRooms = new List<GameObject>();
    private List<Vector3> _takenPositions = new List<Vector3>();
    private List<Vector3> _uniquePositions = new List<Vector3>();
    private List<Node> _path;
    Grid _grid;

    private GameObject _dungeonContainer = null;

    void Start()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        //1752787940
        //1857710287
        //-688597782
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
        
        _SpawnStart();
        Vector3 finalRoomPosition = _SpawnFinal();

        _grid = new Grid(width, height, 1f, finalRoomPosition);
        _path = _grid.GetPath(new Vector3(width / 2f, 0f, height / 2f), finalRoomPosition);

        _GenerateMainPath(_path);
        _GenerateUniqueBranches();

        //_dungeonContainer.transform.Rotate(new Vector3(0f, 45f, 0f));
    }
    
    private void _GenerateUniqueBranches()
    {
        while (_uniqueRooms.Count > 0)
        {
            GameObject room = _SpawnUniqueRoom();

            room.transform.position = _GetRandomRoomPosition();

            if (!room.GetComponent<Room>().normalSize)
            {
                room.transform.position += _GetQuadOffset(room.transform.position);
            }

            Vector3 start = _GetRandomNode();
            _path = _grid.GetPath(start, room.transform.position);
            _uniquePositions.Add(room.transform.position);
            _GenerateMainPath(_path);
        }
    }

    private Vector3 _GetQuadOffset(Vector3 onePosition)
    {
        float x = 0.5f;
        float y = 0.5f;

        if (Random.value > 0.5f)
            x *= -1;
        if (Random.value > 0.5f)
            y *= -1;

        Vector3 offset = new Vector3(x, 0f, y);
        Debug.Log(offset);
        return offset;
    }

    private Vector3 _GetRandomNode()
    {
        int index = Random.Range(0, _takenPositions.Count);
        return _takenPositions[index];
    }

    private void _GenerateMainPath(List<Node> path)
    {
        if (path != null)
        {
            for (int i = 0; i < path.Count; i++)
            {
                GameObject visualNode = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                visualNode.transform.position = path[i].worldPosition;
                //visualNode.transform.position = new Vector3(path[i].x, 0f, path[i].y);
                visualNode.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                visualNode.GetComponent<MeshRenderer>().material.color = Color.black;
                if (i == 0)
                    visualNode.GetComponent<MeshRenderer>().material.color = Color.cyan;

                Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);
                visualNode.transform.rotation = rotation;
                visualNode.transform.parent = _dungeonContainer.transform;
                _takenPositions.Add(visualNode.transform.position);
            }
        }
        path.Clear();
        _path.Clear();
    }

    private void _SpawnStart()
    {
        GameObject room = _SpawnUniqueRoom("Spawn");
        room.transform.position = new Vector3(width / 2f, 0f, height / 2f);
        _uniquePositions.Add(room.transform.position);
    }

    private Vector3 _SpawnFinal()
    {
        GameObject room = _SpawnUniqueRoom("Final");
        room.transform.position = _GetRandomRoomPosition();
        _uniquePositions.Add(room.transform.position);
        return room.transform.position;
    }

    private GameObject _SpawnUniqueRoom(string name = "")
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

    private Vector3 _GetRandomRoomPosition()
    {
        int x = (int)width / 2;
        int y = (int)height / 2;
        Vector3 position = Vector3.zero;

        do
        {
            x = Random.Range(1, width);
            y = Random.Range(1, height);
            position = new Vector3(x, 0f, y);
        }
        while (!NodeValidator.CanSpawnHere(_uniquePositions, position, minXDistance));

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
