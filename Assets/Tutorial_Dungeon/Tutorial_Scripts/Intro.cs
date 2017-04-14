using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{
    // The intro will consist of camera animations for just the intro scene

    private Animator camAnim;

    private Camera introCam;

    private float startSpeed = 1;

    private float timer;

    private float characterFallTime;

    private bool hasFallen = true;

    void Start()
    {
        camAnim = GetComponent<Animator>();

        introCam = GetComponent<Camera>();

        startSpeed = 0;

        characterFallTime = 0;

        hasFallen = false;

        timer = 0;
    }

    void TransitionIn()
    {
        characterFallTime += Time.deltaTime;

        if(characterFallTime >= 3.5f)
        {
            startSpeed += 1;

            timer += 1;

            hasFallen = true;

            camAnim.SendMessage("HasFallen", true);
        }
        else 
        {
           if(timer <= 0)
            {
                characterFallTime = 0;

                camAnim.Stop();
            }
        }
    }

    void Update()
    {
        TransitionIn();
    }
}
