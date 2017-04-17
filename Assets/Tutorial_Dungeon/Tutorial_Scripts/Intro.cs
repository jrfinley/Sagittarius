using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{
    // The intro will consist of camera animations for just the intro scene

    public GameObject player;

    private Animator camAnim;

    private MovementTutorial mT;

    private Camera introCam;

    private float characterFallTime;

    private bool hasFallen = false;

    private bool followFall = false;

    void Awake()
    {
        GameObject g = FindObjectOfType<GameObject>();

        g = player.gameObject;
    }

    void Start()
    {
        camAnim = GetComponent<Animator>();

        introCam = GetComponent<Camera>();

        mT = FindObjectOfType<MovementTutorial>();

        mT = GetComponent<MovementTutorial>();

        characterFallTime = 0;

        hasFallen = false;

        followFall = false;
    }

    void EnablePlayer()
    {
        if(characterFallTime >= 3.5f)
        {
            hasFallen = true;

            followFall = false;

            StartCoroutine(SpawnPlayer());
        }
    }

    IEnumerator TransitionIn()
    {
        yield return new WaitForSeconds(3.5f);

        characterFallTime += Time.deltaTime;

        if(characterFallTime >= 3.5f)
        {
            player.SetActive(true);

            hasFallen = true;

            followFall = true;

            camAnim.SendMessage("Camera Fall", true);

            camAnim.SendMessage("Fall", true);
        }
        else if(!hasFallen && !followFall)
        {
            player.SetActive(false);

            camAnim.SendMessage("Camera Fall", false);

            camAnim.SendMessage("Fall", true);

            if(characterFallTime <= 0)
            {
                characterFallTime = 0;

                camAnim.Stop();
            }
        }

        yield return null;
    }

    IEnumerator SpawnPlayer()
    {
        player.gameObject.SetActive(true);

        mT.enabled = true;

        mT.GetMovementInput();

        yield return null;
    }
}