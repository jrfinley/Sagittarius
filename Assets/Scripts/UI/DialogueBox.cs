//Aidan Lawrence
//Script that handles the pop-up dialogue box.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class DialogueBox : MonoBehaviour
{
    public int maxCharactersBeforeBreak = 100; //How many characters should appear on the screen before breaking to the next page?
    public float characterSpeed = 0.1f; //How many seconds to wait before the next character apears?
    public Text textBox;
    public Image dialogueBoxBacking;
    public Image continueMarker;
    bool isBoxActive = false;
    bool isWaitingForInput = false;
    List<string> dialogueQueue = new List<string>();
    string cachedDialogue = string.Empty;
    System.Action storedCallback = null;

    public bool ShowDialogueBox(string dialogue) //Call this function to display the dialogue box. You can cache multiple lines by calling the function again while a box is active.
    {
        dialogueQueue.Add(dialogue);
        if (isBoxActive)
        {
            return false;
        }
        dialogueBoxBacking.enabled = true;
        textBox.enabled = true;
        isBoxActive = true;
        StartCoroutine(WriteToBox());
        return true;
    }

    public bool ShowDialogueBox(string dialogue, System.Action callbackMethod) //Call this function to display the dialogue box that will call back once completed. Pass in method name.
    {
        dialogueQueue.Add(dialogue);
        storedCallback = callbackMethod;
        if (isBoxActive)
        {
            return false;
        }

        dialogueBoxBacking.enabled = true;
        textBox.enabled = true;
        isBoxActive = true;
        StartCoroutine(WriteToBox());
        return true;
    }

    void Start()
    {
        dialogueBoxBacking.enabled = false;
        continueMarker.color = Color.clear;
        textBox.enabled = false;
    }

    IEnumerator WriteToBox() //write to the text box one character at a time and break when the text becomes too large. 
    {
        textBox.enabled = true;
        for(int j = 0; j < dialogueQueue.Count; j++)
        {
            cachedDialogue = dialogueQueue[j];
            textBox.text = string.Empty;
            string dialogueFeed = string.Empty;
            int lastIndex = 0;
            int i = 0;
            while (i < cachedDialogue.Length)
            {
                if (i == maxCharactersBeforeBreak + lastIndex)
                {
                    textBox.text += "...";
                    lastIndex = i;
                    StartCoroutine(WaitForInput());
                    while (isWaitingForInput)
                        yield return null;

                    textBox.text = string.Empty;
                }
                textBox.text += cachedDialogue[i++];
                yield return new WaitForSeconds(characterSpeed);
            }
            StartCoroutine(WaitForInput());
            while (isWaitingForInput)
                yield return null;
        }
        dialogueQueue.Clear();
        textBox.text = string.Empty;
        dialogueBoxBacking.enabled = false;
        cachedDialogue = string.Empty;
        isBoxActive = false;
        if (storedCallback != null)
            storedCallback();
        storedCallback = null;
        yield return null;

    }

    IEnumerator WaitForInput() //Wait for inputs before continuing.
    {
        isWaitingForInput = true;
        continueMarker.color = Color.white;
        while (true) //Wait for input to continue
        {
            foreach (Touch t in Input.touches)
            {
                if (t.tapCount > 0)
                    break;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                break;
            yield return null;
        }
        isWaitingForInput = false;
        continueMarker.color = Color.clear;
    }
}
