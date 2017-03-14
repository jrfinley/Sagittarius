//Aidan Lawrence
//Controls the "Town scene" UI
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TownUIManager : MonoBehaviour
{
    public GameObject[] panels; //0 - Main Menu, 1 - Forge

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void CloseAllPanels()
    {
        foreach(GameObject p in panels)
        {
            p.SetActive(false);
        }
    }

    public void ShowMainMenuPanel()
    {
        CloseAllPanels();
        panels[0].SetActive(true);
    }

    public void ShowForgePanel()
    {
        CloseAllPanels();
        panels[1].SetActive(true);
    }

}
