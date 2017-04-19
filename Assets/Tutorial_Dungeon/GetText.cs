using UnityEngine;
using System.Collections;

public class GetText : MonoBehaviour
{
    private DisplayText d;

    private MovementTutorial mT;

    void Awake()
    {
        mT = FindObjectOfType<MovementTutorial>();
    }

    void Start()
    {
        mT.enabled = false;

        d = FindObjectOfType<DisplayText>();
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Welcome")
        {
            mT.enabled = true; // activate movement input, then display movement dialogue

            StartCoroutine(d.DisplayOracleIntroText(d.dialogue[0]));
        }

        mT.GetMovementInput();

        if(other.gameObject.tag == "Movement")
        {
            StartCoroutine(d.Movement(d.dialogue[1]));
        }

        if (other.gameObject.tag == "PickUp")
        {
            StartCoroutine(d.PickUp(d.dialogue[2]));
        }

        if (other.gameObject.tag == "Combat")
        {
            StartCoroutine(d.Combat(d.dialogue[3]));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(d.inWelcomeZone == false)
        {
            d.inWelcomeZone = false;

            if (!other)
            {
                d.welcomeText.text = "";
            }
        }

        if (d.inMovementZone == false)
        {
            d.inMovementZone = false;

            if (!other)
            {
                d.movementText.text = "";
            }
        }

        if (d.inPickUpZone == false)
        {
            d.inPickUpZone = false;

            if (!other)
            {
                d.pickUpText.text = "";
            }
        }

        if (d.inCombatZone == false)
        {
            d.inCombatZone = false;

            if (!other)
            {
                d.welcomeText.text = "";
            }
        }
    }
}