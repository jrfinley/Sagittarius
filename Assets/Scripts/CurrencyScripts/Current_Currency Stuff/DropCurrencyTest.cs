using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropCurrencyTest : BaseCurrency
{
    protected int health = 100;

    public Transform item;

    private Text goldText;

    protected float treasureDistance;

    private GameObject obj;

    void Update() // For testing
    {
        if(health > 0)
        {
            health -= 1;
        }

        if(health <= 0)
        {
            Instantiate(item, this.transform.position, this.transform.rotation);

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col) // For testing
    {
        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);

            currencyAmount += totalMaxCurrency;

            goldText.text = currencyAmount + "Amount";
        }
    }
}