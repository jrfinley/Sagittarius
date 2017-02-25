using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enable_Disable_ImageOnTouch : MonoBehaviour
{
    private bool isOpened;

    public CanvasGroup canvasGroup;
	    
    void Start()
    {
        canvasGroup.alpha = 0;
    }

    public void Open()
    {
        if(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha = 0;
        }
        else
        {
            canvasGroup.alpha = 2;
        }
        
    }
}
