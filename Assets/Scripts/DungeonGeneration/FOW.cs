using UnityEngine;
using System.Collections;

public class FOW : MonoBehaviour
{
    private Renderer rend;

    private Color unLit = new Color32(0x1D, 0x1D, 0x1D, 0xFF);
    private Color lit = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
    private Color kindaLit = new Color32(0x68, 0x68, 0x68, 0xFF);

    private enum STATE
    {
        Unseen, Seeing, Seen
    };

    private STATE currentState;

    void Start ()
    {
        rend = GetComponent<Renderer>();   
        this.rend.material.color = unLit;
        currentState = STATE.Unseen;       
    }

    void stateControl()
    {
        switch (currentState)
        {
            case STATE.Unseen:               
                break;

            case STATE.Seeing:
                this.rend.material.color = lit;
                break;

            case STATE.Seen:
                this.rend.material.color = kindaLit;
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        currentState = STATE.Seeing;
        stateControl();
    }

    void OnTriggerExit(Collider other)
    {
        currentState = STATE.Seen;
        stateControl();
    }

}

