using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using GameSparks.Core;
using GameSparks.Api.Requests;
using System.Text;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking.Match;

// paste this to libraries - 

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    private InventoryItem[] inventoryItem;
    public static InventoryDisplay inventoryDisplay;

    public Vector3 pos;

    public List<string> ids = new List<string>();
    public List<EEquipmentType> equipmentType = new List<EEquipmentType>();

    private PlayerParty playerParty;

    private CurrencyManager currencyManager;

    private CurrencyUI currencyUI;

    private CharacterManager characterManager;

    private FOW fogOfWar;

    private GameController gameController;

    private MapGenerator mapGen;
    //private readonly object fileDownloadedCallback;

    //private GameSparksUnity gsUnity;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        //main
        if (Application.loadedLevel == 0)
        {
            StartCoroutine(AllowAutoAddParty());        
        }
        
        #region
/*
gsUnity = GetComponent<GameSparksUnity>();

GSRequestData jsonDataToSend = new GSRequestData(data.ToString());
LogEventRequest eventRequest = new GameSparks.Api.Requests.LogEventRequest().SetEventKey("JsonData").SetEventAttribute("JsonData", data.ToString()).SetMaxResponseTimeInSeconds(30);

eventRequest.Send((response) =>
{
    if (!response.HasErrors)
    {
        Debug.LogWarning("Player Saved to Gamesparks..");
    }
    else
    {
        Debug.LogError("Error Saving Player Data: " + response.Errors.JSON);
    }
});

new GetUploadUrlRequest().Send((response) => 
{
    StartCoroutine(UploadAFile(response.Url, "actor.json"));
});

new GetUploadedRequest().SetUploadId("").Send((response) =>
{
    StartCoroutine(DownloadFile(response.Url));
});

//jsonDataToSend.Add("actors.json", data);
//jsonDataToSend.Add("health", data.characterHealth0);
//new LogEventRequest().SetEventKey("setPlayerDataJSON").SetEventAttribute("JSONData", jsonDataToSend).Send((ActorData) => { });
*/
        #endregion
    }
    #region
    /*
    private IEnumerator UploadAFile(string uploadUrl, string encrytpedData)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(encrytpedData);

        WWWForm form = new WWWForm();
        form.AddBinaryData("json", bytes, "JsonData", "text/json");

        UnityWebRequest request = UnityWebRequest.Post(uploadUrl, form);
        yield return request.Send();

        if(request.error == null)
        {
            Debug.Log("[GS] Save file uploaded successfully");
        }
        else
        {
            Debug.LogError("[GS] Error uploading save file: " + request.error);
        }

        request.Dispose();
        request = null;
    }
    private IEnumerator DownloadFile(string url)
    {
        var fileRequest = new UnityWebRequest(url);
        if(fileRequest == null)
        {
            yield break;
        }
        fileRequest.downloadHandler = new DownloadHandlerBuffer();
        yield return fileRequest.Send();

        if(fileDownloadedCallback != null)
        {
            //
        }
    }*/
    #endregion


    IEnumerator AllowAutoAddParty()
    {
        yield return new WaitForSeconds(.31f);
        characterManager = FindObjectOfType<CharacterManager>();
        playerParty = FindObjectOfType<PlayerParty>();
        data.playerParty = FindObjectOfType<PlayerParty>();
        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
        inventoryItem = FindObjectsOfType<InventoryItem>();
        currencyManager = GetComponent<CurrencyManager>();
        currencyUI = FindObjectOfType<CurrencyUI>();
        fogOfWar = FindObjectOfType<FOW>();
    }


    public void StoreData()
    {
        #region scene main
        if (Application.loadedLevel == 0)
        {
            string dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
            dataPath = string.Empty;//attempt to clear on save

            //saved currencies
            data.goldValue += currencyManager.Gold.Value;
            data.scrapValue += currencyManager.Scrap.Value;
            data.foodValue += currencyManager.Food.Value;

            mapGen = FindObjectOfType<MapGenerator>();

            data.seed = mapGen.Seed;

            //stores item/ inventory info
            if(inventoryDisplay != null)
            {
                data.items = inventoryDisplay.items;
                foreach (InventoryItem inventoryItem in inventoryDisplay.items)
                {
                    data.ids.Add(inventoryItem.id);
                    //data.ids.Remove(inventoryItem.id);
                    data.itemTypes.Add(inventoryItem.itemType);
                    //data.itemTypes.Remove(inventoryItem.itemType);
                }
            }

           

            //Saves Character info
            //0
            data.characterName0 = characterManager.allCharacters[0].Name;
            data.characterLevel0 = characterManager.allCharacters[0].Level;
            data.characterHealth0 = characterManager.allCharacters[0].MaxHealth;
            data.characterStrength0 = characterManager.allCharacters[0].Strength;
            data.characterDexterity0 = characterManager.allCharacters[0].Dexterity;
            data.characterIntellect0 = characterManager.allCharacters[0].Intelect;
            data.characterExperience0 = characterManager.allCharacters[0].Experience;
            data.characterEquipCap0 = characterManager.allCharacters[0].EquipmentCapacity;
            data.characterType0 = characterManager.allCharacters[0].CharacterType;
            data.characterUnlocked0 = characterManager.allCharacters[0].isUnlocked;
            //1
            data.characterName1 = characterManager.allCharacters[1].Name;
            data.characterLevel1 = characterManager.allCharacters[1].Level;
            data.characterHealth1 = characterManager.allCharacters[1].MaxHealth;
            data.characterStrength1 = characterManager.allCharacters[1].Strength;
            data.characterDexterity1 = characterManager.allCharacters[1].Dexterity;
            data.characterIntellect1 = characterManager.allCharacters[1].Intelect;
            data.characterExperience1 = characterManager.allCharacters[1].Experience;
            data.characterEquipCap1 = characterManager.allCharacters[1].EquipmentCapacity;
            data.characterType1 = characterManager.allCharacters[1].CharacterType;
            data.characterUnlocked1 = characterManager.allCharacters[1].isUnlocked;
            //2
            data.characterName2 = characterManager.allCharacters[2].Name;
            data.characterLevel2 = characterManager.allCharacters[2].Level;
            data.characterHealth2 = characterManager.allCharacters[2].MaxHealth;
            data.characterStrength2 = characterManager.allCharacters[2].Strength;
            data.characterDexterity2 = characterManager.allCharacters[2].Dexterity;
            data.characterIntellect2 = characterManager.allCharacters[2].Intelect;
            data.characterExperience2 = characterManager.allCharacters[2].Experience;
            data.characterEquipCap2 = characterManager.allCharacters[2].EquipmentCapacity;
            data.characterType2 = characterManager.allCharacters[2].CharacterType;
            data.characterUnlocked2 = characterManager.allCharacters[2].isUnlocked;
            //3
            data.characterName3 = characterManager.allCharacters[3].Name;
            data.characterLevel3 = characterManager.allCharacters[3].Level;
            data.characterHealth3 = characterManager.allCharacters[3].MaxHealth;
            data.characterStrength3 = characterManager.allCharacters[3].Strength;
            data.characterDexterity3 = characterManager.allCharacters[3].Dexterity;
            data.characterIntellect3 = characterManager.allCharacters[3].Intelect;
            data.characterExperience3 = characterManager.allCharacters[3].Experience;
            data.characterEquipCap3 = characterManager.allCharacters[3].EquipmentCapacity;
            data.characterType3 = characterManager.allCharacters[3].CharacterType;
            data.characterUnlocked3 = characterManager.allCharacters[3].isUnlocked;


            //safty net of adding player to party since theres bug where he one gets deleted
            if (playerParty.characters[0] == null)
            {
                playerParty.characters[0] = characterManager.allCharacters[0];
            }
            if (playerParty.characters[1] == null)
            {
                playerParty.characters[1] = characterManager.allCharacters[1];
            }
            if (playerParty.characters[2] == null)
            {
                playerParty.characters[2] = characterManager.allCharacters[2];
            }


            //0
            if (data.characterName0 == playerParty.characters[0].Name)
            {
                data.characterInParty0 = true;
                data.character0PartyPosition = 0;
            }
            else if (data.characterName0 == playerParty.characters[1].Name)
            {
                data.characterInParty0 = true;
                data.character0PartyPosition = 1;
            }
            else if (data.characterName0 == playerParty.characters[2].Name)
            {
                data.characterInParty0 = true;
                data.character0PartyPosition = 2;
            }
            else
            {
                data.characterInParty0 = false;
                data.character0PartyPosition = -5;
            }
            //1
            if (data.characterName1 == playerParty.characters[0].Name)
            {
                data.characterInParty1 = true;
                data.character1PartyPosition = 0;
            }
            else if (data.characterName1 == playerParty.characters[1].Name)
            {
                data.characterInParty1 = true;
                data.character1PartyPosition = 1;
            }
            else if (data.characterName1 == playerParty.characters[2].Name)
            {
                data.characterInParty1 = true;
                data.character1PartyPosition = 2;
            }
            else
            {
                data.characterInParty1 = false;
                data.character1PartyPosition = -5;
            }          
            //2
            if (data.characterName2 == playerParty.characters[0].Name)
            {
                data.characterInParty2 = true;
                data.character2PartyPosition = 0;
            }
            else if (data.characterName2 == playerParty.characters[1].Name)
            {
                data.characterInParty2 = true;
                data.character2PartyPosition = 1;
            }
            else if (data.characterName2 == playerParty.characters[2].Name)
            {
                data.characterInParty2 = true;
                data.character2PartyPosition = 2;
            }
            else
            {
                data.characterInParty2 = false;
                data.character2PartyPosition = -5;
            }
            //3
            if (data.characterName3 == playerParty.characters[0].Name)
            {
                data.characterInParty3 = true;
                data.character3PartyPosition = 0;
            }
            else if (data.characterName3 == playerParty.characters[1].Name)
            {
                data.characterInParty3 = true;
                data.character3PartyPosition = 1;
            }
            else if (data.characterName3 == playerParty.characters[2].Name)
            {
                data.characterInParty3 = true;
                data.character3PartyPosition = 2;
            }
            else
            {
                data.characterInParty3 = false;
                data.character3PartyPosition = -5;
            }          
        }
        #endregion        
    }

    void LoadData()
    {
        LoadMainData();
        LoadTownData();       
    }

    public void LoadMainData()
    {
        if (Application.loadedLevel == 0)
        {
            //currencies loaded
            currencyManager = GetComponent<CurrencyManager>();
            currencyUI = FindObjectOfType<CurrencyUI>();
            currencyManager.Gold.Value = data.goldValue;
            currencyManager.Scrap.Value = data.scrapValue;
            currencyManager.Food.Value = data.foodValue;

            playerParty = FindObjectOfType<PlayerParty>();

            if(data.seed != 0)
            {
                mapGen = FindObjectOfType<MapGenerator>();
                mapGen.GenerateMap(data.seed);
            }
            

            inventoryDisplay = FindObjectOfType<InventoryDisplay>();
            //loads item/ inventory info
            if(data.items != null)
            {
                InventoryItem[] inSceneITems = FindObjectsOfType<InventoryItem>(); 
                /*foreach(InventoryItem item in inSceneITems)
                {
                    inventoryDisplay.items.Add(item);
                }*/
            }

            foreach (string id in data.ids)
            {
                ids.Add(id);
                ids.Clear();
            }
            foreach (EEquipmentType equip in data.itemTypes)
            {
                equipmentType.Add(equip);
                equipmentType.Clear();
            }


            characterManager = FindObjectOfType<CharacterManager>();
            //character 0
            characterManager.allCharacters[0].Name = data.characterName0;
            characterManager.allCharacters[0].Level = data.characterLevel0;
            characterManager.allCharacters[0].MaxHealth = data.characterHealth0;
            characterManager.allCharacters[0].Strength = data.characterStrength0;
            characterManager.allCharacters[0].Dexterity = data.characterDexterity0;
            characterManager.allCharacters[0].Intelect = data.characterIntellect0;
            characterManager.allCharacters[0].Experience = data.characterExperience0;
            characterManager.allCharacters[0].EquipmentCapacity = data.characterEquipCap0;
            characterManager.allCharacters[0].CharacterType = data.characterType0;
            characterManager.allCharacters[0].isUnlocked = data.characterUnlocked0;
            //character 1
            characterManager.allCharacters[1].Name = data.characterName1;
            characterManager.allCharacters[1].Level = data.characterLevel1;
            characterManager.allCharacters[1].MaxHealth = data.characterHealth1;
            characterManager.allCharacters[1].Strength = data.characterStrength1;
            characterManager.allCharacters[1].Dexterity = data.characterDexterity1;
            characterManager.allCharacters[1].Intelect = data.characterIntellect1;
            characterManager.allCharacters[1].Experience = data.characterExperience1;
            characterManager.allCharacters[1].EquipmentCapacity = data.characterEquipCap1;
            characterManager.allCharacters[1].CharacterType = data.characterType1;
            characterManager.allCharacters[1].isUnlocked = data.characterUnlocked1;
            //character 2
            characterManager.allCharacters[2].Name = data.characterName2;
            characterManager.allCharacters[2].Level = data.characterLevel2;
            characterManager.allCharacters[2].MaxHealth = data.characterHealth2;
            characterManager.allCharacters[2].Strength = data.characterStrength2;
            characterManager.allCharacters[2].Dexterity = data.characterDexterity2;
            characterManager.allCharacters[2].Intelect = data.characterIntellect2;
            characterManager.allCharacters[2].Experience = data.characterExperience2;
            characterManager.allCharacters[2].EquipmentCapacity = data.characterEquipCap2;
            characterManager.allCharacters[2].CharacterType = data.characterType2;
            characterManager.allCharacters[2].isUnlocked = data.characterUnlocked2;
            //character 3
            characterManager.allCharacters[3].Name = data.characterName3;
            characterManager.allCharacters[3].Level = data.characterLevel3;
            characterManager.allCharacters[3].MaxHealth = data.characterHealth3;
            characterManager.allCharacters[3].Strength = data.characterStrength3;
            characterManager.allCharacters[3].Dexterity = data.characterDexterity3;
            characterManager.allCharacters[3].Intelect = data.characterIntellect3;
            characterManager.allCharacters[3].Experience = data.characterExperience3;
            characterManager.allCharacters[3].EquipmentCapacity = data.characterEquipCap3;
            characterManager.allCharacters[3].CharacterType = data.characterType3;
            characterManager.allCharacters[3].isUnlocked = data.characterUnlocked3;

            //0
            characterManager.allCharacters[0].IsPartyMember = data.characterInParty0;
            if (characterManager.allCharacters[0].IsPartyMember == true)
            {
                characterManager.allCharacters[0].PartyPosition = data.character0PartyPosition;
                if (characterManager.allCharacters[0].PartyPosition >= 0 && characterManager.allCharacters[0].PartyPosition < 3)
                {
                    playerParty.AddPartyMember(characterManager.allCharacters[0].PartyPosition + 1, characterManager.allCharacters[0].Name);
                }
            }
            else
            {
                characterManager.allCharacters[0].PartyPosition = -1;
            }
            //1
            characterManager.allCharacters[1].IsPartyMember = data.characterInParty1;
            if (characterManager.allCharacters[1].IsPartyMember == true)
            {
                characterManager.allCharacters[1].PartyPosition = data.character1PartyPosition;
                if (characterManager.allCharacters[1].PartyPosition >= 0 && characterManager.allCharacters[1].PartyPosition < 4)
                {
                    playerParty.AddPartyMember(characterManager.allCharacters[1].PartyPosition + 1, characterManager.allCharacters[1].Name);
                }
            }
            else
            {
                characterManager.allCharacters[1].PartyPosition = -1;
            }
            //2
            characterManager.allCharacters[2].IsPartyMember = data.characterInParty2;
            if (characterManager.allCharacters[2].IsPartyMember == true)
            {
                characterManager.allCharacters[2].PartyPosition = data.character2PartyPosition;
                if (characterManager.allCharacters[2].PartyPosition >= 0 && characterManager.allCharacters[2].PartyPosition < 3)
                {
                    playerParty.AddPartyMember(characterManager.allCharacters[2].PartyPosition + 1, characterManager.allCharacters[2].Name);
                }
            }
            else
            {
                characterManager.allCharacters[2].PartyPosition = -1;
            }        
            //3
            characterManager.allCharacters[3].IsPartyMember = data.characterInParty3;
            if (characterManager.allCharacters[3].IsPartyMember == true)
            {
                characterManager.allCharacters[3].PartyPosition = data.character3PartyPosition;
                if (characterManager.allCharacters[3].PartyPosition >= 0 && characterManager.allCharacters[3].PartyPosition < 3)
                {
                    playerParty.AddPartyMember(characterManager.allCharacters[3].PartyPosition + 1, characterManager.allCharacters[3].Name);
                }
            }
            else
            {
                characterManager.allCharacters[3].PartyPosition = -1;
            }


            //safty net of adding player to party since theres bug where he one gets deleted
            if (playerParty.characters[0] == null)
            {
                playerParty.characters[0] = characterManager.allCharacters[0];
            }
            if (playerParty.characters[1] == null)
            {
                playerParty.characters[1] = characterManager.allCharacters[1];
            }
            if (playerParty.characters[2] == null)
            {
                playerParty.characters[2] = characterManager.allCharacters[2];
            }
        }
    }
    public void LoadTownData()
    {
        if (Application.loadedLevel == 1)
        {
            //currencies loaded
            currencyManager = GetComponent<CurrencyManager>();
            currencyUI = FindObjectOfType<CurrencyUI>();
            currencyManager.Gold.Value = data.goldValue;
            currencyManager.Scrap.Value = data.scrapValue;
            currencyManager.Food.Value = data.foodValue;

            data.playerParty = FindObjectOfType<PlayerParty>();
            playerParty = FindObjectOfType<PlayerParty>();

            //loads item/ inventory info

            foreach (string id in data.ids)
            {
          
                ids.Add(id);
            }
            foreach (EEquipmentType type in data.itemTypes)
            {
                equipmentType.Add(type);
            }

            characterManager = FindObjectOfType<CharacterManager>();
            //character 0
            characterManager.allCharacters[0].Name = data.characterName0;
            characterManager.allCharacters[0].Level = data.characterLevel0;
            characterManager.allCharacters[0].MaxHealth = data.characterHealth0;
            characterManager.allCharacters[0].Strength = data.characterStrength0;
            characterManager.allCharacters[0].Dexterity = data.characterDexterity0;
            characterManager.allCharacters[0].Intelect = data.characterIntellect0;
            characterManager.allCharacters[0].Experience = data.characterExperience0;
            characterManager.allCharacters[0].EquipmentCapacity = data.characterEquipCap0;
            characterManager.allCharacters[0].CharacterType = data.characterType0;
            characterManager.allCharacters[0].isUnlocked = data.characterUnlocked0;

            characterManager.allCharacters[0].IsPartyMember = data.characterInParty0;
            if (characterManager.allCharacters[0].IsPartyMember == true)
            {
                characterManager.allCharacters[0].PartyPosition = data.character0PartyPosition;
                if (characterManager.allCharacters[0].PartyPosition >= 0 && characterManager.allCharacters[0].PartyPosition < 3)
                {
                    playerParty.AddPartyMember(characterManager.allCharacters[0].PartyPosition + 1, characterManager.allCharacters[0].Name);
                }
            }
            else
            {
                characterManager.allCharacters[0].PartyPosition = -1;
            }


            //character 1
            characterManager.allCharacters[1].Name = data.characterName1;
            characterManager.allCharacters[1].Level = data.characterLevel1;
            characterManager.allCharacters[1].MaxHealth = data.characterHealth1;
            characterManager.allCharacters[1].Strength = data.characterStrength1;
            characterManager.allCharacters[1].Dexterity = data.characterDexterity1;
            characterManager.allCharacters[1].Intelect = data.characterIntellect1;
            characterManager.allCharacters[1].Experience = data.characterExperience1;
            characterManager.allCharacters[1].EquipmentCapacity = data.characterEquipCap1;
            characterManager.allCharacters[1].CharacterType = data.characterType1;
            characterManager.allCharacters[1].isUnlocked = data.characterUnlocked1;

            characterManager.allCharacters[1].IsPartyMember = data.characterInParty1;
            if (characterManager.allCharacters[1].IsPartyMember == true)
            {
                characterManager.allCharacters[1].PartyPosition = data.character1PartyPosition;
                if (characterManager.allCharacters[1].PartyPosition >= 0 && characterManager.allCharacters[1].PartyPosition < 4)
                {
                    playerParty.AddPartyMember(characterManager.allCharacters[1].PartyPosition + 1, characterManager.allCharacters[1].Name);
                }
            }
            else
            {
                characterManager.allCharacters[1].PartyPosition = -1;
            }

            //character 2
            characterManager.allCharacters[2].Name = data.characterName2;
            characterManager.allCharacters[2].Level = data.characterLevel2;
            characterManager.allCharacters[2].MaxHealth = data.characterHealth2;
            characterManager.allCharacters[2].Strength = data.characterStrength2;
            characterManager.allCharacters[2].Dexterity = data.characterDexterity2;
            characterManager.allCharacters[2].Intelect = data.characterIntellect2;
            characterManager.allCharacters[2].Experience = data.characterExperience2;
            characterManager.allCharacters[2].EquipmentCapacity = data.characterEquipCap2;
            characterManager.allCharacters[2].CharacterType = data.characterType2;
            characterManager.allCharacters[2].isUnlocked = data.characterUnlocked2;

            characterManager.allCharacters[2].IsPartyMember = data.characterInParty2;
            if (characterManager.allCharacters[2].IsPartyMember == true)
            {
                characterManager.allCharacters[2].PartyPosition = data.character2PartyPosition;
                if (characterManager.allCharacters[2].PartyPosition >= 0 && characterManager.allCharacters[2].PartyPosition < 3)
                {
                    playerParty.AddPartyMember(characterManager.allCharacters[2].PartyPosition + 1, characterManager.allCharacters[2].Name);
                }
            }
            else
            {
                characterManager.allCharacters[2].PartyPosition = -1;
            }

            //character 3
            characterManager.allCharacters[3].Name = data.characterName3;
            characterManager.allCharacters[3].Level = data.characterLevel3;
            characterManager.allCharacters[3].MaxHealth = data.characterHealth3;
            characterManager.allCharacters[3].Strength = data.characterStrength3;
            characterManager.allCharacters[3].Dexterity = data.characterDexterity3;
            characterManager.allCharacters[3].Intelect = data.characterIntellect3;
            characterManager.allCharacters[3].Experience = data.characterExperience3;
            characterManager.allCharacters[3].EquipmentCapacity = data.characterEquipCap3;
            characterManager.allCharacters[3].CharacterType = data.characterType3;
            characterManager.allCharacters[3].isUnlocked = data.characterUnlocked3;

            characterManager.allCharacters[3].IsPartyMember = data.characterInParty3;
            if (characterManager.allCharacters[3].IsPartyMember == true)
            {
                characterManager.allCharacters[3].PartyPosition = data.character3PartyPosition;
                if (characterManager.allCharacters[3].PartyPosition >= 0 && characterManager.allCharacters[3].PartyPosition < 3)
                {
                    playerParty.AddPartyMember(characterManager.allCharacters[3].PartyPosition + 1, characterManager.allCharacters[3].Name);
                }
            }
            else
            {
                characterManager.allCharacters[3].PartyPosition = -1;
            }
        }
    }

    public void ApplyData()
    {
        SaveData.AddActorData(data);
    }

    void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }
    void OnDisable()
    {
        SaveData.OnLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
}

