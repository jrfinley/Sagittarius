using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
    public Sprite item;

    private int barrierHealth = 5;

    public GameObject barrier;

    void Start()
    {
        item = GetComponent<Sprite>();

        barrier = GetComponent<GameObject>();

        barrierHealth = 5;
    }

    void GetTouchCount(int count)
    {
        count = 5;

        if(Input.GetTouch(count).tapCount > count)
        {
            ClearBarrier(health:0);
        }
    }

    private void ClearBarrier(int health)
    {
        health = barrierHealth;

        if(health <= 0)
        {
            Destroy(barrier);
        }
    }

    void GetPickup(string item)
    {

    }

    void EquipItem(bool equip)
    {
        
    }
}