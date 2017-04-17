using UnityEngine;
using System.Collections;

public class OracleDiscovery : MonoBehaviour
{
    private GameObject oracle;

    private Transform oraclePosition;

    private bool spawned = false;

    private Vector3 spawnPosition = new Vector3(0,0, 13.52f);

    public float spawnTimer = 0;

    private Animator camAnim;

    private UIManager uiManager;

    public GameObject dialogueBox;

    public GameObject UIManager;

    private string myText;

    void Awake()
    {
        uiManager = GetComponent<UIManager>();

        UIManager.SetActive(false);
    }

    void Start ()
    {
        oracle = this.gameObject;

        this.gameObject.SetActive(false);

        spawnTimer = 0.0f;

        spawned = false;

        spawnPosition = transform.position;

        camAnim = GetComponentInChildren<Animator>();

        EnableTimer();
	}

    void Update()
    {
        spawnTimer *= Time.deltaTime;

        spawnTimer++;
    }

    void EnableTimer()
    {
        spawnTimer += Time.time;

        if(spawnTimer >= 6.0f)
        {
            spawnTimer = 6.0f;

            StartCoroutine(Spawn());

            // oracle.SetActive(true);

            StartCoroutine(Oracle());
        }
    }

    IEnumerator DisplayDialogue()
    {
        UIManager ui = FindObjectOfType<UIManager>();

        ui = GetComponent<UIManager>();

        ui.gameObject.SetActive(true);     

        if(uiManager.dialogueBox.enabled)
        {
            uiManager.dialogueBox.textBox.text = myText;

            myText = "Welcome to Sagittarius" + "," + "I will be your guide through this tutorial";

            uiManager.CreateNewDialogueBox(myText);
        }

        yield return null;
    }

    IEnumerator Spawn()
    {
        EnableTimer();

        spawnTimer += Time.deltaTime;

        if(spawnTimer >= 6.0f)
        {
            spawned = true;

            oracle.SetActive(true);

            Instantiate(oracle, spawnPosition, Quaternion.identity);
        }

        yield return null;
    }

    IEnumerator Oracle()
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
}