[Serializable]
public class ActorData
{
    public List<string> ids = new List<string>();
    public List<InventoryItem> items = new List<InventoryItem>();
    public List<EEquipmentType> itemTypes = new List<EEquipmentType>();

    public Vector3 pos;

    public Transform targetTransform;

    //currencies
    public float goldValue;
    public float scrapValue;
    public float foodValue;

    public int firstRun = 0;

    public int seed;

    //player party statistics
    public PlayerParty playerParty;
    //npc 0
    public string characterName0;
    public int characterLevel0;
    public int characterHealth0;
    public int characterStrength0;
    public int characterDexterity0;
    public int characterIntellect0;
    public int characterExperience0;
    public int characterEquipCap0;
    public ECharacterType characterType0;
    public bool characterUnlocked0;
    public bool characterInParty0;
    public int character0PartyPosition;

    //npc 1
    public string characterName1;
    public int characterLevel1;
    public int characterHealth1;
    public int characterStrength1;
    public int characterDexterity1;
    public int characterIntellect1;
    public int characterExperience1;
    public int characterEquipCap1;
    public ECharacterType characterType1;
    public bool characterUnlocked1;
    public bool characterInParty1;
    public int character1PartyPosition;


    //npc 2
    public string characterName2;
    public int characterLevel2;
    public int characterHealth2;
    public int characterStrength2;
    public int characterDexterity2;
    public int characterIntellect2;
    public int characterExperience2;
    public int characterEquipCap2;
    public ECharacterType characterType2;
    public bool characterUnlocked2;
    public bool characterInParty2;
    public int character2PartyPosition;


    //npc 3
    public string characterName3;
    public int characterLevel3;
    public int characterHealth3;
    public int characterStrength3;
    public int characterDexterity3;
    public int characterIntellect3;
    public int characterExperience3;
    public int characterEquipCap3;
    public ECharacterType characterType3;
    public bool characterUnlocked3;
    public bool characterInParty3;
    public int character3PartyPosition;

}
