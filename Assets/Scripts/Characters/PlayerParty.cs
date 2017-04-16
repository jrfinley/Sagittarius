﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    public int maxEquipmentLoad,
               equipmentLoad,
               maxPartySize;

    public float moveSpeed;
    public float moveXAmount;
    public float moveZAmount;

    public Vector3 movePosition;

    public BaseCharacter[] characters;

    public Rigidbody rb;

    [SerializeField]
    private int characterOneID;

    private Sprite icon;

    private CharacterManager characterManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characters = new BaseCharacter[maxPartySize];
        movePosition = transform.position;
        characterManager = FindObjectOfType<CharacterManager>(); 
    }

    /*
    This function is just brain storming for what might work when the dungeon gen is done
    
    public void NewSetMoveDirection(InputDirection inputDirection, Tile currentTile)
    {
        Vector3 oldPosition = transform.position;
        Hallway[] tileHallways = currentTile.hallways;
        Hallway selectedHallway;

        for (int i = 0; i < tileHallways.Length; i++)
        {
            if (tileHallways[i].direction == inputDirection)
            {
                selectedHallway = tileHallways[i];
                movePosition = selectedHallway.transform.position;
                StartCoroutine(MovePlayer());
            }
        }

        if (selectedHallway.hasBlocker)
        {
            //Do stat check stuff.
            if(failedStatCheck)
            {
                movePosition = oldPosition;
                StartCoroutine(MovePlayer());
            }
        }
    }
    */

    public void SetMoveDirection(Vector3 moveDirection)
    {
        if (transform.position != movePosition)
            return;

        Vector3 oldPosition = transform.position;

        if (moveDirection.z > 0)
        {
            movePosition.z += moveZAmount;
        }
        else if (moveDirection.z < 0)
        {
            movePosition.z -= moveZAmount;
        }
        else if (moveDirection.x > 0)
        {
            movePosition.x += moveXAmount;
        }
        else if (moveDirection.x < 0)
        {
            movePosition.x -= moveXAmount;
        }

        Collider[] moveSquares = Physics.OverlapSphere(movePosition, 1f);
        Debug.Log(moveSquares.Length);
        if (moveSquares.Length == 0)
        {
            movePosition = oldPosition;
            return;
        }

        StartCoroutine(MovePlayer());
    }

    public void AddPartyMember(int partyPosition, string name)
    {
        partyPosition = Mathf.Clamp(partyPosition, 1, maxPartySize);
        partyPosition -= 1;

        if (characters[partyPosition] != null)
            RemovePartyMember(partyPosition + 1);

        for (int i = 0; i < characterManager.allCharacters.Count; i++)
        {
            if (characterManager.allCharacters[i].Name == name)
            {
                if (!characterManager.allCharacters[i].isUnlocked)
                {
                    Debug.LogError("That character is not unlocked yet");
                    return;
                }

                characters[partyPosition] = characterManager.allCharacters[i];
                maxEquipmentLoad += characterManager.allCharacters[i].EquipmentCapacity;
                return;
            }
            else if (i == characterManager.allCharacters.Count - 1)
                Debug.Log("No character with that name exists.");
        }
    }
    public void RemovePartyMember(int partyPosition)
    {
        partyPosition = Mathf.Clamp(partyPosition, 1, maxPartySize);
        partyPosition -= 1;

        if (characters[partyPosition] == null)
            return;

        maxEquipmentLoad -= characters[partyPosition].EquipmentCapacity;
        characters[partyPosition] = null;
    }

    public void AddStatusEffect<T>(T statusEffect)where T : BaseStatusEffect
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != null)
                characters[i].AddStatusEffect(statusEffect);
        } 
    }
    public void AddStatusEffect<T>(T statusEffect, int partySlot)where T : BaseStatusEffect
    {
        partySlot = Mathf.Clamp(partySlot, 1, maxPartySize);
        partySlot -= 1;

        characters[partySlot].AddStatusEffect(statusEffect);
    }

    public void RemoveStatusEffect(EBuffType typeToRemove)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != null)
                characters[i].RemoveStatusEffect(typeToRemove);
        }
    }
    public void RemoveStatusEffect(EBuffType typeToRemove, int partySlot)
    {
        partySlot = Mathf.Clamp(partySlot, 1, maxPartySize);
        partySlot -= 1;

        characters[partySlot].RemoveStatusEffect(typeToRemove);
    }

    IEnumerator MovePlayer()
    {
		float loopCutoff = 0;
		Vector3 oldPosition = transform.position;
		
        while (transform.position != movePosition && loopCutoff < 5)
        {
            Vector3 moveDir = (movePosition - transform.position);

            if (moveDir.magnitude > 0.2f)
            {
                moveDir = moveDir.normalized * moveSpeed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + moveDir);
            }
            else
            {
                transform.position = movePosition;
            }
			
			loopCutoff += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
		
		if (loopCutoff >= 5)
		{
			transform.position = oldPosition;
			Debug.LogError("Move player while loop reached cut off time");
		}
    }

    //Properties
    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }
}
