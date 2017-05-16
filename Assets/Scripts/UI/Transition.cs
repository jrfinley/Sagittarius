using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour
{
    Color fadeInColor = Color.black;
    Color fadeOutColor = Color.black;
    GUITexture guiTexture;

    public void Awake()
    {
        guiTexture = GetComponent<GUITexture>();
    }

    public void SetColor(Color c)
    {
        StopAllCoroutines();
        guiTexture.color = c;
    }

    public void StartFade(Color c, float speed)
    {
        StartCoroutine(Fade(c, speed, null));
    }

    public void StartFade(Color c, float speed, System.Action afterFadeCallback)
    {
        StartCoroutine(Fade(c, speed, afterFadeCallback));
    }

    IEnumerator Fade(Color c, float speed, System.Action afterFadeCallback)
    {
        while(guiTexture.color != c)
        {
            guiTexture.color = Vector4.MoveTowards(guiTexture.color, c, speed * Time.deltaTime);
            yield return null;
        }
        if (afterFadeCallback != null)
            afterFadeCallback();
    }
}
