using UnityEngine;
using System.Collections;

public class TestCharacterFunctions : MonoBehaviour
{
    public PlayerParty playerParty;

    private void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            playerParty.AddPartyMember(1, "Chad", (ECharacterType)Random.Range(0,3), 100);

        else if (Input .GetKeyDown(KeyCode.Alpha2))
            playerParty.AddPartyMember(2, "John", (ECharacterType)Random.Range(0, 3), 100);

        else if (Input.GetKeyDown(KeyCode.Alpha3))
            playerParty.AddPartyMember(3, "Jane", (ECharacterType)Random.Range(0, 3), 100);
    }
}
