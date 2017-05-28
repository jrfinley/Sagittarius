using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestCharacterFunctions : MonoBehaviour
{
    public enum TestModes { Characters, Status_Effects, Character_Trainer }

    public TestModes testMode;

    public int trainingGold,
               goldToUse;

    [Header("Time to train in hours")]
    public float timeToTrain;

    public PlayerParty playerParty;
    public CharacterManager characterManager;
    public CharacterTrainer characterTrainer;
    public CurrencyManager currencyManager;
    public StatusEffectManager statusEffectManager;


    private Actor actor;

    private void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>();

        Invoke("AutoAddPartyMembers", 0.2f); //Delay auto-add slightly due to race condition
        StartCoroutine(ReturnFindObjects());
    }
    IEnumerator ReturnFindObjects()
    {
        yield return new WaitForSeconds(2f);
        currencyManager = FindObjectOfType<CurrencyManager>();
        actor = FindObjectOfType<Actor>();
        characterTrainer = FindObjectOfType<CharacterTrainer>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(actor != null)
        {
            
        }
        currencyManager.Gold.Value = trainingGold;
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
        if (testMode == TestModes.Characters)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                playerParty.AddPartyMember(1, "Chad");
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                playerParty.AddPartyMember(2, "John");
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                playerParty.AddPartyMember(3, "Jane");

            else if (Input.GetKeyDown(KeyCode.Z))
                playerParty.RemovePartyMember(1);
            else if (Input.GetKeyDown(KeyCode.X))
                playerParty.RemovePartyMember(2);
            else if (Input.GetKeyDown(KeyCode.C))
                playerParty.RemovePartyMember(3);
        }

        //Add Status Effects
        if (testMode == TestModes.Status_Effects)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                statusEffectManager.AddStatusEffect(playerParty.characters[0], 0);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                statusEffectManager.AddStatusEffect(playerParty.characters[0], 1);
        }

        //Add character to training area
        if (testMode == TestModes.Character_Trainer)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                characterTrainer.AddCharacter(characterManager.allCharacters[4], timeToTrain, goldToUse, 1, 1, 1, 1);
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                characterTrainer.AddCharacter(characterManager.allCharacters[1], timeToTrain, goldToUse, 1, 1, 1, 1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                characterTrainer.AddCharacter(characterManager.allCharacters[2], timeToTrain, goldToUse, 1, 1, 1, 1);

            if (characterTrainer.trainingCharacters.Count > 0)
                print(characterTrainer.trainingCharacters[0].character.Name);
        }
    }
}
