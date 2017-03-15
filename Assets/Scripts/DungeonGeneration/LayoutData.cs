using UnityEngine;
using System.Collections;

public class LayoutData
{
    //this class will get replaced by excel data in the future, for now will be hard coded

    private int _roomsMinimun = 5;
    public int RoomsMinimum { get { return _roomsMinimun; } }
    private int _roomsMaximum = 10;
    public int RoomsMaximum { get { return _roomsMaximum; } }


    private int _monsterRoomsMinimum = 2;
    public int MinimumMonsterRooms { get { return _monsterRoomsMinimum; } }
    private int _maximumMonsterRooms = 4;
    public int MaximumMonsterRooms { get { return _maximumMonsterRooms; } }


    private int _hallwayObstaclesMinimum = 2;
    public int HallwayObstaclesMinimum { get { return _hallwayObstaclesMinimum; } }
    private int _hallwayObstaclesMaximum = 5;
    public int HallwayObstaclesMaximum { get { return _hallwayObstaclesMaximum; } }

    private int _treasureRoomsMinimum = 0;
    public int TreasureRoomsMinimum { get { return _treasureRoomsMinimum; } }
    private int _trasureRoomsMaximum = 2;
    public int TreasureRoomsMaximum { get { return _trasureRoomsMaximum; } }
}
