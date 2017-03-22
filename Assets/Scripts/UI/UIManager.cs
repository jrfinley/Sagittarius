//Aidan Lawrence
//Manages core in-game UI functions. Due to Unity 5.3.1, a couple hacky-workarounds may need to be implemented. 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    bool isMenuOpen = false;
    public GameObject[] menuToggleButtons = new GameObject[2]; //0-Up, 1-Down
    public GameObject[] contentPanels; //0-Stats, 1 Gear, 2 Inventory
    public Image[] heroIcons;
    int selectedHero = 0;
    public RectTransform MasterMenuBacking;
    public CombatPanel combatPanel;
    public DialogueBox dialogueBox;
    CanvasScaler canvasScaler;
    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        MasterMenuBacking.gameObject.SetActive(true);
        dialogueBox.gameObject.SetActive(true);
        //MasterMenuBacking.offsetMax = new Vector2(MasterMenuBacking.offsetMax.x, -canvasScaler.referenceResolution.y);
        MasterMenuBacking.transform.localScale = Vector3.zero;
        menuToggleButtons[0].SetActive(true);
        menuToggleButtons[1].SetActive(false);
        SelectHero(selectedHero);
        Canvas.ForceUpdateCanvases();
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        //MasterMenuBacking.offsetMax = new Vector2(MasterMenuBacking.offsetMax.x, BottomMarker.rect.position.y);
        if (!isMenuOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        isMenuOpen = true;
        //MasterMenuBacking.offsetMax = new Vector2(MasterMenuBacking.offsetMax.x, 0);
        MasterMenuBacking.transform.localScale = Vector3.one;
        menuToggleButtons[0].SetActive(false);
        menuToggleButtons[1].SetActive(true);
        Canvas.ForceUpdateCanvases();
    }

    public void CloseMenu()
    {
        isMenuOpen = false;
        //MasterMenuBacking.offsetMax = new Vector2(MasterMenuBacking.offsetMax.x, -canvasScaler.referenceResolution.y);
        MasterMenuBacking.transform.localScale = Vector3.zero;
        menuToggleButtons[0].SetActive(true);
        menuToggleButtons[1].SetActive(false);
        Canvas.ForceUpdateCanvases();
    }

    public void SelectHero(int hero)
    {
        if(hero == selectedHero)
        {
            Toggle t = heroIcons[hero].GetComponent<Toggle>();
            heroIcons[hero].GetComponent<Image>().color = t.colors.pressedColor;
            return;
        }
        Toggle toggle = heroIcons[selectedHero].GetComponent<Toggle>();
        heroIcons[selectedHero].GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        selectedHero = hero;
        toggle = heroIcons[selectedHero].GetComponent<Toggle>();
        heroIcons[hero].GetComponent<Image>().color = toggle.colors.pressedColor;
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

    public void DisplayMiscPanel() 
    {
        HideAllContentPanels();
        contentPanels[3].SetActive(true);
    }

    public void DisplayCombatPanel() //Eventually pass in an array of enemy-classes and display their stats dynamically.
    {
        CreateNewDialogueBox("You are under attack!");
        combatPanel.gameObject.SetActive(true);
        CloseMenu();
        //combatPanel.CreateCombatPanel();
    }

    public void TestButton1() //Found on the Misc tab for now. Just for testing.
    {
        CreateNewDialogueBox("Nam mollis metus ut felis consectetur ornare. Nunc in quam et sem congue ultrices. Praesent erat risus, sollicitudin sit amet mattis non, porta eu dolor. Vivamus scelerisque enim ut cursus ullamcorper. Aenean ut pulvinar velit, quis sagittis lectus. Donec ac turpis convallis, accumsan dolor facilisis, vestibulum ipsum. Cras sit amet luctus est. Nullam vitae iaculis elit. Curabitur aliquam libero dolor, quis vehicula nunc euismod eu. Integer maximus convallis nisl, vitae rutrum nunc mattis sagittis. Quisque nunc nibh, tincidunt a rutrum non, feugiat ut risus. Sed sed efficitur neque, et venenatis est. Aenean pulvinar sit amet magna sit amet sollicitudin. Aliquam commodo enim vitae quam pulvinar, ut ultricies dui iaculis. Aenean volutpat eros sit amet odio bibendum, nec efficitur purus mollis."); //Giant test sentance.
    }

    public bool CreateNewDialogueBox(string dialogue) //Use this function to create a new dialogue box. Returns true if OK, false if a box is already up.
    {
        return dialogueBox.ShowDialogueBox(dialogue);
    }



    void HideAllContentPanels()
    {
        foreach (GameObject p in contentPanels)
            p.SetActive(false);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
