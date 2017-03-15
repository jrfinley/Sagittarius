using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Material[] _roomMaterials;
    private int _seed = 0;
    private int _offset = 15;
    private int _maxTileDistance = 100;
    private LayoutData _layoutData = new LayoutData();

    private List<GameObject> _rooms = new List<GameObject>();
    private HashSet<Vector3> _takenPositions = new HashSet<Vector3>();

    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        _seed = (int)System.DateTime.Now.Ticks;
        Debug.Log(_seed);
        _GenerateMap();
    }

    public void GenerateMap(int seed)
    {
        _seed = seed;
        _GenerateMap();
    }

    private void _GenerateMap()
    {
        Random.seed = _seed;
        GameObject start = _GenerateStartingTile();
        GameObject end =  _GenerateFinalTile();
        _GetPathToFinalRoom(start, end);
    }

    private void _GetPathToFinalRoom(GameObject start, GameObject end)
    {
        Vector3 directionToFinalTile = end.transform.position - start.transform.position;
        Vector3 oldPos = end.transform.position;

        int xNumberOfTilesToTile = Mathf.Abs((int)directionToFinalTile.x / 15);
        int zNumberOfTilesToTile = Mathf.Abs((int)directionToFinalTile.z / 15);

        int maxTiles = xNumberOfTilesToTile + zNumberOfTilesToTile;

        for (int i = 0; i < maxTiles - 1; i++)
        {
            int xDirection = (int)Random.Range(0, 2);
            if (xDirection == 0 && xNumberOfTilesToTile != 0)
            {

                GameObject tile = (directionToFinalTile.x > 0)? tile = _GenerateTile(oldPos - (Vector3.right * 15)) 
                                                              : tile = _GenerateTile(oldPos + (Vector3.right * 15));
                
                oldPos = tile.transform.position;
                xNumberOfTilesToTile--;
            }
            else if (zNumberOfTilesToTile != 0)
            {
                GameObject tile = (directionToFinalTile.z > 0) ? tile = _GenerateTile(oldPos - (Vector3.forward * 15))
                                                               : tile = _GenerateTile(oldPos + (Vector3.forward * 15));
                oldPos = tile.transform.position;
                zNumberOfTilesToTile--;
            }
            else if (xNumberOfTilesToTile != 0)
            {

                GameObject tile = (directionToFinalTile.x > 0) ? tile = _GenerateTile(oldPos - (Vector3.right * 15))
                                                               : tile = _GenerateTile(oldPos + (Vector3.right * 15));

                oldPos = tile.transform.position;
                xNumberOfTilesToTile--;
            }
        }
    }

    private GameObject _GenerateTile(Vector3 position)
    {
        GameObject tile = Instantiate(Resources.Load("DungeonPrefabs/DungeonTile") as GameObject, position, Quaternion.identity) as GameObject;
        _takenPositions.Add(tile.transform.position);
        return tile;
    }

    private GameObject _GenerateFinalTile()
    {
        int x, z;
        do
            x = _FindRandomTilePosition();
        while (x < 30 && x > -30);

        do
            z = _FindRandomTilePosition();
        while (z < 30 && z > -30);
        
        Vector3 pos = new Vector3(x, 0, z);
        GameObject tile = Instantiate(Resources.Load("DungeonPrefabs/DungeonTile") as GameObject, pos, Quaternion.identity) as GameObject;
        tile.GetComponent<MeshRenderer>().material = _roomMaterials[1];

        _takenPositions.Add(tile.transform.position);

        return tile;
    }

    private GameObject _GenerateStartingTile()
    {
        GameObject tile = Instantiate(Resources.Load("DungeonPrefabs/DungeonTile") as GameObject, Vector3.zero, Quaternion.identity) as GameObject;
        tile.GetComponent<MeshRenderer>().material = _roomMaterials[0];

        _takenPositions.Add(tile.transform.position);

        return tile;
    }

    private int _FindRandomTilePosition()
    {
        int posRand = Random.Range(-_maxTileDistance, _maxTileDistance);
        int pos = posRand + (_offset / 2);
        pos -= pos % _offset;

        return pos;
    }
}
