using UnityEngine;
using System.Collections;

public class DialogDisplay : MonoBehaviour
{
    // Dialog display will handle message board text events, where the player will
    // be responsible for following the tutorial phase and listening to what the oracle has to say in order
    // to have a successful learning method of approach to the game... 

    private DialogueBox dialogBox;

    void ShowDialogueBox()
    {
        dialogBox.enabled = true;
    }

    void DoNoShowDialogBox()
    {
        dialogBox.enabled = false;
    }

    void TextForOracle()
    {
        dialogBox.textBox.enabled = true;
    }

    private void TextDisplay(string text)
    {
        text.ToString();
    }
}
