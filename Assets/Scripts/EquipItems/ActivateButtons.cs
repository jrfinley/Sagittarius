using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ActivateButtons : MonoBehaviour
{
    public Image player0;
    public Image player1;
    public Image player2;
    public Image player3;

    void Start ()
    {
        player0.gameObject.SetActive(false);
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        player3.gameObject.SetActive(false);
    }

    IEnumerator DisableOverTime()
    {
        yield return new WaitForSeconds(5);
        player0.gameObject.SetActive(false);
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
        player3.gameObject.SetActive(false);
    }

    public void enableImages()
    {
        player0.gameObject.SetActive(true);
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);
        player3.gameObject.SetActive(true);

        StartCoroutine(DisableOverTime());
    }
}
