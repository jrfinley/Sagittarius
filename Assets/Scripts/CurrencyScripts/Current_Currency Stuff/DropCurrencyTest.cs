using UnityEngine;
using System.Collections;

public class DropCurrencyTest : Gold
{
    protected int health = 100;

    public Transform item;

    new void Update()
    {
        if(health > 0)
        {
            health -= 1;

            Debug.Log("Health" + health);
        }

        if(health <= 0)
        {
            Instantiate(item, this.transform.position, this.transform.rotation);

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Collision");

            Destroy(col.gameObject);

            currencyAmount += totalCurrency;

            goldText.text = currencyAmount + "Amount";
        }
    }
}