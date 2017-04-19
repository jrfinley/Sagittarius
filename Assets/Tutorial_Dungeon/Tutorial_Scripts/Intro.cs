using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{
    public MeshRenderer player;

    public Rigidbody rB;

    public GameObject fallObj;

    private Animator camAnim;

    public Animation anim;

    private MovementTutorial mT;

    private bool hasFallen = false;

    private bool fallPoint = false;

    private float timer;

    void Awake()
    {
        Rigidbody r = FindObjectOfType<Rigidbody>();

        r = GetComponent<Rigidbody>();

        GameObject f = FindObjectOfType<GameObject>();

        f = fallObj.gameObject;

        MeshRenderer m = FindObjectOfType<MeshRenderer>();

        m = player;

        timer = 6;
    }

    void Start()
    {
        rB.isKinematic = true;

        anim = FindObjectOfType<Animation>();

        camAnim = GetComponent<Animator>();

        hasFallen = false;

        fallPoint = true;

        fallObj.SetActive(true);

        timer -= Time.deltaTime;
    }

    IEnumerator EndAnimation()
    {
        anim.IsPlaying("Fall");

        if (timer <= 0)
        {
            fallPoint = false;

            anim.Stop();
        }

        yield return new WaitForSeconds(6.0f);

        fallObj.SetActive(false);

        anim.Stop();

        StartCoroutine(SpawnPlayer());
    }

    void Update()
    {
        StartCoroutine(EndAnimation());
    }

    IEnumerator SpawnPlayer()
    {
        player.GetComponent<MeshRenderer>().enabled = true;

        yield return new WaitForSeconds(3.5f);

        rB.isKinematic = true;
    }
}