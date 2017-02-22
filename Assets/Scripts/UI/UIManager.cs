//Aidan Lawrence
//Manages core in-game UI functions. Due to Unity 5.3.1, a couple hacky-workarounds may need to be implemented. 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    bool isMenuOpen = false;
    public GameObject[] menuToggleButtons = new GameObject[2]; //0-Up, 1-Down
    public GameObject[] contentPanels; //0-Stats, 1 Gear, 2 Inventory
    public RectTransform MasterMenuBacking;
    CanvasScaler canvasScaler;
    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        //MasterMenuBacking.offsetMax = new Vector2(MasterMenuBacking.offsetMax.x, -canvasScaler.referenceResolution.y);
        MasterMenuBacking.transform.localScale = Vector3.zero;
        menuToggleButtons[0].SetActive(true);
        menuToggleButtons[1].SetActive(false);
        Canvas.ForceUpdateCanvases();
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        //MasterMenuBacking.offsetMax = new Vector2(MasterMenuBacking.offsetMax.x, BottomMarker.rect.position.y);
        if (isMenuOpen)
        {
            //MasterMenuBacking.offsetMax = new Vector2(MasterMenuBacking.offsetMax.x, 0);
            MasterMenuBacking.transform.localScale = Vector3.one;
            menuToggleButtons[0].SetActive(false);
            menuToggleButtons[1].SetActive(true);
            Canvas.ForceUpdateCanvases();
        }
        else
        {
            //MasterMenuBacking.offsetMax = new Vector2(MasterMenuBacking.offsetMax.x, -canvasScaler.referenceResolution.y);
            MasterMenuBacking.transform.localScale = Vector3.zero;
            menuToggleButtons[0].SetActive(true);
            menuToggleButtons[1].SetActive(false);
            Canvas.ForceUpdateCanvases();
        }
    }

    public void DisplayStatsPanel()
    {
        HideAllContentPanels();
        contentPanels[0].SetActive(true);
    }

    public void DisplayGearPanel()
    {
        HideAllContentPanels();
        contentPanels[1].SetActive(true);
    }

    public void DisplayInventoryPanel()
    {
        HideAllContentPanels();
        contentPanels[2].SetActive(true);
    }

    public void DisplayMiscPanel() //This panel has not been designed yet!
    {
        HideAllContentPanels();
        Debug.Log("Nothing in this panel yet!");
    }

    void HideAllContentPanels()
    {
        foreach (GameObject p in contentPanels)
            p.SetActive(false);
    }
	
}
