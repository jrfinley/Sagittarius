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
        InputManager iM = FindObjectOfType<InputManager>();

        iM.enabled = true;
    }

    void Start()
    {
        movementisActive = false;
    }

    public void GetMovementInput()
    {
        state = State.CanMove;

        if(state == State.CanMove)
        {
            movementisActive = true;
        }

        else if(state == State.CannotMove)
        {
            movementisActive = false;
        }
    }
}