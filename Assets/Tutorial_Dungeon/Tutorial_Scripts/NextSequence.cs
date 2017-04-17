using UnityEngine;
using System.Collections;

public class NextSequence : MonoBehaviour
{
    // next sequence script will control dungeon room progression for tutorial

    private bool nextSequence = false;

    void Start()
    {
        nextSequence = false;
    }

    IEnumerator LoadSequence()
    {
        int scene = 4;

        nextSequence = true;

        if (nextSequence == true)
        {
            switch (scene)
            {
                case 0:
                    scene = 0;
                    break;
                case 1:
                    scene = 1;
                    break;
                case 2:
                    scene = 2;
                    break;
                case 3: 
                    scene = 3;
                    break;
                default:
                    break;
            }
        }

        yield return scene;
    }

    void OnCollisionEnter(Collision other)
    {
        if(!nextSequence)
        {
            if (other.gameObject.tag == "Player")
            {
                LoadSequence();
            }

            else
            {
                return;
            }
        }
    }
}