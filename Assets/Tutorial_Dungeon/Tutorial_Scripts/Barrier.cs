using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour
{
    public Sprite item;

    private int barrierHealth = 0;

    public GameObject barrier;

    public Sprite sword;

    void Awake()
    {
        Sprite i = FindObjectOfType<Sprite>();

        i = item;

        GameObject g = FindObjectOfType<GameObject>();

        g = barrier.gameObject;
    }

    void Start()
    {
        sword = GetComponent<Sprite>();

        item = GetComponent<Sprite>();

        barrier = GetComponent<GameObject>();

        barrierHealth = 0;
    }

    void GetTouchCount(int count)
    {
        count = 5;

        if(Input.GetTouch(count).tapCount > count)
        {
            ClearBarrier(health:0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        barrierHealth--;

        if(other.gameObject.tag == "Player")
        {
           Destroy(barrier);
        }

        /*
        if(barrierHealth <= 0)
        {
            ClearBarrier(health: 0);
        }
        */
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            DestroyObject(this);
        }
    }

    private void ClearBarrier(int health)
    {
        health = 0;

        if(health <= 0)
        {
            Destroy(this.barrier);
        }
    }

    void GetPickup(string item)
    {
        if(item.Contains("Sword"))
        {
            item = sword.name;
        }
    }

    void EquipItem(bool equip)
    {
        equip = true;

        if(equip && item == sword)
        {
            GetPickup(item:"Sword");
        }
    }
}