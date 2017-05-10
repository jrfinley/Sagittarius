//Aidan Lawrence
//Gets input from touch screen and keyboard.
using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    void Awake()
    {
        playerParty = FindObjectOfType<PlayerParty>();
    }
    void Update ()
    {
        GetKeyboardInput(); //Comment this function out to disable PC inputs.
        GetSwipeInput();
	}

    float gestureStartTime = 0f;
    Vector2 gestureStartPosition = Vector2.zero;
    bool gestureDetected = false;
    float minGestureDistance = 50f;
    float maxGestureTime = 0.5f;
    PlayerParty playerParty;

    void GetSwipeInput() //Returns swipe directions from one finger. Based on: http://pfonseca.com/swipe-detection-on-unity/
    {
        if(Input.touchCount > 0)
        {
            foreach(Touch t in Input.touches)
            {
                switch(t.phase)
                {
                    case TouchPhase.Began:
                        gestureDetected = true;
                        gestureStartTime = Time.time;
                        gestureStartPosition = t.position;
                        break;
                    case TouchPhase.Canceled:
                        gestureDetected = false;
                        break;
                    case TouchPhase.Ended:
                        float gestureTime = Time.time - gestureStartTime;
                        float gestureDistance = (t.position - gestureStartPosition).magnitude;
                        if(gestureDetected && gestureTime < maxGestureTime && gestureDistance > minGestureDistance)
                        {
                            Vector2 direction = t.position - gestureStartPosition;
                            Vector2 swipe = Vector2.zero;
                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                                swipe = Vector2.right * Mathf.Sign(direction.x);
                            else
                                swipe = Vector2.up * Mathf.Sign(direction.y);
                            if(swipe.x != 0f)
                            {
                                if (swipe.x > 0f)
                                    InputRight();
                                else
                                    InputLeft();
                            }
                            if(swipe.y != 0f)
                            {
                                if (swipe.y > 0f)
                                    InputUp();
                                else
                                    InputDown();
                            }
                        }
                        break;
                }
            }
        }
    }

    void GetKeyboardInput() //Dead simple function that polls for "Key Down" inputs on any directional keys (WASD, UDLR). Does not poll axis.
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            InputLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            InputRight();
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            InputUp();
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            InputDown();
    }

    void InputUp()
    {
        Debug.Log("INPUT UP");
        if (playerParty != null)
        {
            playerParty.SetMoveDirection(new Vector3(0, 0, 1));
        }
    }

    void InputDown()
    {
        Debug.Log("INPUT DOWN");
        if (playerParty != null)
        {
            playerParty.SetMoveDirection(new Vector3(0, 0, -1));
        }
    }

    void InputLeft()
    {
        Debug.Log("INPUT LEFT");
        if (playerParty != null)
        {
            playerParty.SetMoveDirection(new Vector3(-1, 0, 0));
        }
    }

    void InputRight()
    {
        Debug.Log("INPUT RIGHT");
        if (playerParty != null)
        {
            playerParty.SetMoveDirection(new Vector3(1, 0, 0));
        }
    }

}
