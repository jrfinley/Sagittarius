using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathNode
{
    public Vector3 position = Vector3.zero;
    public Room roomToSpawn = null;
    public int indexOfRoom = 1;
    public Vector3 enterConnection = Vector3.zero;
    public Vector3 exitConnection = Vector3.zero;
}
