using UnityEngine;
using System.Collections;

public class GenerateLoader : MonoBehaviour
{
    private GameController gameController;
    private int count = 0;

	void Start ()
    {
        gameController = FindObjectOfType<GameController>();
        Destroy(gameObject, .22f);

        StartCoroutine(CallLoaderSpawn());
    }

    IEnumerator CallLoaderSpawn()
    {
        yield return new WaitForSeconds(.21f);
        gameController.Load();
        Destroy(gameObject, 1f);
        /*
            if (count < 1)
            {
                count++;
                Debug.Log("Created Loader" + count + " Times");
            }
            else
            {
            }
        }
        */
    }

}
