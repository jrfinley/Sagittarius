using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{
    private UIManager ui;

    private  Text welcomeText;

    private Text movementText;

    private Text pickUpText;

    private Text combatText;

    public bool inWelcomeZone = false;

    public bool inMovementZone = false;

    public bool inPickUpZone = false;

    public bool inCombatZone = false;

    public string[] dialogue;

    private string wText;

    private string mText;

    private string pText;

    private string cText;

    private float characterWaitTime = 0.1f;

    void Start()
    {

        ui = FindObjectOfType<UIManager>();

        inWelcomeZone = false;

        inMovementZone = false;

        inPickUpZone = false;

        inCombatZone = false;

        welcomeText = FindObjectOfType<Text>();

        wText = welcomeText.text;

        welcomeText.text = "";

        movementText = FindObjectOfType<Text>();

        mText = movementText.text;

        movementText.text = "";

        pickUpText = FindObjectOfType<Text>();

        pText = pickUpText.text;

        pickUpText.text = "";

        combatText = FindObjectOfType<Text>();

        cText = combatText.text;

        combatText.text = "";
    }

    public IEnumerator DisplayOracleIntroText(string dialogue)
    {
        inWelcomeZone = true;

        welcomeText = GetComponent<Text>();

        wText = "";

        int legnth = wText.Length;

        int characterIndex = 0;

        while(characterIndex < legnth)
        {
            welcomeText.text += wText[characterIndex];

            characterIndex++;

            if(characterIndex < legnth)
            {
                yield return new WaitForSeconds(characterWaitTime);
            }
            else
            {
                break;
            }
        }

        if(inWelcomeZone == true)
        {
            ui.CreateNewDialogueBox("Welcome to Sagittarius");
        }
      
        else
        {
            inWelcomeZone = false;

            if(inWelcomeZone == false)
            {
                welcomeText.text = "";
            }
        }
    }

    public IEnumerator Movement(string dialogue)
    {
        inMovementZone = true;

        movementText = GetComponent<Text>();

        mText = movementText.text;

        int legnth = mText.Length;

        int characterIndex = 0;

        while (characterIndex < legnth)
        {
            movementText.text += mText[characterIndex];

            characterIndex++;

            if (characterIndex < legnth)
            {
                yield return new WaitForSeconds(characterWaitTime);
            }
            else
            {
                break;
            }
        }

        if (inMovementZone == true)
        {
            ui.CreateNewDialogueBox("Are you ready to get started? " + "\n" + "to navigate around, you may use swipe input"+
                "\n," + "Swipe Left" + "Swipe Right" + "Swipe Up" + "Swipe Down");
        }

        else
        {
            inMovementZone = false;

            if (inMovementZone == false)
            {
                movementText.text = "";
            }
        }

        yield return null;
    }

    public IEnumerator PickUp(string dialogue)
    {
        inPickUpZone = true;

        pickUpText = GetComponent<Text>();

        pText = pickUpText.text;

        int legnth = wText.Length;

        int characterIndex = 0;

        while (characterIndex < legnth)
        {
            pickUpText.text += pText[characterIndex];

            characterIndex++;

            if (characterIndex < legnth)
            {
                yield return new WaitForSeconds(characterWaitTime);
            }
            else
            {
                break;
            }
        }

        if (inPickUpZone == true)
        {
             ui.CreateNewDialogueBox("You have now discovered your first item" + "\n" +
                "use and equip for all your needs");
        }

        else
        {
            inPickUpZone = false;

            if (inPickUpZone == false)
            {
                pickUpText.text = "";
            }
        }

        yield return null;
    }

    public IEnumerator Combat(string dialogue)
    {
        inCombatZone = true;

        combatText = GetComponent<Text>();

        cText = combatText.text;

        int legnth = cText.Length;

        int characterIndex = 0;

        while (characterIndex < legnth)
        {
            combatText.text += cText[characterIndex];

            characterIndex++;

            if (characterIndex < legnth)
            {
                yield return new WaitForSeconds(characterWaitTime);
            }
            else
            {
                break;
            }
        }

        if (inCombatZone == true)
        {
            ui.CreateNewDialogueBox("You have now entered a combat zone" + "\n" + "You will be able to Attack, Heal, or Run ");

            yield return new WaitForSeconds(5.0f);

            SceneManager.LoadScene("Combat", LoadSceneMode.Additive);

            SceneManager.UnloadScene(2);
        }

        else
        {
            inCombatZone = false;

            if (inCombatZone == false)
            {
                combatText.text = "";
            }
        }

        yield return null;
    }
}