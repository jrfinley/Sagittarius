using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    public bool lockMovement = false;

    public int maxEquipmentLoad,
               equipmentLoad,
               maxPartySize,
               currentFood,
               foodPerMove;

    public float moveSpeed;
    public float moveXAmount;
    public float moveZAmount;
    public float posSnapDistance;

    public Vector3 movePosition;

    public BaseCharacter[] characters;

    public Rigidbody rb;

    private bool isMoving;

    private Sprite icon;

    private CharacterManager characterManager;
    private StatusEffectManager statusEffectManager;
    private PlayerEventManager eventManager;
    private Room currentRoom;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characters = new BaseCharacter[maxPartySize];
        movePosition = transform.position;
        characterManager = FindObjectOfType<CharacterManager>();
        statusEffectManager = FindObjectOfType<StatusEffectManager>();
        eventManager = GetComponent<PlayerEventManager>();
        eventManager.OnPlayerMove += EatFood;
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        //uncomment connection stuff when dungeon connections are done
        if (lockMovement)
            return;

        if (isMoving == true)
            return;
        else
            isMoving = true;

        if (currentRoom == null)
            currentRoom = GetRoom(transform.position);

        Vector3 oldPosition = transform.position;
        //Transform connection = null;

        if (moveDirection.z > 0)
        {
            //connection = currentRoom.Connections.northConnections[0];
            movePosition.z += moveZAmount;
            movePosition.x += moveXAmount;
        }
        else if (moveDirection.z < 0)
        {
            //connection = currentRoom.Connections.southConnections[0];
            movePosition.z -= moveZAmount;
            movePosition.x -= moveXAmount;
        }
        else if (moveDirection.x > 0)
        {
            //connection = currentRoom.Connections.eastConnections[0];
            movePosition.x += moveXAmount;
            movePosition.z -= moveZAmount;
        }
        else if (moveDirection.x < 0)
        {
            //connection = currentRoom.Connections.westConnections[0];
            movePosition.x -= moveXAmount;
            movePosition.z += moveZAmount;
        }

        Room targetRoom = GetRoom(movePosition);

        //for (int i = 0; i < currentRoom.Connections.closedConnections.Count; i++)
        //    if (connection == currentRoom.Connections.closedConnections[i])
        //        targetRoom = null;

        if (targetRoom == null)
        {
            movePosition = oldPosition;
            isMoving = false;
            return;
        }

        //StartCoroutine(MovePlayer(movePosition));
        StartCoroutine(MovePlayer(targetRoom.transform.position));
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
                if (!characterManager.allCharacters[i].isUnlocked || characterManager.allCharacters[i].IsTraining)
                {
                    Debug.Log("That character is not unlocked yet or is training");
                    return;
                }

                characters[partyPosition] = characterManager.allCharacters[i];
                characterManager.allCharacters[i].IsPartyMember = true;
                characterManager.allCharacters[i].PartyPosition = partyPosition + 1;
                maxEquipmentLoad += characterManager.allCharacters[i].EquipmentCapacity;
                foodPerMove += characterManager.allCharacters[i].FoodConsumption;
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
        foodPerMove -= characterManager.allCharacters[partyPosition].FoodConsumption;
        characters[partyPosition].IsPartyMember = false;
        characters[partyPosition] = null;
    }

    void EatFood()
    {
        currentFood -= foodPerMove;

        if (currentFood <= 0)
        {
            currentFood = 0;

            for (int i = 0; i < characters.Length; i++)
                statusEffectManager.AddStatusEffect(characters[i], 2);
        }
    }
    Room GetRoom(Vector3 checkPosition)
    {
        Room room = null;
        Collider[] moveSquares = Physics.OverlapSphere(checkPosition, transform.localScale.x);

        for (int i = 0; i < moveSquares.Length; i++)
        {
            print(checkPosition);
            float distFromCheck = (checkPosition - moveSquares[i].transform.position).magnitude;

            if (moveSquares[i].gameObject.GetComponent<Room>() && distFromCheck < 0.2f)
                room = moveSquares[i].gameObject.GetComponent<Room>();
        }

        return room;
    }

    IEnumerator MovePlayer(Vector3 targetPosition)
    {
		float loopCutoff = 0;
		Vector3 oldPosition = transform.position;
		
        while (transform.position != targetPosition && loopCutoff < 5)
        {
            Vector3 moveDir = (targetPosition - transform.position);

            if (moveDir.magnitude > posSnapDistance)
            {
                moveDir = moveDir.normalized * moveSpeed * Time.fixedDeltaTime;
                rb.MovePosition(rb.position + moveDir);
            }
            else
            {
                transform.position = targetPosition;
            }
			
			loopCutoff += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
		
		if (loopCutoff >= 5)
		{
			transform.position = oldPosition;
            movePosition = oldPosition;
            isMoving = false;
            Debug.LogError("Move player while loop reached cut off time");
            yield break;
		}

        isMoving = false;
        eventManager.FireOnPlayerMove();
    }

    //Properties
    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }
}
