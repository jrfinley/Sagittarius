using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using System.Text;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking.Match;
using System.IO;

// paste this to libraries - 

public class Actor : MonoBehaviour
{
    #region variables
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
    #endregion

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        //main
        if (Application.loadedLevel == 2)
        {
            StartCoroutine(AllowAutoAddParty());
        }
    }

    #region coroutine call
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
    #endregion

    #region Save Data
    public void StoreData()
    {
        characterManager = FindObjectOfType<CharacterManager>();
        playerParty = FindObjectOfType<PlayerParty>();
        data.playerParty = FindObjectOfType<PlayerParty>();
        currencyManager = GetComponent<CurrencyManager>();
        currencyUI = FindObjectOfType<CurrencyUI>();
        fogOfWar = FindObjectOfType<FOW>();

        string dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
        dataPath = string.Empty;//attempt to clear on save
                                //saved currencies
        data.goldValue += currencyManager.Gold.Value;
        data.scrapValue += currencyManager.Scrap.Value;
        data.foodValue += currencyManager.Food.Value;

        if (Application.loadedLevel == 2)
        {
            inventoryDisplay = FindObjectOfType<InventoryDisplay>();
            inventoryItem = FindObjectsOfType<InventoryItem>();

            mapGen = FindObjectOfType<MapGenerator>();

            data.seed = mapGen.Seed;

            //stores item/ inventory info
            if (inventoryDisplay != null)
            {
                data.items = inventoryDisplay.items;
                foreach (InventoryItem inventoryItems in inventoryDisplay.items)
                {
                    data.ids.Add(inventoryItems.id);
                    //data.ids.Remove(inventoryItem.id);
                    data.itemTypes.Add(inventoryItems.itemType);
                    //data.itemTypes.Remove(inventoryItem.itemType);
                }
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

        /*
          GameSparks, *NOTE: While gamesparks storage is working fine, i comment out this code during pushes because, if 
                       you don't start from gamesparks login scene, saving will give you errors, as it should, 
                       cause you are not able to save your info to the cloud if that is the case ;) 
        */

        #region GameSparks Code
        /*if (System.IO.File.Exists(Path.Combine(Application.persistentDataPath, "actors.json")))
        {
            GSRequestData DATA = new GSRequestData();
            Debug.Log("DATA: " + DATA.ToString());

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("actors")
                .SetEventAttribute("POS", data.pos.ToString())
                //currencies
                .SetEventAttribute("GOLD", (long)data.goldValue)
                .SetEventAttribute("SCRAP", (long)data.scrapValue)
                .SetEventAttribute("FOOD", (long)data.foodValue)
                //item info
                .SetEventAttribute("IDS", data.ids)
                .SetEventAttribute("ITEMS", data.items.ToString())
                //seed
                .SetEventAttribute("SEED", data.seed)
                //character 0 info
                .SetEventAttribute("CHARNAMEZERO", data.characterName0)
                .SetEventAttribute("CHARLEVELZERO", data.characterLevel0)
                .SetEventAttribute("CHARHealthZERO", data.characterHealth0)
                .SetEventAttribute("CHARSTRENGTHZERO", data.characterStrength0)
                .SetEventAttribute("CHARDEXTERITYZERO", data.characterDexterity0)
                .SetEventAttribute("CHARINTELLECTZERO", data.characterIntellect0)
                .SetEventAttribute("CHAREXPERIENCEZERO", data.characterExperience0)
                .SetEventAttribute("CHAREQUIPCAPZERO", data.characterEquipCap0)
                .SetEventAttribute("CHARUNLOCKEDZERO", data.characterUnlocked0.ToString())
                .SetEventAttribute("CHARINPARTYZERO", data.characterInParty0.ToString())
                .SetEventAttribute("CHARPARTYPOSITIONZERO", data.character0PartyPosition)
                //character 1 info
                .SetEventAttribute("CHARNAMEONE", data.characterName1)
                .SetEventAttribute("CHARLEVELONE", data.characterLevel1)
                .SetEventAttribute("CHARHealthONE", data.characterHealth1)
                .SetEventAttribute("CHARSTRENGTHONE", data.characterStrength1)
                .SetEventAttribute("CHARDEXTERITYONE", data.characterDexterity1)
                .SetEventAttribute("CHARINTELLECTONE", data.characterIntellect1)
                .SetEventAttribute("CHAREXPERIENCEONE", data.characterExperience1)
                .SetEventAttribute("CHAREQUIPCAPONE", data.characterEquipCap1)
                .SetEventAttribute("CHARUNLOCKEDONE", data.characterUnlocked1.ToString())
                .SetEventAttribute("CHARINPARTYONE", data.characterInParty1.ToString())
                .SetEventAttribute("CHARPARTYPOSITIONONE", data.character1PartyPosition)
                //character 2 info
                .SetEventAttribute("CHARNAMETWO", data.characterName2)
                .SetEventAttribute("CHARLEVELTWO", data.characterLevel2)
                .SetEventAttribute("CHARHealthTWO", data.characterHealth2)
                .SetEventAttribute("CHARSTRENGTHTWO", data.characterStrength2)
                .SetEventAttribute("CHARDEXTERITYTWO", data.characterDexterity2)
                .SetEventAttribute("CHARINTELLECTTWO", data.characterIntellect2)
                .SetEventAttribute("CHAREXPERIENCETWO", data.characterExperience2)
                .SetEventAttribute("CHAREQUIPCAPTWO", data.characterEquipCap2)
                .SetEventAttribute("CHARUNLOCKEDTWO", data.characterUnlocked2.ToString())
                .SetEventAttribute("CHARINPARTYTWO", data.characterInParty2.ToString())
                .SetEventAttribute("CHARPARTYPOSITIONTWO", data.character2PartyPosition)
                //character 3 info
                .SetEventAttribute("CHARNAMETHREE", data.characterName3)
                .SetEventAttribute("CHARLEVELTHREE", data.characterLevel3)
                .SetEventAttribute("CHARHealthTHREE", data.characterHealth3)
                .SetEventAttribute("CHARSTRENGTHTHREE", data.characterStrength3)
                .SetEventAttribute("CHARDEXTERITYTHREE", data.characterDexterity3)
                .SetEventAttribute("CHARINTELLECTTHREE", data.characterIntellect3)
                .SetEventAttribute("CHAREXPERIENCETHREE", data.characterExperience3)
                .SetEventAttribute("CHAREQUIPCAPTHREE", data.characterEquipCap3)
                .SetEventAttribute("CHARUNLOCKEDTHREE", data.characterUnlocked3.ToString())
                .SetEventAttribute("CHARINPARTYTHREE", data.characterInParty3.ToString())
                .SetEventAttribute("CHARPARTYPOSITIONTHREE", data.character3PartyPosition)

                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        string gsData = response.BaseData.GetString(DATA.ToString());
                        Debug.Log("my result is: " + gsData);
                    }
                    else
                    {
                        Debug.Log("There are errors " + response.Errors);
                    }
                });
        }*/
        #endregion
    }
    #endregion

    void LoadData()
    {
        LoadMainData();
        LoadTownData();       
    }

    #region Load Main Scene Data
    public void LoadMainData()
    {
        if (Application.loadedLevel == 2)
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
    #endregion

    #region Load Town Data
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
    #endregion

    #region Applying state of data
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
    #endregion
}

#region ActorData class, houses all the variables that get saved
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
#endregion