using UnityEngine;
using System.Collections;

public class ActivatePanels : MonoBehaviour
{
    public GameObject welcomeZone;

    public GameObject movementZone;

    public GameObject pickUpZone;

    public GameObject combatZone;

    void Awake()
    {
        GameObject w = FindObjectOfType<GameObject>();

        w = welcomeZone.gameObject;

        GameObject m = FindObjectOfType<GameObject>();

        m = movementZone.gameObject;

        GameObject p = FindObjectOfType<GameObject>();

        p = pickUpZone.gameObject;

        GameObject c = FindObjectOfType<GameObject>();

        c = combatZone.gameObject;
    }

    void Start()
    {
        // were set to false until properly called, but those calls don't work at the moment

        welcomeZone.SetActive(true); 

        movementZone.SetActive(true);

        pickUpZone.SetActive(true);

        combatZone.SetActive(true);
    }

    public void Welcome()
    {
        welcomeZone.SetActive(true);
    }

    public void Move()
    {
        movementZone.SetActive(true);
    }

    public void PickUp()
    {
        pickUpZone.SetActive(true);
    }

    public void Combat()
    {
        combatZone.SetActive(true);
    }
}