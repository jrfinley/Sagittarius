using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
    private int barrierHealth = 0;

    public GameObject barrier;

    void Awake()
    {
        GameObject g = FindObjectOfType<GameObject>();

        g = barrier.gameObject;
    }

    void Start()
    {
        barrier = GetComponent<GameObject>();

        barrierHealth = 0;
    }

    void GetTouchCount(int count)
    {
        count = 5;

        if(Input.GetTouch(count).tapCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            barrierHealth--;

            if(count >= 5 && barrierHealth <= 0)
            {
                ClearBarrier(health: 0);
            }    
        }
    }

    // Test, Works when triggered with Player
    /*
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            barrierHealth--;

            if (barrierHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    */

    private void ClearBarrier(int health)
    {
        health = 0;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}