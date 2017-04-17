using UnityEngine;
using System.Collections;

public class MovementTutorial : MonoBehaviour 
{
    private InputManager iM;

    private bool movementisActive = false;

    State state = State.CannotMove;

    private enum State
    {
        CanMove, 
        CannotMove, 
    }

    void Awake()
    {
        this.gameObject.SetActive(false);

        movementisActive = false;

        state = State.CannotMove;
    }

    void Start()
    {
        iM = GetComponent<InputManager>();
    }

    public void GetMovementInput()
    {
        state = State.CanMove;

        if(state == State.CanMove)
        {
            movementisActive = true;

            if (movementisActive == true)
            {
                iM.gameObject.SetActive(true);

                iM.GetComponent<InputManager>().enabled = true;
            }
        }

       else if(state == State.CannotMove)
        {
            if(state == State.CannotMove)
            {
                movementisActive = false;

                if(movementisActive == false)
                {
                    iM.GetComponent<InputManager>().enabled = false;
                }
            }
        }
    }
}