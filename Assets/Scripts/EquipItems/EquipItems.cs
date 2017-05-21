using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EquipItems : MonoBehaviour
{
    #region variables
    public Image itemSpriteColorSwap;
    private CharacterManager characterManager;
    private PlayerParty playerParty;
    private Actor actor;
    private InventoryItemDisplay inventoryItemDisplay;
    public int thisCharacterNumber;
    //0
    public bool equipedHelm0 = false;
    public bool equipedArmor0 = false;
    public bool equipedRightHand0 = false;
    public bool equipedLeftHand0 = false;
    public bool equipedAmulet0 = false;
    //1
    public bool equipedHelm1 = false;
    public bool equipedArmor1 = false;
    public bool equipedRightHand1 = false;
    public bool equipedLeftHand1 = false;
    public bool equipedAmulet1 = false;
    //2
    public bool equipedHelm2 = false;
    public bool equipedArmor2 = false;
    public bool equipedRightHand2 = false;
    public bool equipedLeftHand2 = false;
    public bool equipedAmulet2 = false;
    //3
    public bool equipedHelm3 = false;
    public bool equipedArmor3 = false;
    public bool equipedRightHand3 = false;
    public bool equipedLeftHand3 = false;
    public bool equipedAmulet3 = false;

    public bool itemIsEquiped = false;

    public EquipItems[] items;
    public EquipItems[] equipCheckItems;
    #endregion

    #region start & update
    void Start ()
    {
        characterManager = FindObjectOfType<CharacterManager>();
        playerParty = FindObjectOfType<PlayerParty>();
        inventoryItemDisplay = GetComponentInParent<InventoryItemDisplay>();
        items = FindObjectsOfType<EquipItems>();
    }

    void Update ()
    {
        items = FindObjectsOfType<EquipItems>();
    }
    #endregion

    #region Equiping and Unequiping armor, helmet, and amulet
    public void Equip_Unequip()
    {
        //Character 0 equiping
        if (thisCharacterNumber == 0)
        {
            #region equip/ unequip armor
            if (equipedArmor0 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[0].armor == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMOR)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;

                    itemIsEquiped = true;
                    equipedArmor0 = true;
                    equipedArmor1 = true;
                    equipedArmor2 = true;
                    equipedArmor3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedArmor0 = true;
                    }
                    foreach(EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Armor
            else if (equipedArmor0 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMOR)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedArmor0 = false;
                    equipedArmor1 = false;
                    equipedArmor2 = false;
                    equipedArmor3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedArmor0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip Helmet
            if (equipedHelm0 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[0].armor == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.HELMET)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedHelm0 = true;
                    equipedHelm1 = true;
                    equipedHelm2 = true;
                    equipedHelm3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedHelm0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Helmet
            else if (equipedHelm0 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.HELMET)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedHelm0 = false;
                    equipedHelm1 = false;
                    equipedHelm2 = false;
                    equipedHelm3 = false;
                    foreach (EquipItems item in items)
                    {
                        item.equipedHelm0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip amulet
            if (equipedAmulet0 == false && equipedAmulet1 == false && equipedAmulet2 == false && equipedAmulet3 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[0].amulet == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AMULET)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedAmulet0 = true;
                    equipedAmulet1 = true;
                    equipedAmulet2 = true;
                    equipedAmulet3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedAmulet0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Amulet
            else if (equipedAmulet0 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.AMULET)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedAmulet0 = false;
                    equipedAmulet1 = false;
                    equipedAmulet2 = false;
                    equipedAmulet3 = false;
                    foreach (EquipItems item in items)
                    {
                        item.equipedAmulet0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/ unequip rightHand
            if (equipedRightHand0 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AXE)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.MACE)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
            }
            //Unequip righthand
            else if (equipedRightHand0 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.AXE)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.MACE)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip leftHand
            if (equipedLeftHand0 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AXE)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.MACE)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[0].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
            }
            //Unequip righthand
            else if (equipedLeftHand0 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.AXE)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.MACE)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[0].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[0].Health = characterManager.allCharacters[0].MaxHealth;
                    characterManager.allCharacters[0].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[0].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[0].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand0 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion
        }
        //Character 1 equiping
        else if (thisCharacterNumber == 1)
        {
            #region equip/ unequip armor
            if (equipedArmor1 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[1].armor == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMOR)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;

                    itemIsEquiped = true;
                    equipedArmor0 = true;
                    equipedArmor1 = true;
                    equipedArmor2 = true;
                    equipedArmor3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedArmor1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Armor
            else if (equipedArmor1 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMOR)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedArmor0 = false;
                    equipedArmor1 = false;
                    equipedArmor2 = false;
                    equipedArmor3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedArmor1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip Helmet
            if (equipedHelm1 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[1].armor == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.HELMET)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedHelm0 = true;
                    equipedHelm1 = true;
                    equipedHelm2 = true;
                    equipedHelm3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedHelm1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Helmet
            else if (equipedHelm1 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.HELMET)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedHelm0 = false;
                    equipedHelm1 = false;
                    equipedHelm2 = false;
                    equipedHelm3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedHelm1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip amulet
            if (equipedAmulet1 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[1].amulet == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AMULET)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedAmulet0 = true;
                    equipedAmulet1 = true;
                    equipedAmulet2 = true;
                    equipedAmulet3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedAmulet1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Amulet
            else if (equipedAmulet1 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.AMULET)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedAmulet0 = false;
                    equipedAmulet1 = false;
                    equipedAmulet2 = false;
                    equipedAmulet3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedAmulet1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/ unequip rightHand
            if (equipedRightHand1 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AXE)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.MACE)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
            }
            //Unequip righthand
            else if (equipedRightHand1 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.AXE)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.MACE)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip leftHand
            if (equipedLeftHand1 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AXE)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.MACE)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[0].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[1].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[1].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
            }
            //Unequip righthand
            else if (equipedLeftHand0 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.AXE)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.MACE)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;


                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[1].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[1].Health = characterManager.allCharacters[1].MaxHealth;
                    characterManager.allCharacters[1].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[1].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[1].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand1 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion
        }

        else if (thisCharacterNumber == 2)
        {
            #region equip/ unequip armor
            if (equipedArmor2 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[2].armor == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMOR)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;

                    itemIsEquiped = true;
                    equipedArmor0 = true;
                    equipedArmor1 = true;
                    equipedArmor2 = true;
                    equipedArmor3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedArmor2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Armor
            else if (equipedArmor2 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMOR)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedArmor0 = false;
                    equipedArmor1 = false;
                    equipedArmor2 = false;
                    equipedArmor3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedArmor2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip Helmet
            if (equipedHelm2 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[2].armor == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.HELMET)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedHelm0 = true;
                    equipedHelm1 = true;
                    equipedHelm2 = true;
                    equipedHelm3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedHelm2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Helmet
            else if (equipedHelm2 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.HELMET)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedHelm0 = false;
                    equipedHelm1 = false;
                    equipedHelm2 = false;
                    equipedHelm3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedHelm2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip amulet
            if (equipedAmulet2 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[2].amulet == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AMULET)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedAmulet0 = true;
                    equipedAmulet1 = true;
                    equipedAmulet2 = true;
                    equipedAmulet3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedAmulet2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Amulet
            else if (equipedAmulet2 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.AMULET)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedAmulet0 = false;
                    equipedAmulet1 = false;
                    equipedAmulet2 = false;
                    equipedAmulet3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedAmulet2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/ unequip rightHand
            if (equipedRightHand2 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AXE)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.MACE)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
            }
            //Unequip righthand
            else if (equipedRightHand2 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.AXE)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.MACE)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip leftHand
            if (equipedLeftHand2 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AXE)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.MACE)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[2].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[2].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
            }
            //Unequip righthand
            else if (equipedLeftHand2 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.AXE)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.MACE)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;


                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[2].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[2].Health = characterManager.allCharacters[2].MaxHealth;
                    characterManager.allCharacters[2].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[2].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[2].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand2 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion
        }

        else if (thisCharacterNumber == 3)
        {
            #region equip/ unequip armor
            if (equipedArmor3 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[3].armor == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMOR)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;

                    itemIsEquiped = true;
                    equipedArmor0 = true;
                    equipedArmor1 = true;
                    equipedArmor2 = true;
                    equipedArmor3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedArmor3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Armor
            else if (equipedArmor3 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMOR)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;
                    equipedArmor0 = false;
                    equipedArmor1 = false;
                    equipedArmor2 = false;
                    equipedArmor3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedArmor3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip Helmet
            if (equipedHelm3 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[3].armor == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.HELMET)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedHelm0 = true;
                    equipedHelm1 = true;
                    equipedHelm2 = true;
                    equipedHelm3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedHelm3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Helmet
            else if (equipedHelm3 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.HELMET)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedHelm0 = false;
                    equipedHelm1 = false;
                    equipedHelm2 = false;
                    equipedHelm3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedHelm3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip amulet
            if (equipedAmulet3 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[3].amulet == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AMULET)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedAmulet0 = true;
                    equipedAmulet1 = true;
                    equipedAmulet2 = true;
                    equipedAmulet3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedAmulet3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }

                }
            }
            //Unequip Amulet
            else if (equipedAmulet3 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.AMULET)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedAmulet0 = false;
                    equipedAmulet1 = false;
                    equipedAmulet2 = false;
                    equipedAmulet3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedAmulet3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/ unequip rightHand
            if (equipedRightHand3 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AXE)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.MACE)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].rightHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;
                    equipedRightHand0 = true;
                    equipedRightHand1 = true;
                    equipedRightHand2 = true;
                    equipedRightHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
            }
            //Unequip righthand
            else if (equipedRightHand3 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.AXE)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.MACE)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedRightHand0 = false;
                    equipedRightHand1 = false;
                    equipedRightHand2 = false;
                    equipedRightHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedRightHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion


            #region equip/unequip leftHand
            if (equipedLeftHand3 == false && itemIsEquiped == false)
            {
                if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.AXE)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.MACE)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
                else if (characterManager.allCharacters[3].leftHand == null && inventoryItemDisplay.item.itemType ==
                EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[3].MaxHealth += inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength += inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity += inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect += inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.red;
                    itemIsEquiped = true;

                    equipedLeftHand0 = true;
                    equipedLeftHand1 = true;
                    equipedLeftHand2 = true;
                    equipedLeftHand3 = true;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = true;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = true;
                    }
                }
            }
            //Unequip righthand
            else if (equipedLeftHand3 == true && itemIsEquiped == true)
            {
                if (inventoryItemDisplay.item.itemType == EEquipmentType.SHIELD)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.ARMING_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.AXE)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.SHORT_BOW)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.LONG_BOW)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.GREAT_SWORD)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.MACE)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;


                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.DAGGER)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.CROSSBOW)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
                else if (inventoryItemDisplay.item.itemType == EEquipmentType.RAPIER)
                {
                    characterManager.allCharacters[3].MaxHealth -= inventoryItemDisplay.item.health;
                    characterManager.allCharacters[3].Health = characterManager.allCharacters[3].MaxHealth;
                    characterManager.allCharacters[3].Strength -= inventoryItemDisplay.item.strength;
                    characterManager.allCharacters[3].Dexterity -= inventoryItemDisplay.item.dexterity;
                    characterManager.allCharacters[3].Intelect -= inventoryItemDisplay.item.intellect;
                    Debug.Log("Item Dex : " + inventoryItemDisplay.item.dexterity);
                    itemSpriteColorSwap.color = Color.white;
                    itemIsEquiped = false;

                    equipedLeftHand0 = false;
                    equipedLeftHand1 = false;
                    equipedLeftHand2 = false;
                    equipedLeftHand3 = false;

                    foreach (EquipItems item in items)
                    {
                        item.equipedLeftHand3 = false;
                    }
                    foreach (EquipItems check in equipCheckItems)
                    {
                        check.itemIsEquiped = false;
                    }
                }
            }
            #endregion
        }

    }
    #endregion
}
