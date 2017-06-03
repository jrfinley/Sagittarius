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
using GameSparks.Api.Messages;
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

    private EquipItems[] equipItems;
    #endregion

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        //main

        StartCoroutine(AllowAutoAddParty());
    }

    #region coroutine call
    IEnumerator AllowAutoAddParty()
    {
        yield return new WaitForSeconds(.31f);
        if(Application.loadedLevel == 2)
        {
            characterManager = FindObjectOfType<CharacterManager>();
            playerParty = FindObjectOfType<PlayerParty>();
            data.playerParty = FindObjectOfType<PlayerParty>();
            inventoryDisplay = FindObjectOfType<InventoryDisplay>();
            inventoryItem = FindObjectsOfType<InventoryItem>();
            currencyManager = GetComponent<CurrencyManager>();
            currencyUI = FindObjectOfType<CurrencyUI>();
            fogOfWar = FindObjectOfType<FOW>();
            equipItems = FindObjectsOfType<EquipItems>();
        }
        else if(Application.loadedLevel == 1)
        {
            characterManager = FindObjectOfType<CharacterManager>();
            playerParty = FindObjectOfType<PlayerParty>();
            currencyManager = GetComponent<CurrencyManager>();
            currencyUI = FindObjectOfType<CurrencyUI>();
        }

    }
    #endregion

    #region Save Data
    public void StoreData()
    {
        //Unequip equiped items
        EquipItems[] equipItems = FindObjectsOfType<EquipItems>();
        foreach (EquipItems itemsToUnequip in equipItems)
        {
            if (itemsToUnequip.itemIsEquiped == true)
            {
                itemsToUnequip.Equip_Unequip();
            }
        }
        //character training
        CharacterTrainer trainingStruct = FindObjectOfType<CharacterTrainer>();
        if(characterManager.allCharacters[0].IsTraining == true)
        {
            data.characterIsTraning0 = true;
            data.characterTraining0Time = trainingStruct.trainingCharacters[0].endTime;
            data.healthIncrease0 = trainingStruct.trainingCharacters[0].healthIncrease;
            data.dexterityIncrease0 = trainingStruct.trainingCharacters[0].dexterityIncrease;
            data.strengthIncrease0 = trainingStruct.trainingCharacters[0].strengthIncrease;
            data.intellectIncrease0 = trainingStruct.trainingCharacters[0].intelectIncrease;
        }
        if (characterManager.allCharacters[1].IsTraining == true)
        {
            data.characterIsTraning1 = true;
            data.characterTraining1Time = trainingStruct.trainingCharacters[1].endTime;
            data.healthIncrease1 = trainingStruct.trainingCharacters[1].healthIncrease;
            data.dexterityIncrease1 = trainingStruct.trainingCharacters[1].dexterityIncrease;
            data.strengthIncrease1 = trainingStruct.trainingCharacters[1].strengthIncrease;
            data.intellectIncrease1 = trainingStruct.trainingCharacters[1].intelectIncrease;
        }
        if (characterManager.allCharacters[2].IsTraining == true)
        {
            data.characterIsTraning2 = true;
            data.characterTraining2Time = trainingStruct.trainingCharacters[2].endTime;
            data.healthIncrease2 = trainingStruct.trainingCharacters[2].healthIncrease;
            data.dexterityIncrease2 = trainingStruct.trainingCharacters[2].dexterityIncrease;
            data.strengthIncrease2 = trainingStruct.trainingCharacters[2].strengthIncrease;
            data.intellectIncrease2 = trainingStruct.trainingCharacters[2].intelectIncrease;
        }
        if (characterManager.allCharacters[3].IsTraining == true)
        {
            data.characterIsTraning3 = true;
            data.characterTraining3Time = trainingStruct.trainingCharacters[3].endTime;
            data.healthIncrease3 = trainingStruct.trainingCharacters[3].healthIncrease;
            data.dexterityIncrease3 = trainingStruct.trainingCharacters[3].dexterityIncrease;
            data.strengthIncrease3 = trainingStruct.trainingCharacters[3].strengthIncrease;
            data.intellectIncrease3 = trainingStruct.trainingCharacters[3].intelectIncrease;
        }

        string dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
        dataPath = string.Empty;//attempt to clear on save

        data.goldValue += currencyManager.Gold.Value;
        data.scrapValue += currencyManager.Scrap.Value;
        data.foodValue += currencyManager.Food.Value;

        if (Application.loadedLevel == 2)
        {         
            mapGen = FindObjectOfType<MapGenerator>();

            data.seed = mapGen.Seed;

            //inventoryDisplay = FindObjectOfType<InventoryDisplay>();
            //inventoryItem = FindObjectsOfType<InventoryItem>();

            //stores item/ inventory info
            if (inventoryDisplay != null)
            {
                data.items = inventoryDisplay.items;
                foreach (InventoryItem inventoryItem in inventoryDisplay.items)
                {
                    data.ids.Add(inventoryItem.id);
                    //data.ids.Remove(inventoryItem.id);
                    data.itemTypes.Add(inventoryItem.itemType);
                    //data.itemTypes.Remove(inventoryItem.itemType);
                    Debug.Log("Saved items");
                }
            }

            
            //status effects
            if (playerParty.characters[0] != null)
            {
                if (playerParty.characters[0].hasStatusEffect == true)
                {
                    data.hasStatusEffectCharacter0 = true;
                    data.statusEffectsOnCharacter0 = playerParty.characters[0].statusEffects;
                }
            }
            if (playerParty.characters[1] != null)
            {
                if (playerParty.characters[1].hasStatusEffect == true)
                {
                    data.hasStatusEffectCharacter1 = true;
                    data.statusEffectsOnCharacter1 = playerParty.characters[1].statusEffects;
                }
            }
            if (playerParty.characters[2] != null)
            {
                if (playerParty.characters[2].hasStatusEffect == true)
                {
                    data.hasStatusEffectCharacter2 = true;
                    data.statusEffectsOnCharacter2 = playerParty.characters[2].statusEffects;
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
        StoreGameSparksData();
    }
    #endregion

    void LoadData()
    {
        LoadMainData();
        LoadTownData();

        CharacterTrainer trainingStruct = FindObjectOfType<CharacterTrainer>();
        if (data.characterIsTraning0 == true)
        {
            trainingStruct.LoadCharacter(characterManager.allCharacters[0], data.characterTraining0Time,
                data.healthIncrease0, data.dexterityIncrease0, data.strengthIncrease0, data.intellectIncrease0);
        }
        if (data.characterIsTraning1 == true)
        {
            trainingStruct.LoadCharacter(characterManager.allCharacters[1], data.characterTraining1Time,
                data.healthIncrease1, data.dexterityIncrease1, data.strengthIncrease1, data.intellectIncrease1);
        }
        if (data.characterIsTraning2 == true)
        {
            trainingStruct.LoadCharacter(characterManager.allCharacters[2], data.characterTraining2Time,
                data.healthIncrease2, data.dexterityIncrease2, data.strengthIncrease2, data.intellectIncrease2);
        }
        if (data.characterIsTraning3 == true)
        {
            trainingStruct.LoadCharacter(characterManager.allCharacters[3], data.characterTraining3Time,
                data.healthIncrease3, data.dexterityIncrease3, data.strengthIncrease3, data.intellectIncrease3);
        }
    }

    void StoreGameSparksData()
    {
        /*
          GameSparks, *NOTE: While gamesparks storage is working fine, i comment out this code during pushes because, if 
                       you don't start from gamesparks login scene, saving will give you errors, as it should, 
                       cause you are not able to save your info to the cloud if that is the case ;) 
        */
        #region GameSparks Code
        /*
        if (System.IO.File.Exists(Path.Combine(Application.persistentDataPath, "actors.json")))
        {
            GSRequestData jsonDataToSend = new GSRequestData();

            jsonDataToSend.Add("POS", data.pos.ToString());
            jsonDataToSend.Add("GOLD", (long)data.goldValue);
            jsonDataToSend.Add("SCRAP", (long)data.scrapValue);
            jsonDataToSend.Add("FOOD", (long)data.foodValue);
            jsonDataToSend.Add("IDS", data.ids);
            jsonDataToSend.Add("ITEMS", data.items.ToString());
            jsonDataToSend.Add("SEED", data.seed);
            jsonDataToSend.Add("CHARNAMEZERO", data.characterName0);
            jsonDataToSend.Add("CHARLEVELZERO", data.characterLevel0);
            jsonDataToSend.Add("CHARHealthZERO", data.characterHealth0);
            jsonDataToSend.Add("CHARSTRENGTHZERO", data.characterStrength0);
            jsonDataToSend.Add("CHARDEXTERITYZERO", data.characterDexterity0);
            jsonDataToSend.Add("CHARINTELLECTZERO", data.characterIntellect0);
            jsonDataToSend.Add("CHAREXPERIENCEZERO", data.characterExperience0);
            jsonDataToSend.Add("CHAREQUIPCAPZERO", data.characterEquipCap0);
            jsonDataToSend.Add("CHARUNLOCKEDZERO", data.characterUnlocked0.ToString());
            jsonDataToSend.Add("CHARINPARTYZERO", data.characterInParty0.ToString());
            jsonDataToSend.Add("CHARPARTYPOSITIONZERO", data.character0PartyPosition);

            jsonDataToSend.Add("CHARNAMEONE", data.characterName1);
            jsonDataToSend.Add("CHARLEVELONE", data.characterLevel1);
            jsonDataToSend.Add("CHARHealthONE", data.characterHealth1);
            jsonDataToSend.Add("CHARSTRENGTHONE", data.characterStrength1);
            jsonDataToSend.Add("CHARDEXTERITYONE", data.characterDexterity1);
            jsonDataToSend.Add("CHARINTELLECTONE", data.characterIntellect1);
            jsonDataToSend.Add("CHAREXPERIENCEONE", data.characterExperience1);
            jsonDataToSend.Add("CHAREQUIPCAPONE", data.characterEquipCap1);
            jsonDataToSend.Add("CHARUNLOCKEDONE", data.characterUnlocked1.ToString());
            jsonDataToSend.Add("CHARINPARTYONE", data.characterInParty1.ToString());
            jsonDataToSend.Add("CHARPARTYPOSITIONONE", data.character1PartyPosition);

            jsonDataToSend.Add("CHARNAMETWO", data.characterName2);
            jsonDataToSend.Add("CHARLEVELTWO", data.characterLevel2);
            jsonDataToSend.Add("CHARHealthTWO", data.characterHealth2);
            jsonDataToSend.Add("CHARSTRENGTHTWO", data.characterStrength2);
            jsonDataToSend.Add("CHARDEXTERITYTWO", data.characterDexterity2);
            jsonDataToSend.Add("CHARINTELLECTTWO", data.characterIntellect2);
            jsonDataToSend.Add("CHAREXPERIENCETWO", data.characterExperience2);
            jsonDataToSend.Add("CHAREQUIPCAPTWO", data.characterEquipCap2);
            jsonDataToSend.Add("CHARUNLOCKEDTWO", data.characterUnlocked2.ToString());
            jsonDataToSend.Add("CHARINPARTYTWO", data.characterInParty2.ToString());
            jsonDataToSend.Add("CHARPARTYPOSITIONTWO", data.character2PartyPosition);

            jsonDataToSend.Add("CHARNAMETWO", data.characterName2);
            jsonDataToSend.Add("CHARLEVELTWO", data.characterLevel2);
            jsonDataToSend.Add("CHARHealthTWO", data.characterHealth2);
            jsonDataToSend.Add("CHARSTRENGTHTWO", data.characterStrength2);
            jsonDataToSend.Add("CHARDEXTERITYTWO", data.characterDexterity2);
            jsonDataToSend.Add("CHARINTELLECTTWO", data.characterIntellect2);
            jsonDataToSend.Add("CHAREXPERIENCETWO", data.characterExperience2);
            jsonDataToSend.Add("CHAREQUIPCAPTWO", data.characterEquipCap2);
            jsonDataToSend.Add("CHARUNLOCKEDTWO", data.characterUnlocked2.ToString());
            jsonDataToSend.Add("CHARINPARTYTWO", data.characterInParty2.ToString());
            jsonDataToSend.Add("CHARPARTYPOSITIONTWO", data.character2PartyPosition);

            jsonDataToSend.Add("CHARNAMETHREE", data.characterName3);
            jsonDataToSend.Add("CHARLEVELTHREE", data.characterLevel3);
            jsonDataToSend.Add("CHARHealthTHREE", data.characterHealth3);
            jsonDataToSend.Add("CHARSTRENGTHTHREE", data.characterStrength3);
            jsonDataToSend.Add("CHARDEXTERITYTHREE", data.characterDexterity3);
            jsonDataToSend.Add("CHARINTELLECTTHREE", data.characterIntellect3);
            jsonDataToSend.Add("CHAREXPERIENCETHREE", data.characterExperience3);
            jsonDataToSend.Add("CHAREQUIPCAPTHREE", data.characterEquipCap3);
            jsonDataToSend.Add("CHARUNLOCKEDTHREE", data.characterUnlocked3.ToString());
            jsonDataToSend.Add("CHARINPARTYTHREE", data.characterInParty3.ToString());
            jsonDataToSend.Add("CHARPARTYPOSITIONTHREE", data.character3PartyPosition);

            new LogEventRequest().SetEventKey("getPlayerData")
                .SetEventAttribute("jsonData", jsonDataToSend)
                .Send((response) =>
                {
                    if (response.HasErrors)
                    {

                    }
                    else
                    {
                        Debug.Log("Reponse Script Error :  " + response.ScriptData.GetGSData("container").GetGSDataList(jsonDataToSend.JSON)); 
                        //Debug.Log("GameSparks gold Value: " + response.ScriptData.GetNumber("GOLD").HasValue);
                        //data.goldValue = (float)jsonDataToSend.GetNumber("GOLD");
                    }

                });
        }
        else
        {
            Debug.Log("Continue without Gamesparks Save");
        }
        */
        #endregion
    }

    public void GetGameSparksdata()
    {
        
    }

    #region Load Main Scene Data
    public void LoadMainData()
    {
        //load character info in both scenes
        characterManager = FindObjectOfType<CharacterManager>();
        playerParty = FindObjectOfType<PlayerParty>();
        data.playerParty = FindObjectOfType<PlayerParty>();
        //character 0
        characterManager.allCharacters[0].Name = data.characterName0;
        characterManager.allCharacters[0].Level = data.characterLevel0 - 1;
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
        characterManager.allCharacters[1].Level = data.characterLevel1 - 1;
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
        characterManager.allCharacters[2].Level = data.characterLevel2 - 1;
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
        characterManager.allCharacters[3].Level = data.characterLevel3 - 1;
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
        if (Application.loadedLevel == 2)
        {
            //currencies loaded
            currencyManager = GetComponent<CurrencyManager>();
            currencyUI = FindObjectOfType<CurrencyUI>();
            currencyManager.Gold.Value = data.goldValue;
            currencyManager.Scrap.Value = data.scrapValue;
            currencyManager.Food.Value = data.foodValue;


            if (data.seed != 0)
            {
                mapGen = FindObjectOfType<MapGenerator>();
                mapGen.GenerateMap(data.seed);
            }


            inventoryDisplay = FindObjectOfType<InventoryDisplay>();
            //loads item/ inventory info
            if (data.items != null)
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
            //re-attach status effects
            if (data.hasStatusEffectCharacter0 == true)
            {
                playerParty.characters[0].hasStatusEffect = true;
                playerParty.characters[0].InitializeStatusEffects(data.statusEffectsOnCharacter0);
                data.hasStatusEffectCharacter0 = false;
            }

            if (data.hasStatusEffectCharacter1 == true)
            {
                playerParty.characters[1].hasStatusEffect = true;
                playerParty.characters[1].InitializeStatusEffects(data.statusEffectsOnCharacter1);
                data.hasStatusEffectCharacter1 = false;
            }
            if (data.hasStatusEffectCharacter2 == true)
            {
                playerParty.characters[2].hasStatusEffect = true;
                playerParty.characters[2].InitializeStatusEffects(data.statusEffectsOnCharacter2);
                data.hasStatusEffectCharacter2 = false;
            }
            #region
            //re-attach status effects
            StatusEffectManager statusEffectManager = FindObjectOfType<StatusEffectManager>();
            /*
            if (data.hasStatusEffectCharacter0 == true)
            {
                playerParty.characters[0].hasStatusEffect = true;
                if(data.statusEffectsOnCharacter0[0] == 0)
                {
                    statusEffectManager.AddStatusEffect(playerParty.characters[0], 0);
                }
                else if (data.statusEffectsOnCharacter0[0] == 1)
                {
                    statusEffectManager.AddStatusEffect(playerParty.characters[0], 1);
                }

                if (data.statusEffectsOnCharacter0[1] == 0)
                {
                    statusEffectManager.AddStatusEffect(playerParty.characters[0], 0);

                } 
                else if(data.statusEffectsOnCharacter0[1] == 1)
                {
                    statusEffectManager.AddStatusEffect(playerParty.characters[0], 1);
                }
                data.hasStatusEffectCharacter0 = false;            
            }          
            if (data.hasStatusEffectCharacter1 == true)
            {
                playerParty.characters[1].hasStatusEffect = true;
                if (data.statusEffectsOnCharacter1[0] == 0 || data.statusEffectsOnCharacter1[1] == 0)
                {
                    statusEffectManager.AddStatusEffect(playerParty.characters[1], 0);
                }
                else if (data.statusEffectsOnCharacter1[0] == 1 || data.statusEffectsOnCharacter1[1] == 1)
                {
                    statusEffectManager.AddStatusEffect(playerParty.characters[1], 1);
                }
                data.hasStatusEffectCharacter1 = false;
            }
            if (data.hasStatusEffectCharacter2 == true)
            {
                playerParty.characters[2].hasStatusEffect = true;
                if (data.statusEffectsOnCharacter2[0] == 0 || data.statusEffectsOnCharacter2[1] == 0)
                {
                    statusEffectManager.AddStatusEffect(playerParty.characters[2], 0);
                }
                else if (data.statusEffectsOnCharacter2[0] == 1 || data.statusEffectsOnCharacter2[1] == 1)
                {
                    statusEffectManager.AddStatusEffect(playerParty.characters[2], 1);
                }
                data.hasStatusEffectCharacter2 = false;
            }
            */
            #endregion
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

            //loads item/ inventory info

            foreach (string id in data.ids)
            {

                ids.Add(id);
            }
            foreach (EEquipmentType type in data.itemTypes)
            {
                equipmentType.Add(type);
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

    //public string userId;

    //player party statistics
    public PlayerParty playerParty;

    public bool hasStatusEffectCharacter2;
    public List<int> statusEffectsOnCharacter2 = new List<int>();
    public bool hasStatusEffectCharacter1;
    public List<int> statusEffectsOnCharacter1 = new List<int>();
    public bool hasStatusEffectCharacter0;
    public List<int> statusEffectsOnCharacter0 = new List<int>();

    //character 0 training info
    public DateTime characterTraining0Time;
    public bool characterIsTraning0;
    public int healthIncrease0;
    public int dexterityIncrease0;
    public int strengthIncrease0;
    public int intellectIncrease0;

    //character 1 training info
    public DateTime characterTraining1Time;
    public bool characterIsTraning1;
    public int healthIncrease1;
    public int dexterityIncrease1;
    public int strengthIncrease1;
    public int intellectIncrease1;

    //character 1 training info
    public DateTime characterTraining2Time;
    public bool characterIsTraning2;
    public int healthIncrease2;
    public int dexterityIncrease2;
    public int strengthIncrease2;
    public int intellectIncrease2;

    //character 1 training info
    public DateTime characterTraining3Time;
    public bool characterIsTraning3;
    public int healthIncrease3;
    public int dexterityIncrease3;
    public int strengthIncrease3;
    public int intellectIncrease3;

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