using UnityEngine;
using System.Collections;

public class GenerateLoader : MonoBehaviour
{
    private GameController gameController;

	void Start ()
    {
        gameController = FindObjectOfType<GameController>();

        StartCoroutine(CallLoaderSpawn());
	}

    IEnumerator CallLoaderSpawn()
    {
        yield return new WaitForSeconds(.25f);
        gameController.Load();
        Destroy(gameObject);
    }


}
