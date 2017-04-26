using UnityEngine;
using System.Collections;

public class OpeningCameraController : MonoBehaviour
{
    Transition transition;
    void Awake()
    {
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
    }

    public void FadeInTransition() //CALLED BY CAMERA ANIMATION
    {
        transition.StartFade(Color.clear, 2f);
    }
    public void FadeOutTransition() //CALLED BY CAMERA ANIMATION
    {
        transition.StartFade(new Color(0.05882f, 0f, 0.04314f, 1f), 1f);
    }
}
