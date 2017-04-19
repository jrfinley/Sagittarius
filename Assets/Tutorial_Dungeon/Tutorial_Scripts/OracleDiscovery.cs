using UnityEngine;
using System.Collections;

public class OracleDiscovery : MonoBehaviour
{
    private ActivatePanels panels;

    public MeshRenderer oracle;

    private Transform oraclePosition;

    private bool spawned = false;

    private Vector3 spawnPosition = new Vector3(0,0,-2);

    public float spawnTimer;

    private Animator camAnim;

    void Awake()
    {
        spawnTimer = 4.0f;

        ActivatePanels p = FindObjectOfType<ActivatePanels>();

        p = panels;

        MeshRenderer r = FindObjectOfType<MeshRenderer>();

        r = oracle;
    }

    void Start ()
    {
        oracle.GetComponent<MeshRenderer>().enabled = false;

        spawned = false;

        transform.position = spawnPosition.normalized;

        camAnim = GetComponentInChildren<Animator>();

        spawnTimer -= Time.deltaTime;

        StartCoroutine(SpawnOracle());
	}

    IEnumerator SpawnOracle()
    {
        yield return new WaitForSeconds(4.0f);

        if (spawnTimer <= 4)
        {
            StartCoroutine(Spawn());
        }
    }

    void Update()
    {
        StartCoroutine(SpawnOracle());
    }

    IEnumerator Spawn()
    {
        spawned = true;

        oracle.GetComponent<MeshRenderer>().enabled = true;

        yield return new WaitForSeconds(0.5f);

       // panels.welcomeZone.SetActive(true);

        yield return null;
    }

    /*
    IEnumerator OracleAnim()
    {
       // yield return new WaitForSeconds(6.0f);

        spawned = true;

        if (spawned == true)
        {
            camAnim.SetLookAtPosition(spawnPosition);

            camAnim.Play("OracleCam");

            StartCoroutine(DisplayDialogue());
        }

        yield return null;
    }
    */
}