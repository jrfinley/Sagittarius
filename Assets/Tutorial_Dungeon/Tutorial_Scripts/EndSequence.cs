using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSequence : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Town", LoadSceneMode.Single);

            SceneManager.LoadScene(1);
        }
    }
}