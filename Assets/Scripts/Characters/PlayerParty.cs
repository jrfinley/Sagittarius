using System.Collections;
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
    private Sprite icon;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characters = new BaseCharacter[maxPartySize];
    }

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

        StartCoroutine(MovePlayer(moveDirection));
    }
    public void AddPartyMember(int partyPosition, string name, ECharacterType characterType, int level)
    {
        partyPosition = Mathf.Clamp(partyPosition, 1, maxPartySize);
        partyPosition -= 1;

        switch (characterType)
        {
            case ECharacterType.MAGE:
                Mage newMage = gameObject.AddComponent<Mage>();
                newMage.InitializeCharacter(name, level);

                if (characters[partyPosition] != null)
                    RemovePartyMember(partyPosition + 1);

                characters[partyPosition] = (newMage);
                break;

            case ECharacterType.ROGUE:
                Rogue newRogue = gameObject.AddComponent<Rogue>();
                newRogue.InitializeCharacter(name, level);

                if (characters[partyPosition] != null)
                    RemovePartyMember(partyPosition + 1);

                characters[partyPosition] = (newRogue);
                break;

            case ECharacterType.WARRIOR:
                Warrior newWarrior = gameObject.AddComponent<Warrior>();
                newWarrior.InitializeCharacter(name, level);

                if (characters[partyPosition] != null)
                    RemovePartyMember(partyPosition + 1);

                characters[partyPosition] = (newWarrior);
                break;
        }

        maxEquipmentLoad += characters[partyPosition].EquipmentCapacity;
    }
    public void RemovePartyMember(int partyPosition)
    {
        partyPosition = Mathf.Clamp(partyPosition, 1, maxPartySize);
        partyPosition -= 1;

        if (characters[partyPosition] == null)
            return;

        maxEquipmentLoad -= characters[partyPosition].EquipmentCapacity;
        Destroy(characters[partyPosition]);
        characters[partyPosition] = null;
    }
    public void AddStatusEffect<T>(T statusEffect)where T : BaseStatusEffect
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != null)
            {
                characters[i].AddStatusEffect(statusEffect);

            }
        } 
    }
    public void AddStatusEffect<T>(T statusEffect, int partySlot)where T : BaseStatusEffect
    {
        partySlot -= 1;

        characters[partySlot].AddStatusEffect(statusEffect);
    }

    IEnumerator MovePlayer(Vector3 moveDestination)
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
