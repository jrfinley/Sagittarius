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
    
    //Port this to StateMachineEngine
    void fowState()
    {
        switch (currentState)
        {
            case STATE.Unseen:
                break;

            case STATE.Seeing:
                if (this.rend.material.color == unLit)
                {
                    this.rend.material.color = Color32.Lerp(unLit, lit, Time.time);
                }
                if(this.rend.material.color == kindaLit)
                {
                    this.rend.material.color = Color32.Lerp(kindaLit, lit, Time.time);
                }
                break;

            case STATE.Seen:
                this.rend.material.color = Color32.Lerp(lit, kindaLit, Time.time);
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerParty")
        {
            currentState = STATE.Seeing;
            fowState();
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerParty")
        {
            currentState = STATE.Seen;
            fowState();
        }
    }

}

