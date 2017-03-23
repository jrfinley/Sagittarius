//Aidan Lawrence
//Controls the "Town scene" UI
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TownUIManager : MonoBehaviour
{
    public GameObject[] panels; //0 - Main Menu, 1 - Forge, 2 - Character Training, 3 - Adjust Party, 4 - Shop, 5 - Inventory, 6 - Options

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

    public void ShowPanel(int index)
    {
        CloseAllPanels();
        panels[index].SetActive(true);
    }
}
