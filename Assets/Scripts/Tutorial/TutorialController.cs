using UnityEngine;
using System.Collections;
using System;

public enum TutorialState
{
    OPEN_CUTSCENE,
    PLAY_SESSION_1,
    COMBAT_1,
    PLAY_SESSION_2,
    BOSS,
    END_CUTSCENE
};

public class TutorialController : MonoBehaviour
{
    Transition transition;
    TutorialState tutorialState = TutorialState.OPEN_CUTSCENE;
    public GameObject playerGO;
    PlayerParty player;
    public GameObject cutsceneCam;
    public GameObject mainCam;
    public UIManager ui;
    
    public string[] oracleDialogueSetIntro01;

    void Awake()
    {
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
        player = playerGO.GetComponent<PlayerParty>();
    }

    void Start()
    {
        mainCam.SetActive(false);
        player.lockMovement = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && tutorialState == TutorialState.OPEN_CUTSCENE)
        {
            BeginTutorialPlaySession();
        }
    }

    public void BeginTutorialPlaySession()
    {
        tutorialState = TutorialState.PLAY_SESSION_1;
        cutsceneCam.SetActive(false);
        mainCam.SetActive(true);
        player.lockMovement = false;
        transition.SetColor(Color.clear);
        ui.CreateNewDialogueBox("This way! Swipe up and down to walk down the hall!");
    }

    public void OracleSpeakIntro_01()
    {
        ui.CreateNewDialogueBox(oracleDialogueSetIntro01[0]);
        ui.CreateNewDialogueBox(oracleDialogueSetIntro01[1]);
        ui.CreateNewDialogueBox(oracleDialogueSetIntro01[2]);
        ui.CreateNewDialogueBox(oracleDialogueSetIntro01[3], BeginTutorialPlaySession);
    }

    public void PlayerGetSword()
    {
        ui.CreateNewDialogueBox("Hey, look! A rusty sword!");
        ui.hideMenuToggle = false;
        ui.CreateNewDialogueBox("You can equip items by tapping the menu button below", EnableUI);
    }

    public void EnableUI()
    {
        ui.OpenMenu();
        ui.CreateNewDialogueBox("Open the INV screen, tap your player, then tap the sword!");
    }

    public void PlayerEncounterRockslide()
    {
        ui.CreateNewDialogueBox("Hmm.. Looks like this way is blocked off...");
        ui.CreateNewDialogueBox("Let's look for another way around!");
        ui.CreateNewDialogueBox("Swipe left and right to move down adjacent hallways!");
    }

    public void PlayerEncounterEnemyWarning()
    {
        ui.CreateNewDialogueBox("Hey. Wait... did you hear that?");
        ui.CreateNewDialogueBox("I think there's something else down here with us...");
    }

    public void PlayerEncounterEnemy1()
    {
        ui.CreateNewDialogueBox("Woah! Lookout!");
        player.lockMovement = true;
        transition.StartFade(new Color(0.05882f, 0f, 0.04314f, 1f), 1f, BeginTutorialCombatSession);
        tutorialState = TutorialState.COMBAT_1;
    }
    public void BeginTutorialCombatSession()
    {
        mainCam.SetActive(false);
        ui.DisplayCombatPanel(PostCombatSession1);
        transition.StartFade(Color.clear, 1f);
    }

    public void PostCombatSession1()
    {
        mainCam.SetActive(true);
        player.lockMovement = false;
        tutorialState = TutorialState.PLAY_SESSION_2;
        ui.CreateNewDialogueBox("Wow. That was intense. Are you okay?");
        ui.CreateNewDialogueBox("I think I see some health potions in the room in front of us.");
    }

    public void PlayerGetHealthPotion()
    {
        ui.CreateNewDialogueBox("To drink a potion, first open up your INV menu and select your hero.");
        ui.CreateNewDialogueBox("Next, tap on the potion to heal yourself!");
    }
    public void PlayerEncounterBossWarning()
    {
        ui.CreateNewDialogueBox("I think you and I will grow to be good friends.");
        ui.CreateNewDialogueBox("...Once we make it out of here together, of course.");
    }

    public void PlayerEncounterBoss()
    {
        ui.CreateNewDialogueBox("This guy's huge! Let's get out of here!");
        player.lockMovement = true;
        transition.StartFade(new Color(0.05882f, 0f, 0.04314f, 1f), 1f, BeginBossCombatSession);
        tutorialState = TutorialState.COMBAT_1;
    }

    public void BeginBossCombatSession()
    {
        mainCam.SetActive(false);
        ui.DisplayCombatPanel(PostCombatSession2);
        transition.StartFade(Color.clear, 1f);
    }

    public void PostCombatSession2()
    {
        cutsceneCam.SetActive(true);
        cutsceneCam.GetComponent<CutsceneCamera>().TriggerEndCutScene();
        tutorialState = TutorialState.END_CUTSCENE;
    }
}
