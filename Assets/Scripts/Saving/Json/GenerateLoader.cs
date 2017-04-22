using UnityEngine;
using System.Collections;

public class GenerateLoader : MonoBehaviour
{
    private GameController gameController;
    private int count = 0;

	void Start ()
    {
        gameController = FindObjectOfType<GameController>();

        StartCoroutine(CallLoaderSpawn());
    }

    IEnumerator CallLoaderSpawn()
    {
        yield return new WaitForSeconds(.21f);
        if(count < 1)
        {
            gameController.Load();
            Debug.Log("Created Loader" + count + " Times");
            count++;
            Actor loadedActor = FindObjectOfType<Actor>();
            if(loadedActor != null)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
