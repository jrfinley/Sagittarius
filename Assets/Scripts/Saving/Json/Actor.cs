using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    public InventoryItemDisplay inventoryItemDisplayPrefab;

    private InventoryItem[] inventoryItem;
    public static InventoryDisplay inventoryDisplay;

    public Vector3 pos;

    public static Transform targetTransform;

    public List<int> ids = new List<int>();
    public List<EItemType> itemTypes = new List<EItemType>();

    public PlayerParty playerParty;

    public CurrencyManager currencyManager;

    public CurrencyUI currencyUI;

    public CharacterManager characterManager;

    public FOW fogOfWar;


    void Start()
    {
        characterManager = FindObjectOfType<CharacterManager>();
        playerParty = FindObjectOfType<PlayerParty>();
        data.playerParty = FindObjectOfType<PlayerParty>();
        inventoryDisplay = FindObjectOfType<InventoryDisplay>();
        inventoryItem = FindObjectsOfType<InventoryItem>();
        currencyManager = GetComponent<CurrencyManager>();
        currencyUI = FindObjectOfType<CurrencyUI>();
        Debug.Log("Gold: " + currencyManager.Gold.Value);
        Debug.Log("Scrap: " + currencyManager.Scrap.Value);
        Debug.Log("Food: " + currencyManager.Food.Value);    
    }

    public void StoreData()
    {
        //saved currencies
        data.goldValue += currencyManager.Gold.Value;
        data.scrapValue += currencyManager.Scrap.Value;
        data.foodValue += currencyManager.Food.Value;

        //stores item/ inventory info
        data.items = inventoryDisplay.items;

        foreach(InventoryItem inventoryItem in inventoryDisplay.items)
        {
            //data.inventoryItemDisplayPrefab = inventoryItemDisplayPrefab;
            //data.targetTransform = targetTransform;
            //data.inventoryItemDisplayPrefab = inventoryItemDisplayPrefab;
            //data.targetTransform = targetTransform;
            data.ids.Add(inventoryItem.id);
            data.itemTypes.Add(inventoryItem.itemType);
            Debug.Log("inventoryItemID = " + inventoryItem.id);
            Debug.Log("inventoryItemType = " + inventoryItem.itemType);

        }

        #region
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
        #endregion
    }

    void LoadData()
    {
        if (this.gameObject.GetComponent<DestroyOnLoad>())
        {
            Destroy(this.gameObject);
        }

        //currencies loaded
        currencyManager = GetComponent<CurrencyManager>();
        currencyUI = FindObjectOfType<CurrencyUI>();
        currencyManager.Gold.Value = data.goldValue;
        currencyManager.Scrap.Value = data.scrapValue;
        currencyManager.Food.Value = data.foodValue;
        Debug.Log("gold: " + currencyManager.Gold.Value);
        Debug.Log("scrap: " + currencyManager.Scrap.Value);
        Debug.Log("food: " + currencyManager.Food.Value);

        data.playerParty = FindObjectOfType<PlayerParty>();
        playerParty = FindObjectOfType<PlayerParty>();

        //loads item/ inventory info
        inventoryDisplay.items = data.items;

        foreach (int id in data.ids)
        {
            #region
            //inventoryItemDisplayPrefab = data.inventoryItemDisplayPrefab;
            //InventoryItemDisplay display = (InventoryItemDisplay)Instantiate(data.inventoryItemDisplayPrefab);
            //targetTransform = data.targetTransform;
            //display.transform.SetParent(targetTransform, false);
            //display.Prime(inventoryItem);
            #endregion
            ids.Add(id);
            Debug.Log("inventoryItemID = " + id.ToString());
        }
        foreach(EItemType itemType in data.itemTypes)
        {
            itemTypes.Add(itemType);
            Debug.Log("InventoryItemType = " + itemType.ToString());
        }
        

        #region
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
        #endregion
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
        SaveData.OnBeforeSave += ApplyData;
    }
}

[Serializable]
public class ActorData
{
    //public InventoryItemDisplay inventoryItemDisplayPrefab;

    public List<int> ids = new List<int>();
    public List<InventoryItem> items = new List<InventoryItem>();
    public List<EItemType> itemTypes = new List<EItemType>();

    public Vector3 pos;

    public Transform targetTransform;

    //currencies
    public float goldValue;
    public float scrapValue;
    public float foodValue;



    #region
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
    #endregion
}
