using UnityEngine;
using System.Collections;

public class OracleDiscovery : MonoBehaviour
{
    // oracle will spawn near the position the player has fallen, 
    // and promp the dialog box to begin tutorial

    private GameObject oracle;

    private Transform oraclePosition;

    private bool spawned = false;

    private Vector3 spawnPosition;

	void Start ()
    {
        spawned = false;

        spawnPosition = oraclePosition.position;
	}
}
