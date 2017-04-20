using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestCharacterFunctions : MonoBehaviour
{
    public int trainingGold,
               goldToUse;

    public PlayerParty playerParty;
    public CharacterManager characterManager;
    public CharacterTrainer characterTrainer;
    public CurrencyManager currencyManager;


    private Actor actor;


    private void Awake()
    {
        actor = FindObjectOfType<Actor>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        currencyManager.Gold.Value = trainingGold;

        Invoke("AutoAddPartyMembers", 0.2f); //Delay auto-add slightly due to race condition

    }

    void AutoAddPartyMembers()
    {
        playerParty.AddPartyMember(1, "Chad");
        playerParty.AddPartyMember(2, "John");
        playerParty.AddPartyMember(3, "Jane");
    }

    private void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        //Add and remove party members
        if (Input.GetKeyDown(KeyCode.Alpha1))
            playerParty.AddPartyMember(1, "Chad");
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            playerParty.AddPartyMember(2, "John");
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            playerParty.AddPartyMember(3, "Jane");

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

        //Add character to training area
        if (Input.GetKeyDown(KeyCode.O))
            characterTrainer.AddCharacter(characterManager.allCharacters[0], goldToUse);
    }
}
