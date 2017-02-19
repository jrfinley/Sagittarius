using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    /*While attached to the canvas this allows
    the canvas's setting of constant pixel size to be
    scale with screen size on start allowing the inventory
    to keep scale and not have clipping issues by having it set
    to scale when screen size by default*/

    private CanvasScaler scaler;

	void Start ()
    {
        scaler = GetComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
	}
	
}
