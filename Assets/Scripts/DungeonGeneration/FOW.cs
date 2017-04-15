using UnityEngine;
using System.Collections;

public class FOW : MonoBehaviour
{
    private Renderer rend;

    private Color unLit = new Color32(0x1D, 0x1D, 0x1D, 0xFF);
    private Color lit = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
    private Color kindaLit = new Color32(0x68, 0x68, 0x68, 0xFF);

    public float lerpSpeed;

    public enum STATE
    {
        Unseen, Seeing, Seen
    };

    public STATE currentState;

    void Start ()
    {
        rend = GetComponent<Renderer>();   
        this.rend.material.color = unLit;
        currentState = STATE.Unseen;       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerParty")
        {
            currentState = STATE.Seeing;
            StartCoroutine(ChangeFOW());
        }
            
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerParty")
        {
            currentState = STATE.Seen;
            StartCoroutine(ChangeFOW());
        }
    }

    IEnumerator ChangeFOW()
    {
        Color targetColor;
        float loopBreak = 0f;
        float speed = 0;

        if (currentState == STATE.Unseen)
            targetColor = unLit;

        else if (currentState == STATE.Seeing)
            targetColor = lit;

        else
            targetColor = kindaLit;


        while (this.rend.material.color != targetColor)
        {
            if (loopBreak < 5f)
                this.rend.material.color = Color32.Lerp(this.rend.material.color, targetColor, speed);
            else
                Debug.LogError("ChangeFOW reached loop break cutoff");

            speed  += lerpSpeed;
            loopBreak += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}

