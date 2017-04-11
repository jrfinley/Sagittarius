using UnityEngine;
using System.Collections;

public class MovementTutorial : MonoBehaviour 
{
    private InputManager iM;

    private bool movementisActive = false;

    private enum State
    {
        CanMove, 
        CannotMove, 
    }

    void Awake()
    {
        this.gameObject.SetActive(false);

        movementisActive = false;
    }

    void Start()
    {
        iM = GetComponent<InputManager>();
    }

    void GetMovementInput()
    {
        if(movementisActive)
        {
            iM.gameObject.SetActive(true);

            iM.GetComponent<InputManager>().enabled = true;
        }
        else
        {
            if(!movementisActive)
            {
                iM.GetComponent<InputManager>().enabled = false;
            }
        }
    }
}
