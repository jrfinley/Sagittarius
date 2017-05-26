﻿//Aidan Lawrence
//Manages core in-game UI functions. Due to Unity 5.3.1, a couple hacky-workarounds may need to be implemented. 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public bool hideMenuToggle = false; //Prevents the player from opening the menu, but still allows for menu functions like chat boxes.
    bool isMenuOpen = false;
    public GameObject[] menuToggleButtons = new GameObject[2]; //0-Up, 1-Down
    public GameObject[] contentPanels; //0-Stats, 1 Gear, 2 Inventory
    public Text[] currencyTexts; //0-Gold, 1-Food, 2-Scrap
    public GameObject emptyHeroCard;
    public Transform heroCardAreaTransform;
    public List<HeroCard> heroCards = new List<HeroCard>();
    public Image[] heroIcons;
    int selectedHero = 0;
    public RectTransform MasterMenuBacking;
    public CombatPanel combatPanel;
    public DialogueBox dialogueBox;
    public CharacterStats characterStats;
    public GearStats gearStats;
    public Inventory inventory;
    public InventoryDisplay inventoryDisplay;
    public GearPanel gear;
    CanvasScaler canvasScaler;
    PlayerParty playerParty;


    void Awake()
    {
        GameObject pPartyGO = GameObject.FindGameObjectWithTag("Player");
        if(pPartyGO != null)
            playerParty = pPartyGO.GetComponent<PlayerParty>();
    }

    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        MasterMenuBacking.gameObject.SetActive(true);
        dialogueBox.gameObject.SetActive(true);
        MasterMenuBacking.transform.localScale = Vector3.zero;
        menuToggleButtons[0].SetActive(true);
        menuToggleButtons[1].SetActive(false);
        //CreatePartyCards();
        SelectHero(selectedHero);
        SetCurrencyGold(0);
        SetCurrencyFood(0);
        SetCurrencyScrap(0);
        if(playerParty != null)
            inventory.SetCarryWeight(playerParty.maxEquipmentLoad, 0);
        UpdateAllHeroStats();
        Canvas.ForceUpdateCanvases();
    }

    void Update()
    {
        if(hideMenuToggle)
        {
            CloseMenu();
            foreach (GameObject m in menuToggleButtons)
                m.SetActive(false);
        }
        else if(!isMenuOpen)
        {
            menuToggleButtons[0].SetActive(true);
        }
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
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
        MasterMenuBacking.transform.localScale = Vector3.one;
        menuToggleButtons[0].SetActive(false);
        menuToggleButtons[1].SetActive(true);
        SelectHero(selectedHero);
        UpdateAllHeroStats();
        if(playerParty != null)
            inventory.SetCarryWeight(playerParty.maxEquipmentLoad, 0);
        Canvas.ForceUpdateCanvases();
    }

    void CreatePartyCards()
    {
        foreach (HeroCard card in heroCards)
            Destroy(card.gameObject);
        heroCards.Clear();
        if(playerParty == null)
        {
            return;
        }
        foreach(BaseCharacter c in playerParty.characters)
        {
            GameObject tmp = Instantiate(emptyHeroCard, Vector3.zero, Quaternion.identity) as GameObject;
            tmp.transform.SetParent(heroCardAreaTransform);
            HeroCard card = tmp.GetComponent<HeroCard>();
            heroCards.Add(card);
            if (c == null)
            {
                Debug.LogError("Characters in player party are null!");
            }

            card.icon = Resources.Load("UIIcons/placeholderChar_1", typeof(Sprite)) as Sprite;
        }
    }

    public int GetSelectedHero()
    {
        return selectedHero;
    }

    public void CloseMenu()
    {
        isMenuOpen = false;
        MasterMenuBacking.transform.localScale = Vector3.zero;
        menuToggleButtons[0].SetActive(true);
        menuToggleButtons[1].SetActive(false);
        Canvas.ForceUpdateCanvases();
    }

    public void SelectHero(int hero)
    {
        if(playerParty == null)
        {
            Debug.LogError("No PlayerParty found!");
            return;
        }
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
        UpdateHeroStats(hero);
        //gear.UpdateGear();
    }

    public void UpdateHeroStats(int hero)
    {
        if (playerParty == null)
            return;
        if (playerParty.characters.Length < 1 || playerParty.characters[hero] == null)
            Debug.LogWarning("Player party is empty or hero index is out of range! No stats updated.");
        else
        {
            characterStats.DrawCharacterStatistics(playerParty.characters[hero]);
            heroCards[hero].SetHealthBar(playerParty.characters[hero].Health, playerParty.characters[hero].MaxHealth); //Not robust. May want to have this as part of the character class.
            gearStats.SetGearBonusStats(playerParty.characters[hero]);
        }
    }

    public void UpdateAllHeroStats()
    {
        if (playerParty != null)
        {
            for (int i = 0; i < playerParty.characters.Length; i++)
            {
                if (playerParty.characters[i] != null)
                    UpdateHeroStats(i);
            }
        }
    }

    public void AddRemoveEquippedItem(Item item, InventoryItemDisplay itemDisplay) //Entire inventory system needs to be completely refactored. This level of script cross-talk shouldn't be necessary.
    {
        BaseCharacter selectedPlayer = GetSelectedCharacter();
        switch (item.Types.ItemType)
        {
            case EItemType.ARMOR:
                if (selectedPlayer != itemDisplay.item.equippedBy)
                {
                    if(itemDisplay.item.equippedBy != null)
                        itemDisplay.item.equippedBy.RemoveItem(1); //Remove from previous character
                    selectedPlayer.EquipItem(item, 1);
                    itemDisplay.Equip(selectedPlayer);
                }
                else
                {
                    selectedPlayer.RemoveItem(1);
                    itemDisplay.Remove();
                }
                break;
            case EItemType.ACCESSORY:
                if (selectedPlayer != itemDisplay.item.equippedBy)
                {
                    if (itemDisplay.item.equippedBy != null)
                        itemDisplay.item.equippedBy.RemoveItem(4); 
                    selectedPlayer.EquipItem(item, 4);
                    itemDisplay.Equip(selectedPlayer);
                }
                else
                {
                    selectedPlayer.RemoveItem(4);
                    itemDisplay.Remove();
                }
                break;
            //case EItemType.WEAPON:
            //    if (selectedPlayer != itemDisplay.item.equippedBy)
            //    {
            //        if (itemDisplay.item.equippedBy != null)
            //            itemDisplay.item.equippedBy.RemoveItem(3); 
            //        selectedPlayer.EquipItem(item, 3);
            //        itemDisplay.Equip(selectedPlayer);
            //    }
            //    else
            //    {
            //        selectedPlayer.RemoveItem(3);
            //        itemDisplay.Remove();
            //    }
            //    break;
            default:
                Debug.LogError("Attempted to equip unknown item type: " + item.Types.EquipSlot.ToString());
                break;
        }

    }

    public void DisplayStatsPanel()
    {
        HideAllContentPanels();
        SelectHero(selectedHero);
        UpdateHeroStats(selectedHero);
        contentPanels[0].SetActive(true);
    }

    public void DisplayGearPanel()
    {
        HideAllContentPanels();
        //gear.UpdateGear();
        contentPanels[1].SetActive(true);
    }

    public void DisplayInventoryPanel()
    {
        HideAllContentPanels();
        if(playerParty != null)
            inventory.SetCarryWeight(playerParty.maxEquipmentLoad, playerParty.equipmentLoad);
        contentPanels[2].SetActive(true);
    }

    public void DisplayMiscPanel() 
    {
        HideAllContentPanels();
        contentPanels[3].SetActive(true);
    }

    public void DisplayCombatPanel(System.Action postCombatCallback) //Eventually pass in an array of enemy-classes and display their stats dynamically.
    {
        //CreateNewDialogueBox("You are under attack!");
        //combatPanel.gameObject.SetActive(true);
        StartCoroutine(LoadCombatScene(postCombatCallback));

        CloseMenu();
        //combatPanel.CreateCombatPanel();
    }

    IEnumerator LoadCombatScene(System.Action postCombatCallback)
    {
        //bool loaded = SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
        var loaded = Application.LoadLevelAdditiveAsync("Combat");
        yield return loaded;
        if (postCombatCallback != null)
            GameObject.FindGameObjectWithTag("CombatPanel").GetComponent<CombatPanel>().SetPostCombatCallback(postCombatCallback);
    }

    public void TestButton1() //Found on the Misc tab for now. Just for testing.
    {
        CreateNewDialogueBox("Nam mollis metus ut felis consectetur ornare. Nunc in quam et sem congue vestibulum ipsumorut risus."); //Giant test sentance.
    }

    public bool CreateNewDialogueBox(string dialogue, System.Action callBack) //Use this function to create a new dialogue box with a callback. 
    {
        return dialogueBox.ShowDialogueBox(dialogue, callBack);
    }

    public bool CreateNewDialogueBox(string dialogue) //Use this function to create a new dialogue box. 
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

    public void SetCurrencyGold(int value)
    {
        currencyTexts[0].text = value.ToString();
    }

    public void SetCurrencyFood(int value)
    {
        currencyTexts[1].text = value.ToString();
    }

    public void SetCurrencyScrap(int value)
    {
        currencyTexts[2].text = value.ToString();
    }

    public BaseCharacter GetSelectedCharacter()
    {
        return playerParty.characters[selectedHero];
    }
}
