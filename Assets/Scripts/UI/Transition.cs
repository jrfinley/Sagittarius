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

    public void StartFade(Color c, float speed)
    {
        StartCoroutine(Fade(c, speed));
    }

    IEnumerator Fade(Color c, float speed)
    {
        while(guiTexture.color != c)
        {
            guiTexture.color = Vector4.MoveTowards(guiTexture.color, c, speed * Time.deltaTime);
            yield return null;
        }
    }
}
