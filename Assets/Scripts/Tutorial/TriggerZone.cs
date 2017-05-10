using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TriggerZone : MonoBehaviour
{
    public UnityEvent callOnEnter;
    public bool triggerOneShot = false;
    bool trigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (triggerOneShot && trigger)
                return;
            if (callOnEnter != null)
            {
                callOnEnter.Invoke();
                trigger = true;
            }
        }

    }
}
