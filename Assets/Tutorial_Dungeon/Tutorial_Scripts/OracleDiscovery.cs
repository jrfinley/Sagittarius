using UnityEngine;
using System.Collections;

public class OracleDiscovery : MonoBehaviour
{
    private DisplayText dT;

    private ActivatePanels panels;

    public MeshRenderer oracle;

    private Transform oraclePosition;

    private bool spawned = false;

    private Vector3 spawnPosition = new Vector3(0,0,-1);

    public float spawnTimer;

    private Animator camAnim;

    private UIManager ui;

    public Collider col;

    void Awake()
    {
        dT = FindObjectOfType<DisplayText>();

        spawnTimer = 4.0f;

        ActivatePanels p = FindObjectOfType<ActivatePanels>();

        p = panels;

        MeshRenderer r = FindObjectOfType<MeshRenderer>();

        r = oracle;

        ui = FindObjectOfType<UIManager>();
    }

    void Start ()
    {
        col.GetComponent<Collider>().enabled = false;

        ui.menuToggleButtons[0].SetActive(false);

        /*
        ui.dialogueBox.continueMarker.enabled = false;

        ui.menuToggleButtons[0].SetActive(false);

        ui.menuToggleButtons[1].SetActive(false);
        */

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

        col.GetComponent<Collider>().enabled = true;

        yield return new WaitForSeconds(2.0f);

        yield return null;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Welcome")
        {
            dT.inWelcomeZone = true;

            ui.CreateNewDialogueBox("Hello");
        }
    }

    /*
    public void IfSpawned()
    {
        if(spawned == true)
        {
            ui.dialogueBox.continueMarker.enabled = false;

            ui.CreateNewDialogueBox("Hello, Welcome to Sagittarius");

            dT.inMovementZone = true;

            StartCoroutine(dT.Movement(dT.dialogue[0]));

            Destroy(this, 3.0f);
        }
    }
    */

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