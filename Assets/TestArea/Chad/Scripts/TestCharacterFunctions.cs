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
        //Add and remove party members
        if (Input.GetKeyDown(KeyCode.Alpha1))
            playerParty.AddPartyMember(1, "Chad", (ECharacterType)Random.Range(0, 3), 100);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            playerParty.AddPartyMember(2, "John", (ECharacterType)Random.Range(0, 3), 100);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            playerParty.AddPartyMember(3, "Jane", (ECharacterType)Random.Range(0, 3), 100);

        else if (Input.GetKeyDown(KeyCode.Q))
            playerParty.RemovePartyMember(1);
        else if (Input.GetKeyDown(KeyCode.W))
            playerParty.RemovePartyMember(2);
        else if (Input.GetKeyDown(KeyCode.E))
            playerParty.RemovePartyMember(3);

        //Add and remove status effects
        if (Input.GetKeyDown(KeyCode.A))
        {
            Poisoned newPoison = new Poisoned();
            newPoison.buffType = EBuffType.POISONED;
            newPoison.statusName = "New Awesome Totaly Rad Poison Status Effect";
            newPoison.healthChange = 1;
            newPoison.strengthChange = 3;
            newPoison.expirationTime = 4;

            playerParty.AddStatusEffect(newPoison);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            playerParty.RemoveStatusEffect(EBuffType.POISONED);
        }    
    }
}
