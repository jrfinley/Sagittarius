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

    void Start()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        //1752787940
        GenerateMap(1752787940);

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
        Vector3 finalRoomPosition;
        _SpawnStartAndFinalRooms(out finalRoomPosition);
        Grid grid = new Grid(width, height, 1f, finalRoomPosition);

        List<Node> path = grid.GetPath(Vector3.zero, finalRoomPosition);
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
            }
        }
    }
    
    private void _SpawnStartAndFinalRooms(out Vector3 finalTilePosition)
    {
        finalTilePosition = Vector3.zero;

        foreach (GameObject room in _uniqueRooms)
        {
            if (room.gameObject.name.Contains("Spawn"))
            {
                GameObject tempRoom = Instantiate(room);
                tempRoom.transform.position = Vector3.zero;
            }
            else if (room.gameObject.name.Contains("Final"))
            {
                GameObject tempRoom = Instantiate(room);
                tempRoom.transform.position = _GetRandomRoomPosition();
                finalTilePosition = tempRoom.transform.position;
            }
        }
    }

    private Vector3 _GetRandomRoomPosition()
    {
        int x = 0;
        int y = 0;

        while (x < minXDistance && x > -minXDistance)
            x = Random.Range(-(width / 2) + 1, width / 2);
        while (y < minYDistance && y > -minYDistance)
            y = Random.Range(-(height / 2) + 1, height / 2);

        Vector3 position = new Vector3(x, 0f, y);
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
        //Debug.Log("Dungeon seed: " + _seed);
    }
}
