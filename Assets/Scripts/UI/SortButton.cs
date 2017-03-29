using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SortButton : MonoBehaviour
{
    public RectTransform arrowIcon;
    Image arrowImage;
    Quaternion upsideDown = Quaternion.Euler(0,0,180);

    void Awake()
    {
        arrowImage = arrowIcon.GetComponent<Image>();
    }

    public void ResetSortDirection()
    {
        arrowIcon.rotation = Quaternion.identity;
        arrowImage.color = Color.gray;
    }

    public void ChangeSortDirection(bool isSortingHigh)
    {
        arrowImage.color = Color.black;
        if (isSortingHigh)
            arrowIcon.rotation = Quaternion.identity;
        else
            arrowIcon.rotation = upsideDown; 
    }
}
