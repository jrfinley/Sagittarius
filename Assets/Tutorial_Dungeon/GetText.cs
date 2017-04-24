using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Welcome")
        {
            mT.enabled = true;

            StartCoroutine(d.DisplayOracleIntroText(d.dialogue[0]));
        }

        mT.GetMovementInput();

        if (other.gameObject.tag == "Movement")
        {
            StartCoroutine(d.Movement(d.dialogue[1]));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Combat")
        {
            StartCoroutine(d.Combat(d.dialogue[3]));
        }

        if (other.gameObject.tag == "PickUp")
        {
            StartCoroutine(d.PickUp(d.dialogue[2]));
        }
    }

    void OnTriggerExit(Collider other)
    {
        d.inWelcomeZone =!d.inWelcomeZone;

        if(d.inWelcomeZone == false)
        {
            d.inWelcomeZone = false;

            if (!other.gameObject)
            {
                d.inWelcomeZone = true;
            }
        }

        else if (d.inMovementZone == false)
        {
            d.inMovementZone = false;

            if (!other.gameObject)
            {
                d.inMovementZone = true;
            }
        }

        else if (d.inPickUpZone == false)
        {
            d.inPickUpZone = false;

            if (!other.gameObject)
            {
                d.inPickUpZone = true;
            }
        }

        else if (d.inCombatZone == false)
        {
            d.inCombatZone = false;

            if (!other.gameObject)
            {
                d.inCombatZone = true;
            }
        }
    }
}